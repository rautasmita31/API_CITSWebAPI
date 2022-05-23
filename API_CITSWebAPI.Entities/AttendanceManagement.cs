using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;


namespace API_CITSWebAPI.Entities
{
    [Table("Attendance_Management")]
   public class AttendanceManagement
    {
        [Key]
        [Column("AttendanceManagementId")]
        public double AttendanceManagementId { get; set; }

        [Column("Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Column("In-time")]
        [Required]
        [DataType(DataType.Time)]
        public DateTime Intime { get; set; }

        [Column("Out-time")]
        [Required]
        [DataType(DataType.Time)]
        public DateTime Outtime { get; set; }


        [Column("Late-Hours")]
        [Required]
        public int LateHours { get; set; }

        [Column("Half-Day-Leaves")]
        [Required]
        public int HalfDayLeaves { get; set; }

        [Column("Notes")]
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Notes { get; set; }
        public int EmployeeManagementEmployeeId { get; set; }
        public EmployeeManagement EmployeeManagement { get; }

    }
}
