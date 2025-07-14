
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceReportSystem.Models
{
    public class ActionTaken
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("ActionTakenWarehouse")]
        public int IssueReportID { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public ActionTakenWarehouse ActionTakenWarehouse { get; set; }

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