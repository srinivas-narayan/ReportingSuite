using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SriReportSuite.Models
{
    public class Consultant
    {
        [Key]
        public int ConsultantID { get; set; }
        [Display(Name = "Name"), StringLength(50, ErrorMessage = "First Name length should not be greater than 50")]
        public string ForeName { get; set; }
        [Display(Name = "Surname"), StringLength(50, ErrorMessage = "Last Name length should not be greater than 50")]
        public string SurName { get; set; }
        [StringLength(50, ErrorMessage = "Designation should not be greater than 50 characters")]
        public string Designation { get; set; }

        [ForeignKey("Role")]
        public int RoleID { get; set; } //foreign key to roles


        public ICollection<Clinic> ClinicsDone { get; set; } //List of Cinics done

        public ICollection<Patient> PatientsSeen { get; set; } //List of Patients seen as named consultant 
    }

    public class MRIConsultants : Consultant //MRI consultants subgroup of Consultants
    {

        public ICollection<Patient> PatientsScanned { get; set; } //List of patients scanned

        public ICollection<Study> Studies { get; set; } //List of scans done
    }
}
