using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsNetwork.Domain
{
   public  class GroupPost
    {
        public int GroupPostId { get; set; }

        public int UserId { get; set; }

        public int UserGroupId { get; set; }

        public string PostStr { get; set; }

        public DateTime PostDate { get; set; }

        public virtual User User { get; set; }

        public virtual UserGroup UserGroup { get; set; }

        public virtual ICollection<GroupComment> GroupComments { get; set; }

    }
}
