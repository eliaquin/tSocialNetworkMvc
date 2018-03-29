namespace PsNetwork.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;
    public class SchoolLevel
    {
        [Key]
        public int SchoolLevelId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(100, ErrorMessage = "Max length is {1} ")]
        [Index("SchoolLevel_Name_Index", IsUnique = true)]
        [Display(Name = "School Level")]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Person> Persons { get; set; }
    }
}
