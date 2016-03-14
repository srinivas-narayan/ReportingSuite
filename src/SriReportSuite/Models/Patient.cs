using System;
using System.ComponentModel.DataAnnotations;

namespace SriReportSuite.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }
        [Display(Name = "First Name"), FirstNameValidation]
        public string FirstName { get; set; }
        [Display(Name = "Second Name"), StringLength(50, ErrorMessage = "Last Name length should not be greater than 50")]
        public string SurName { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        [Display(Name = "Hospital Number")]
        public string HospNum { get; set; }
        [Display(Name = "NHS Number")]
        public string NHSNum { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [Display(Name ="Post code")]
        public string PostCode { get; set; }
        [Display(Name = "Dead?")]
        public bool dead { get; set; }

        //the following can be made more granular if desired!! - Need to carefully think this through.. not end up as another HS
        [MaxLength(2000)]
        public string Diagnosis { get; set; }
        [MaxLength(2000)]
        public string Procedures { get; set; }

        //foriegn keys
        [Display(Name ="Consultant")]
        public int ConsID { get; set; } //one to one look up with tblConsultants
        [Display(Name = "Clinic")]
        public int ClinicID { get; set; } //one to one look up with clinic ID


        public override string ToString() //coughs up most data as string
        {
            return (FirstName + " " + SurName + " --|-- "
                + DOB.ToString() + " --|-- "
                + HospNum + " --|-- "
                + Address + " --|-- "
                + City + " --|-- "
                + PostCode + " --|-- "
                + dead.ToString());
        }
    }

    public class FirstNameValidation : ValidationAttribute //server side custom validation!!
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Please provide a First Name");
            }
            else
            {
                if (value.ToString().Contains("@"))
                {
                    return new ValidationResult("First name has invalid character @");
                }

            }
            return ValidationResult.Success;
        }
    }
}