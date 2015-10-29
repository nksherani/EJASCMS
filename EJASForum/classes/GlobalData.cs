using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EJASForum.classes
{
    //global data for forum
    public class GlobalData
    {
        public static ForumThread CurrentThread;
        //public static int userid;
       public static int reply_pages=0;
        

    }
}