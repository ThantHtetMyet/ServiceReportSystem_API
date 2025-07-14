using Microsoft.EntityFrameworkCore;
using ServiceReportSystem.Models;

namespace ServiceReportSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ServiceReportForm> ServiceReportForms { get; set; }
        public DbSet<CustomerWarehouse> CustomerWarehouses { get; set; }
        public DbSet<ProjectNoWarehouse> ProjectNoWarehouses { get; set; }
        public DbSet<SystemWarehouse> SystemWarehouses { get; set; }
        public DbSet<LocationWarehouse> LocationWarehouses { get; set; }
        public DbSet<FollowupActionWarehouse> FollowupActionWarehouses { get; set; }
        public DbSet<ServiceTypeWarehouse> ServiceTypeWarehouses { get; set; }
        public DbSet<FormStatusWarehouses> FormStatusWarehouses { get; set; }
        public DbSet<IssueReported> IssueReported { get; set; }
        public DbSet<IssueFound> IssueFound { get; set; }
        public DbSet<ActionTaken> ActionTaken { get; set; }
        public DbSet<IssueReportWarehouse> IssueReportWarehouses { get; set; }
        public DbSet<IssueFoundWarehouse> IssueFoundWarehouses { get; set; }
        public DbSet<ActionTakenWarehouse> ActionTakenWarehouses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FurtherActionTakenWarehouse> FurtherActionTakenWarehouses { get; set; }
    }
}