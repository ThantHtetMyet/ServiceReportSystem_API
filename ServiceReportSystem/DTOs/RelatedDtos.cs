namespace ServiceReportSystem.DTOs
{
    public class IssueReportedDto
    {
        public int ID { get; set; }
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
        public string Description { get; set; }
        public string Remark { get; set; }
    }

    public class IssueFoundDto
    {
        public int ID { get; set; }
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
        public string Description { get; set; }
        public string Remark { get; set; }
    }

    public class ActionTakenDto
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }

    public class CreateActionTakenDto
    {
        public string Description { get; set; }
    }

    public class UpdateActionTakenDto
    {
        public string Description { get; set; }
    }
}