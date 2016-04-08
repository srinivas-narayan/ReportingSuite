using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SriReportSuite.Models
{
    public class Flow
    {
        [Key]
        public int FlowID { get; private set; }
        [ForeignKey("Study")]
        public int StudyID { get; set; }
        public string Structure { get; set; }
        public float ForwardFlow { get; set; }
        public float ReverseFlow { get; set; }
        public int HeartRate { get; set; }
    }

    public class Image
    {
        [Key]
        public int ImageID { get; private set; }
        [ForeignKey("Study")]
        public int StudyID { get; set; }
        public byte[] Img { get; set; } //byte array to hold the image
        public string ImgDesc { get; set; } //80 character limit
    }

    public class Volume
    {
        [Key]
        public int VolumeID { get; private set;  }
        [ForeignKey("Study")]
        public int StudyID { get; set; }
        public string Chamber { get; set; }
        public float EDV { get; set; } //end-diastolic volume
        public float ESV { get; set; } //end systolic volume
        public int HeartRate { get; set; }
    }

    public class Measurement
    {
        [Key]
        public int MeasurementID { get; set; }
        [ForeignKey("Study")]
        public int StudyID { get; set; }
        public string Strucuture { get; set; }
        public string Measure { get; set; }
        public string MeasureSequence { get; set;  } //sequence measurement taken
    }

    public class Study
    {
        [Key, ConcurrencyCheck]
        public int StudyID { get; private set; }
        [ForeignKey("Patient")]     //Foreign key to patient table
        public int PatientID { get; set; }
        public DateTime StudyDate { get; set; }
        public DateTime ReportDate { get; set; }
        [Timestamp]
        public byte[] LastUpdated { get; set;  }
        public string StudyStatus { get; set; } //could be "Unknown", "Waitlisted", "Scheduled", "Performed", "Preliminary Report", "Final Report", "Amended Report" - only
        public string StudyType { get; set; }
        public bool GA { get; set; } //General Anaesthesia - Yes or No
        public string Echo { get; set; } //stores if echo done and if so - TOE / Transthoracic - hence "None", "Transthoracic", "Transesophageal", "Both TTE and TOE"
        public bool Bronchosopy { get; set; } //Yes or No
        public string Echocardiogram { get; set; } //types - None, Transthoracic, Transesophageal only
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal CVP { get; set; }
        public int Saturations { get; set; }
        public decimal FiO2 { get; set; } //as percentage, default 21%
        public string Indication { get; set; } //256 words describing indication
        public string Contrast { get; set; } //limit to None, Dotarem or Gadovist
        public string ContrastDose { get; set; } //if not None, then 0.2* Weight as default
        public string ScanSummary { get; set; } //comma seperated list of sequences used
        public string Findings { get; set; } //up to 5000 word text of findings (html) - should store text formatting and links to pictures.
        public string Summary { get; set; } //up to 1000 word summary of findings (html) - storing text formatting and links to pictures

        [ForeignKey("Registar")]
        public int RegID { get; set; } //ID of registar doing report - foreign key to Registrars.cs
        [ForeignKey("MRIConsultant")]
        public int ConsultantID { get; set; } //ID of consultant supervising study - foreign key to class MRIConsultants (superclass of Consultants)

        
        public ICollection<Flow> Flows { get; set; }
       
        public ICollection<Volume> Volumes { get; set; }
        
        public ICollection<Image> Images { get; set; }
        
        public ICollection<Measurement> Measurements { get; set; }

    }
}
//Nice reference about using List<T> vs. ICollection<T> at: http://stackoverflow.com/questions/7655845/icollectiont-vs-listt-in-entity-framework. In summary:
/* 
Entity Framework would use ICollection<T> because it needs to support Add operations, which are not part of the IEnumerable<T> interface. 
Also note that you were using ICollection<T>, you were merely exposing it as the List<T> implementation.List<T> brings along with it IList<T>, ICollection<T>, and IEnumerable<T>.
As for your change, exposing via the interface is a good choice, despite List<T> working.The interface defines the contract but not the implementation.
The implementation could change. In some instances, perhaps the implementation could be a HashSet<T>, for example. 
(This is a mindset you could use for more than just Entity Framework, by the way. A good object-oriented practice is to program towards the interface and not the implementation.
Implementations can and will change.)
*/