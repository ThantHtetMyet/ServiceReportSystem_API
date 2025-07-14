
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceReportSystem.Models
{
    public class IssueFound
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("IssueFoundWarehouse")]
        public int IssueReportID { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public IssueFoundWarehouse IssueFoundWarehouse { get; set; }

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