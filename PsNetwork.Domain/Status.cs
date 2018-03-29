namespace PsNetwork.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    public class Status
    {
        [Key]
        public int StatusId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun length for field {0} is {1} characters")]
       // [Index("Status_Name_Index", IsUnique = true)]
        [Display(Name = "Status")]
        public string Name { get; set; }
        
        [MaxLength(50, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        //[Index("Status_Table_Index", IsUnique = true)]
       public string Table { get; set; }

        [JsonIgnore] public virtual ICollection<Person> Persons { get; set; }
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<UserRol> UserRols { get; set; }
       
        [JsonIgnore]
        public virtual ICollection<Rol> Rols { get; set; }
        
        
    }
}
