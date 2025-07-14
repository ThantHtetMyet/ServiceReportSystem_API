
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceReportSystem.Models {
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

       
        [Column(TypeName = "nvarchar(100)")]
        public string MobileNo { get; set; }

        
        [Column(TypeName = "nvarchar(100)")]
        public string Gender { get; set; }

        
        [Column(TypeName = "nvarchar(100)")]
        public string LoginPassword { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime LastLogin { get; set; }
    }
}