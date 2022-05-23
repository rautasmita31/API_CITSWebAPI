using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;


namespace API_CITSWebAPI.Entities
{
    [Table("Emp_Management")]
    public class EmployeeManagement
    {
        [Key]
        [Column("EmpId")]  
        public int EmployeeId { get; set; }

        [Column("EmpAddress")]
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Address { get; set; }

        [Column("DOB")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateofBirth { get; set; }


        [Column("ContactAddress")]
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string ContactAddress { get; set; }

        [Column("MobileNumber")]
        [Required]
        public double MobileNumber { get; set; }

        [Column("DOJ")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateofJoining { get; set; }


        [Column("BasicSalary")]
        [Required]
        public double BasicSalary { get; set; }

        [Column("Profession")]
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Profession { get; set; }

        [Column("Resume")]
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Resume { get; set; }

        [Column("OfferLetter")]
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string OfferLetter { get; set; }
        public string CompanyDetailsCompanyName { get; set; }

        public CompanyDetails CompanyDetails { get; }
        public List<AttendanceManagement> AttendanceManagement { get; }

    }
}

