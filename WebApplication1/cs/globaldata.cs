using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Xml;

//global data for cms
public class globaldata
{
    //Attributes
    //number of posts displayed on a single page at a time
    public static int no_of_Posts=10;//naveed

    //sequence of first post displayed
    public static int initial_post = 1;

    //number of times next button pressed to see next N posts
    public static int pages_visited=0;

    //used in reading and editing a page dynamically
    public static List<string> PageContents;

    //function to make or update connection string
    public static void AddUpdateConnectionString(string name, string server, string database, string username, string password)
    {
        bool isNew = false;
        string path = HttpContext.Current.Server.MapPath("~/Web.Config");
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        XmlNodeList list = doc.DocumentElement.SelectNodes(string.Format("connectionStrings/add[@name='{0}']", name));
        XmlNode node;
        isNew = list.Count == 0;
        if (isNew)
        {
            node = doc.CreateNode(XmlNodeType.Element, "add", null);
            XmlAttribute attribute = doc.CreateAttribute("name");
            attribute.Value = name;
            node.Attributes.Append(attribute);

            attribute = doc.CreateAttribute("connectionString");
            attribute.Value = "";
            node.Attributes.Append(attribute);

            attribute = doc.CreateAttribute("providerName");
            attribute.Value = "System.Data.SqlClient";
            node.Attributes.Append(attribute);
        }
        else
        {
            node = list[0];
        }
        string conString = node.Attributes["connectionString"].Value;
        SqlConnectionStringBuilder conStringBuilder = new SqlConnectionStringBuilder(conString);
        conStringBuilder.InitialCatalog = database;
        conStringBuilder.DataSource = server;
        conStringBuilder.IntegratedSecurity = false;
        conStringBuilder.UserID = username;
        conStringBuilder.Password = password;
        node.Attributes["connectionString"].Value = conStringBuilder.ConnectionString;
        if (isNew)
        {
            doc.DocumentElement.SelectNodes("connectionStrings")[0].AppendChild(node);
        }
        doc.Save(path);
    }

    //create table using ddl
    public static void create_table(string ddl,string table_name)
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
        SqlCommand com1 = new SqlCommand(ddl, con1);
        string exception_query = "";
        try//normal execution if table is not already present in database
        {
            con1.Open();
            com1.ExecuteReader();
            con1.Close();
            HttpContext.Current.Response.Write("<p style=\"color:green\">Table " + table_name + " Created Successfully</p>");
        }
        catch (SqlException ex)//if table is present or some other reason prevents the function to work properly
        //then catch block is run to display the error details
        {
            HttpContext.Current.Response.Write("<p style =\"color:red\">" +ex.Message + "</p>");

            //empty the already existing table
            exception_query = "truncate table [dbo].["+table_name+"]";
            com1 = new SqlCommand(exception_query, con1);
            try
            {
                //execute truncation
                com1.ExecuteReader();
                con1.Close();
            }
            catch (SqlException exc)//truncation failed
            {
                //print erroor message
                HttpContext.Current.Response.Write("<p style =\"color:red\">" + exc.Message + "</p>");
                con1.Close();
            }

        }
    }
    public static void create_sequence(string sequence_name)
    {
        //CREATE SEQUENCE test_Seq AS INTEGER START WITH 1 INCREMENT BY 1 MINVALUE 1 CYCLE;
        string exception_query;
        string q1 = "create sequence " + sequence_name+ " AS INTEGER START WITH 1 INCREMENT BY 1 MINVALUE 1 CYCLE;";
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
        SqlCommand com1 = new SqlCommand(q1, con1);
        con1.Open();
        try
        {
            //sequence creation normal execution
            com1.ExecuteReader();
            con1.Close();
            HttpContext.Current.Response.Write("<p style=\"color:green\">Sequence " + sequence_name + " Created Successfully</p>");
        }
        catch(SqlException ex)//if try block fails
        {
            HttpContext.Current.Response.Write("<p style =\"color:red\">" + ex.Message + "</p>");
            exception_query = "alter sequence "+sequence_name+" restart with 1";
            com1 = new SqlCommand(exception_query, con1);
            try
            {
                com1.ExecuteReader();
                con1.Close();
            }
            catch (SqlException exc)
            {
                HttpContext.Current.Response.Write("<p style =\"color:red\">" + exc.Message + "</p>");
                con1.Close();
            }

        }
        
    }

    //Getting current value of any sequence by passing only its name
    public static string GetCurrentValueofSequence(string sequence_name)
    {
        string q1 = "select current_value from sys.sequences where name = '"+sequence_name+"'";
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["globaldb"].ConnectionString);
        SqlCommand com1 = new SqlCommand(q1, con1);
        string currentIndex="";
        con1.Open();
        try
        {
            currentIndex= com1.ExecuteScalar().ToString();
            con1.Close();
            return currentIndex;
        }
        catch (SqlException ex)
        {
            con1.Close();
            return ex.Message;

        }

    }

    

    
}