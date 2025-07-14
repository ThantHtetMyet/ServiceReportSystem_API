
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceReportSystem.Models {
    public class ServiceReportForm
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public CustomerWarehouse Customer { get; set; }

        [ForeignKey("FurtherActionTaken")]
        public int FurtherActionTakenID { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public FurtherActionTakenWarehouse FurtherActionTaken { get; set; }

        [ForeignKey("ProjectNo")]
        public int ProjectNoID { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public ProjectNoWarehouse ProjectNo { get; set; }

        [ForeignKey("System")]
        public int SystemID { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public SystemWarehouse System { get; set; }

        [ForeignKey("Location")]
        public int LocationID { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public LocationWarehouse Location { get; set; }

        [ForeignKey("FollowupAction")]
        public int FollowupActionID { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public FollowupActionWarehouse FollowupAction { get; set; }

        [ForeignKey("ServiceType")]
        public int ServiceTypeID { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public ServiceTypeWarehouse ServiceType { get; set; }

        [ForeignKey("FormStatus")]
        public int FormStatusID { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public FormStatusWarehouse FormStatus { get; set; }

        public DateTime? FailureDetectedDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public DateTime? CompletionDate { get; set; }
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

        public ICollection<IssueReported>? IssueReported { get; set; }
        public ICollection<IssueFound>? IssueFound { get; set; }
        public ICollection<ActionTaken>? ActionTaken { get; set; }
    }
}