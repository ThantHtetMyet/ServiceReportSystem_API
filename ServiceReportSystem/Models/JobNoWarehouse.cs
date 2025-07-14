
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceReportSystem.Models {
    public class JobNoWarehouse
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string JobNumber { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        [ForeignKey("CreatedByUser")]
        public int? CreatedBy { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public User? CreatedByUser { get; set; }
        [ForeignKey("UpdatedByUser")]
        public int? UpdatedBy { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public User? UpdatedByUser { get; set; }
    }
}