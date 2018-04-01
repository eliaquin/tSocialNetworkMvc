using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsNetwork.Domain
{
    public class UserGroup
    {
        public int UserGroupId { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public string Picture { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual User User { get; set; }
    }
}
