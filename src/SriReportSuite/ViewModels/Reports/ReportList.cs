using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SriReportSuite.Models;

namespace SriReportSuite.ViewModels.Reports
{
    public class StudyLineItem
    {
        public StudyStatus StudyStatus { get; set; } //Mapped to Study.StudyStatus (default order)
        public DateTime StudyDate { get; set; }//Map to Study.StudyDae
        public string HospNum { get; set; } //Map to Patient.HospNum
        public string PtName { get; set; } //Listed as Surname, FirstName - from Patient   (Order bt Surname)
        public DateTime DOB { get; set; } //Patient.DOB
        public string StudyComment { get; set; } //Study.StudyComment
    }
    
}
