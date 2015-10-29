using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJASForum.classes
{
    public class ForumReply
    {
        public int ReplyId;
        public int ReplierId;
        public string Replier;
        public int ThreadId;
        public string ReplyBody;
        public DateTime DateCreated;
        public DateTime DateModified;
        public DateTime DatePublished;
        public int Published;

        public ForumReply()
        {

        }
    }
}
