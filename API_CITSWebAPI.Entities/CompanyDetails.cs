using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Collections.Generic;


namespace API_CITSWebAPI.Entities
{
    [Table("CompanyDetails")]
    public class CompanyDetails
    {
        [Key]
        [Column("Cname")]   
        [StringLength(50, MinimumLength = 3)]
        public string CompanyName { get; set; }
        [Column("CAddress")]
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Address { get; set; }
        [Column("ContactNumber")]
        [Required]
        public double ContactNumber { get; set; }
        [Column("CLogo")]
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string CLogo { get; set; }

        public List<EmployeeManagement> EmployeeManagements { get; }

    }
}
