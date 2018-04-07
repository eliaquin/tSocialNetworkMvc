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

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required")]
        [StringLength(20, ErrorMessage = "Max length is {0}")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required")]
        [Compare("Password", ErrorMessage = "The password and the confirmation must be equals")]
        [Display(Name = "Password Confirm")]
        public string PasswordConfirm { get; set; }
    }
}
