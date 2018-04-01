using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsNetwork.Domain
{
    public class GroupComment
    {
        public int GroupCommentId { get; set; }
        public int UserId { get; set; }
        public int GroupPostId { get; set; }

        public string Commentary { get; set; }

        public DateTime CommentDate { get; set; }

        public virtual User User
        {
            get; set;

        }
        public virtual GroupPost GroupPost
        {
            get; set;
        }
    }
}
