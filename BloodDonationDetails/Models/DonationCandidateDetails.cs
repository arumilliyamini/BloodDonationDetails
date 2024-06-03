using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BloodDonationDetails.Models
{
    public class DonationCandidateDetails
    {
        [Key]
        public int DonatedpersonID { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? First_Name { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? Last_Name { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? MobileNumber { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? Email { get; set; }
        public int? Age { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? BloodGroup { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? Address { get; set; }

    }
}
