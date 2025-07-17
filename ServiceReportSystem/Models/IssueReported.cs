
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceReportSystem.Models
{
    public class IssueReported
    {
        [Key]
        public Guid ID { get; set; }
        public string? Description { get; set; }
        public string? Remark { get; set; }

        [ForeignKey("IssueReportWarehouse")]
        public Guid IssueReportWarehouseID { get; set; }

        [ForeignKey("ServiceReportForm")]
        public Guid ServiceReportFormID { get; set; }

        [ForeignKey("CreatedByUser")]
        public Guid? CreatedBy { get; set; }

        [ForeignKey("UpdatedByUser")]
        public Guid? UpdatedBy { get; set; }
        public User UpdatedByUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}