namespace ServiceReportSystem.DTOs
{
    public class IssueReportedDto
    {
        public Guid ID { get; set; }
        public string Description { get; set; }
        public string Remark { get; set; }
    }

    public class CreateIssueReportedDto
    {
        public string Description { get; set; }
        public string Remark { get; set; }
    }

    public class UpdateIssueReportedDto
    {
        public Guid ID { get; set; }  // Add ID property
        public string Description { get; set; }
        public string Remark { get; set; }
        public string UpdatedBy { get; set; }  // Add UpdatedBy property
    }

    public class IssueFoundDto
    {
        public Guid ID { get; set; }
        public string Description { get; set; }
        public string Remark { get; set; }
    }

    public class CreateIssueFoundDto
    {
        public string Description { get; set; }
        public string Remark { get; set; }
    }

    public class UpdateIssueFoundDto
    {
        public Guid ID { get; set; }  // Add ID property
        public string Description { get; set; }
        public string Remark { get; set; }
        public string UpdatedBy { get; set; }  // Add UpdatedBy property
    }

    public class ActionTakenDto
    {
        public Guid ID { get; set; }
        public string Description { get; set; }
    }

    public class CreateActionTakenDto
    {
        public string Description { get; set; }
    }

    public class UpdateActionTakenDto
    {
        public Guid ID { get; set; }  // Add ID property
        public string Description { get; set; }
        public string UpdatedBy { get; set; }  // Add UpdatedBy property
    }

    public class ServiceTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
    }

    public class FormStatusDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
    }
}