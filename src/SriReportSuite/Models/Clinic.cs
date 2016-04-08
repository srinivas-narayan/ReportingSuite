using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SriReportSuite.Models
{
    public class Clinic
    {
        [Key]
        public int ClinicID { get; set; }
        [ForeignKey("Consultant")]
        public int ConsultantID { get; set; }
        [Required, StringLength(50, ErrorMessage ="Maximum length is 50 characters")]
        public string ClinicPlace { get; set; }
        [Required, StringLength(5, ErrorMessage ="Maximum length is 5 characters")]
        public string ClinicShortName { get; set; }

        
        public ICollection<Patient> Patients { get; set; } //List of patients in clinic
    }
}
