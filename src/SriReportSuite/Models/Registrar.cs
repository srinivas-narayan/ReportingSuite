using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SriReportSuite.Models
{
    public class Registrar
    {
        [Key]
        public int RegID { get; set; }
        [Display(Name = "Name"), StringLength(50, ErrorMessage = "First Name length should not be greater than 50")]
        public string ForeName { get; set; }
        [Display(Name = "Surname"), StringLength(50, ErrorMessage = "Last Name length should not be greater than 50")]
        public string SurName { get; set; }
        public string Designation { get; set; }

        [ForeignKey("Role")]
        public int RoleID { get; set; } //foreign key to roles

        public virtual ICollection<Study> Studies { get; set;  } //List of studies done.
    }
}
