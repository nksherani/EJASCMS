using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WebApplication1.cs
{
    public class Plugin
    {
        string Name;
        int Activated;
        DateTime DateInstalled;
        string About;
        string Author;

        //constructor
        public Plugin(string _Name)
        {
            Name = _Name;
            
        }
        public Plugin(string _Name, string _Author,string _About)
        {
            Name = _Name;
            Author = _Author;
            About = _About;
        }

        //unzip plugin
        public static bool ExtractPlugin(string archiveFilenameIn, string filename)
        {

            var folder = HttpContext.Current.Server.MapPath("~/Plugins");
            folder += "\\" + filename.Replace(".", "_");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            else
            {
                HttpContext.Current.Response.Write("Installation failed, folder of plugin already exists");
                return false;
            }

            string outFolder = folder; //HttpContext.Current.Server.MapPath("~/Plugins/"+archiveFilenameIn);
            ZipFile zf = null;
            try
            {
                FileStream fs = File.OpenRead(archiveFilenameIn);
                zf = new ZipFile(fs);

                foreach (ZipEntry zipEntry in zf)
                {
                    if (!zipEntry.IsFile)
                    {
                        continue;           // Ignore directories
                    }
                    String entryFileName = zipEntry.Name;
                    // to remove the folder from the entry:- entryFileName = Path.GetFileName(entryFileName);
                    // Optionally match entrynames against a selection list here to skip as desired.
                    // The unpacked length is available in the zipEntry.Size property.

                    byte[] buffer = new byte[4096];     // 4K is optimum
                    Stream zipStream = zf.GetInputStream(zipEntry);

                    // Manipulate the output filename here as desired.
                    String fullZipToPath = Path.Combine(outFolder, entryFileName);
                    string directoryName = Path.GetDirectoryName(fullZipToPath);
                    if (directoryName.Length > 0)
                        Directory.CreateDirectory(directoryName);

                    // Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                    // of the file, but does not waste memory.
                    // The "using" will close the stream even if an exception occurs.
                    using (FileStream streamWriter = File.Create(fullZipToPath))
                    {
                        StreamUtils.Copy(zipStream, streamWriter, buffer);
                    }
                }
            }
            finally
            {
                if (zf != null)
                {
                    zf.IsStreamOwner = true; // Makes close also shut the underlying stream
                    zf.Close(); // Ensure we release resources
                }
            }
            return true;
        }

        //saving dll assemblies to folder
        public static void SaveAssemblies(string path,string plugin)
        {
            //path = HttpContext.Current.Server.MapPath(path);
            var sourceDirectory = new DirectoryInfo(path);
            var sourceFiles = sourceDirectory.GetFiles();//.Where(f => ".dll" == (f.Extension.ToLower()));
            foreach(var i in sourceFiles)
            {
                if(i.Extension.ToLower()==".dll")
                {
                    string copyPath = HttpContext.Current.Server.MapPath("../Assemblies/" + i.Name);
                    try
                    {
                        i.CopyTo(copyPath,false);
                        Assembly.LoadFrom(copyPath);
                    }
                    catch (IOException ex)
                    {
                        HttpContext.Current.Response.Write(i.Name+" already exists<br/>");
                    }
                    SaveAssembliestoDb(i.Name, plugin);
                }
            }
        }

        public static void LoadAssemblies()
        {
            string Path = HttpContext.Current.Server.MapPath("../Assemblies");
            var sourceDirectory = new DirectoryInfo(Path);
            var sourceFiles = sourceDirectory.GetFiles();//.Where(f => ".dll" == (f.Extension.ToLower()));
            //Assembly assembly;
            foreach (var i in sourceFiles)
            {
                Assembly.LoadFrom(i.FullName);
            }
             
        }

        //saving dll to db
        public static void SaveAssembliestoDb(string Assembly, string Plugin)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "Insert into Assemblies values('" + Assembly + "','" + Plugin + "')";
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            com1.ExecuteReader();
            con1.Close();
        }

        //delete folders of plugin
        public static void DeleteDirectory(string path)
        {
            
            if (Directory.Exists(path))
            {
                //Delete all files from the Directory
                foreach (string file in Directory.GetFiles(path))
                {
                    File.Delete(file);
                }
                //Delete all child Directories
                foreach (string directory in Directory.GetDirectories(path))
                {
                    DeleteDirectory(directory);
                }
                //Delete a Directory
                Directory.Delete(path);
                
            }
        }

        //check if plugin is active or not
        public static int PluginStatus(string filename)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1 = "select Activated from plugins where name='" + filename + "'";
            SqlCommand com1 = new SqlCommand(q1, con1);
            con1.Open();
            int activated = Convert.ToInt32(com1.ExecuteScalar());
            con1.Close();
            return activated;
        }

        //read author and about
        public void Read_Author_About()
        {
            string filename = Name;
            var folder = HttpContext.Current.Server.MapPath("~/Plugins");
            folder += "\\" + filename.Replace(".", "_")+"\\author.txt";

            //reading author.txt from plugin folder
            //string author = "";
            //string path = HttpContext.Current.Server.MapPath("~/UserPages/" + pageName + ".aspx");
            using (StreamReader sr = new StreamReader(folder))
            {
                while (sr.Peek() >= 0)
                    Author += sr.ReadLine();
            }
            folder = HttpContext.Current.Server.MapPath("~/Plugins");
            folder += "\\" + filename.Replace(".", "_") + "\\about.txt";
            using (StreamReader sr = new StreamReader(folder))
            {
                while (sr.Peek() >= 0)
                    About += sr.ReadLine();
            }
        }

        //delete from plugins table 
        public static void DeletePluginfromDB(string filename)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            
            string q1 = "delete from plugins where Name='" + filename + "'";
            SqlCommand com1 = new SqlCommand(q1,con1);
            com1 = new SqlCommand(q1, con1);
            try
            {
                con1.Open();
                com1.ExecuteReader();
                con1.Close();

            }
            catch (SqlException ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
                con1.Close();
            }
        }

        //save plugin data to db
        public void SavePluginDatatoDB()
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
            string q1;
            if (!string.IsNullOrEmpty(About))
                q1 = "insert into plugins values('"+Name+"',0,@dt,'"+About+"','"+Author+"')";
            else
                q1 = "insert into plugins values('" + Name + "',0,@dt,'" + Author + "')";
            SqlCommand com1 = new SqlCommand(q1,con1);
            com1.Parameters.AddWithValue("@dt", DateTime.Now);
            con1.Open();
            com1.ExecuteReader();
            con1.Close();

        }
    }
}