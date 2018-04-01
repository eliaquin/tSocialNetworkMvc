using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PsNetwork.Domain
{
    public class TimeLinePost
    {
        public int TimeLinePostId { get; set; }

        public int UserId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? PublishDate { get; set; }

        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string PostStr { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
