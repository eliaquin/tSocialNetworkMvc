﻿namespace PsNetwork.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Type")]
        public int UserTypeId { get; set; }
        //[Display(Name = "Nivel")]
        //public int? Level { get; set; }

        [Display(Name = "Picture")]
        [DataType(DataType.ImageUrl)]
        public string Picture { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(100, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        [DataType(DataType.EmailAddress)]
        //[Index("User_Email_Index", IsUnique = true)]
        public string Email { get; set; }

        [Display(Name = "Status")]
        public int StatusId { get; set; }
        
        [JsonIgnore]
        public virtual UserType UserType { get; set; }

        [JsonIgnore]
        public virtual Status Status { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<UserRol> UserRols { get; set; }
        
    }

}
