namespace PsNetwork.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using PsNetwork.Domain;
    using Newtonsoft.Json;
    public   class Rol
    {

        [Key]
        public int RolId { get; set; }       

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(20, ErrorMessage = "Max length is {1}")]
        [Display(Name = "Rol")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(100, ErrorMessage = "Max length is {1}")]
        public string Description { get; set; }        
        
        [Display(Name = "Status")]
        public int StatusId { get; set; }


        [JsonIgnore]
        public virtual Status Status { get; set; }

        
    }
}
