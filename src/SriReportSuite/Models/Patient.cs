using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SriReportSuite.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }
        [Display(Name = "Name"), StringLength(50, ErrorMessage = "First Name length should not be greater than 50"), FirstNameValidation]
        public string FirstName { get; set; }
        [Required, Display(Name = "Surname"), StringLength(50, ErrorMessage = "Last Name length should not be greater than 50")]
        public string SurName { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] //to make the date in acceptable format to Chrome HTML5 date field
        public DateTime DOB { get; set; }
        [Required, Display(Name = "Hosp. Number"), StringLength(15, ErrorMessage = "Hospital number length should not be greater than 15")]
        public string HospNum { get; set; }
        [Display(Name = "NHS Number"), StringLength(15, ErrorMessage = "NHS number length should not be greater than 15")]
        public string NHSNum { get; set; }
        [StringLength(100, ErrorMessage = "Address length should not be greater than 100")]
        public string Address { get; set; }
        [StringLength(50, ErrorMessage = "City should not be greater than 50 characters")]
        public string City { get; set; }
        [Required, Display(Name ="Postcode"), StringLength(15, ErrorMessage = "Postcode length should not be greater than 15")]
        public string PostCode { get; set; }
        [Display(Name = "Dead?")]
        public bool Dead { get; set; }

        //the following can be made more granular if desired!! - Need to carefully think this through.. not end up as another HS

        [MaxLength(2000)]
        public string Diagnosis { get; set; }
        
        [MaxLength(2000)]
        public string Procedures { get; set; }

        //foriegn keys
        [ForeignKey("Consultant")]
        public int ConsultantID; //Patient's Consultant
        [ForeignKey("Clinic")]
        public int ClinicID; //Patient's Clinic

        //List of Patient's MRI Study
        
        public virtual ICollection<Study> Studies { get; set; } 
 

        public override string ToString() //collects up most data as string - for debugging purposes
        {
            return (FirstName + " " + SurName + " --|-- "
                + DOB.ToString() + " --|-- "
                + HospNum + " --|-- "
                + Address + " --|-- "
                + City + " --|-- "
                + PostCode + " --|-- "
                + Dead.ToString());
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