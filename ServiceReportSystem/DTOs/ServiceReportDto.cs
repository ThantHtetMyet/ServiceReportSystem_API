using System;
using System.Collections.Generic;

namespace ServiceReportSystem.DTOs
{
    public class ServiceReportDto
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int ProjectNoID { get; set; }
        public string ProjectNumber { get; set; }
        public int SystemID { get; set; }
        public string SystemName { get; set; }
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public int FollowupActionID { get; set; }
        public string FollowupActionNo { get; set; }
        public int ServiceTypeID { get; set; }
        public string ServiceTypeName { get; set; }
        public int FormStatusID { get; set; }
        public string FormStatusName { get; set; }
        public DateTime? FailureDetectedDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserName { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedByUserName { get; set; }
    }

    public class CreateServiceReportDto
    {
        public int CustomerID { get; set; }
        public int ProjectNoID { get; set; }
        public int SystemID { get; set; }
        public int LocationID { get; set; }
        public int FollowupActionID { get; set; }
        public int ServiceTypeID { get; set; }
        public int FormStatusID { get; set; }
        public DateTime? FailureDetectedDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public List<CreateIssueReportedDto> IssueReported { get; set; }
        public List<CreateIssueFoundDto> IssueFound { get; set; }
        public List<CreateActionTakenDto> ActionTaken { get; set; }
    }

    public class UpdateServiceReportDto
    {
        public int CustomerID { get; set; }
        public int ProjectNoID { get; set; }
        public int SystemID { get; set; }
        public int LocationID { get; set; }
        public int FollowupActionID { get; set; }
        public int ServiceTypeID { get; set; }
        public int FormStatusID { get; set; }
        public DateTime? FailureDetectedDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public List<UpdateIssueReportedDto> IssueReported { get; set; }
        public List<UpdateIssueFoundDto> IssueFound { get; set; }
        public List<UpdateActionTakenDto> ActionTaken { get; set; }
    }
}