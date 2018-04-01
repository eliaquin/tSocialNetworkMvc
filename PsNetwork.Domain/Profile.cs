using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using PsNetwork.Domain;

namespace PsNetwork.Domain
{
    [NotMapped]
    public class Profile : User
    {
        [Display(Name = "Imagen")]
        public HttpPostedFileBase ImageFile { get; set; }

    }
}
