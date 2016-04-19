using System.ComponentModel.DataAnnotations;

namespace SriReportSuite.Models
{
    public class Role
    {
        [Key]
        public int RoleID { get; private set; }
        [Required, StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string RoleDesc { get; set; }
    }
}
