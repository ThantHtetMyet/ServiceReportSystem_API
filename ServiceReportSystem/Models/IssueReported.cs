
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceReportSystem.Models
{
    public class IssueReported
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("IssueReportWarehouse")]
        public int IssueReportID { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public IssueReportWarehouse IssueReportWarehouse { get; set; }

        [ForeignKey("ServiceReportForm")]
        public int ServiceReportFormID { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public ServiceReportForm ServiceReportForm { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Remark { get; set; }
    }
}