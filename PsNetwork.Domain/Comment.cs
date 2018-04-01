using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsNetwork.Domain
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int TimeLinePostId { get; set; }

        public string Commentary { get; set; }

        public DateTime CommentDate { get; set; }

        public virtual User User
        {
            get; set;

        }
        public virtual TimeLinePost ToTimeLinePost
        {
            get; set;
        }
    }
}
