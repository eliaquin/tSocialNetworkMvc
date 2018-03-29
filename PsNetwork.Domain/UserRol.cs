namespace PsNetwork.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    public  class UserRol
    {

        [Key]
        public int UserRolId { get; set; }

       //public int RolId { get; set; }

       // public int UserId { get; set; }

        [Display(Name = "From")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FromDate { get; set; }

        [Display(Name = "To")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ToDate { get; set; }

        [Display(Name = "Undefined ?")]
        public bool Undefined { get; set; }


        //[Display(Name = "Status")]
        //public int StatusId { get; set; }
        
        //[JsonIgnore]
        //public virtual Status Status { get; set; }

        //[JsonIgnore]
        //public virtual Rol Rol { get; set; }
        //[JsonIgnore]
        //public virtual User User { get; set; }


    }
}
