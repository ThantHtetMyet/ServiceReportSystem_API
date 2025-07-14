using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceReportSystem.Data;
using ServiceReportSystem.DTOs;
using ServiceReportSystem.Models;

namespace ServiceReportSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceReportController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServiceReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ServiceReport
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceReportDto>>> GetServiceReports()
        {
            var serviceReports = await _context.ServiceReportForms
                .Include(s => s.Customer)
                .Include(s => s.ProjectNo)
                .Include(s => s.System)
                .Include(s => s.Location)
                .Include(s => s.FollowupAction)
                .Include(s => s.ServiceType)
                .Include(s => s.FormStatus)
                .Include(s => s.CreatedByUser)
                .Include(s => s.UpdatedByUser)
                .Include(s => s.IssueReported)
                .Include(s => s.IssueFound)
                .Include(s => s.ActionTaken)
                .Where(s => !s.IsDeleted)
                .Select(s => new ServiceReportDto
                {
                    ID = s.ID,
                    CustomerID = s.CustomerID,
                    CustomerName = s.Customer.Name,
                    ProjectNoID = s.ProjectNoID,
                    ProjectNumber = s.ProjectNo.ProjectNumber,
                    SystemID = s.SystemID,
                    SystemName = s.System.Name,
                    LocationID = s.LocationID,
                    LocationName = s.Location.Name,
                    FollowupActionID = s.FollowupActionID,
                    FollowupActionNo = s.FollowupAction.FollowupActionNo,
                    ServiceTypeID = s.ServiceTypeID,
                    ServiceTypeName = s.ServiceType.Name,
                    FormStatusID = s.FormStatusID,
                    FormStatusName = s.FormStatus.Name,
                    FailureDetectedDate = s.FailureDetectedDate,
                    ResponseDate = s.ResponseDate,
                    ArrivalDate = s.ArrivalDate,
                    CompletionDate = s.CompletionDate,
                    CreatedDate = s.CreatedDate,
                    CreatedByUserName = s.CreatedByUser.FirstName,
                    UpdatedDate = s.UpdatedDate,
                    UpdatedByUserName = s.UpdatedByUser.FirstName
                })
                .ToListAsync();

            return serviceReports;
        }

        // GET: api/ServiceReport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceReportDto>> GetServiceReport(int id)
        {
            var serviceReport = await _context.ServiceReportForms
                .Include(s => s.Customer)
                .Include(s => s.ProjectNo)
                .Include(s => s.System)
                .Include(s => s.Location)
                .Include(s => s.FollowupAction)
                .Include(s => s.ServiceType)
                .Include(s => s.FormStatus)
                .Include(s => s.CreatedByUser)
                .Include(s => s.UpdatedByUser)
                .Include(s => s.IssueReported)
                .Include(s => s.IssueFound)
                .Include(s => s.ActionTaken)
                .FirstOrDefaultAsync(s => s.ID == id && !s.IsDeleted);

            if (serviceReport == null)
            {
                return NotFound();
            }

            var dto = new ServiceReportDto
            {
                ID = serviceReport.ID,
                CustomerID = serviceReport.CustomerID,
                CustomerName = serviceReport.Customer.Name,
                ProjectNoID = serviceReport.ProjectNoID,
                ProjectNumber = serviceReport.ProjectNo.ProjectNumber,
                SystemID = serviceReport.SystemID,
                SystemName = serviceReport.System.Name,
                LocationID = serviceReport.LocationID,
                LocationName = serviceReport.Location.Name,
                FollowupActionID = serviceReport.FollowupActionID,
                FollowupActionNo = serviceReport.FollowupAction.FollowupActionNo,
                ServiceTypeID = serviceReport.ServiceTypeID,
                ServiceTypeName = serviceReport.ServiceType.Name,
                FormStatusID = serviceReport.FormStatusID,
                FormStatusName = serviceReport.FormStatus.Name,
                FailureDetectedDate = serviceReport.FailureDetectedDate,
                ResponseDate = serviceReport.ResponseDate,
                ArrivalDate = serviceReport.ArrivalDate,
                CompletionDate = serviceReport.CompletionDate,
                CreatedDate = serviceReport.CreatedDate,
                CreatedByUserName = serviceReport.CreatedByUser.FirstName,
                UpdatedDate = serviceReport.UpdatedDate,
                UpdatedByUserName = serviceReport.UpdatedByUser.FirstName
            };

            return dto;
        }

        // POST: api/ServiceReport
        [HttpPost]
        public async Task<ActionResult<ServiceReportDto>> CreateServiceReport(CreateServiceReportDto createDto)
        {
            var serviceReport = new ServiceReportForm
            {
                CustomerID = createDto.CustomerID,
                ProjectNoID = createDto.ProjectNoID,
                SystemID = createDto.SystemID,
                LocationID = createDto.LocationID,
                FollowupActionID = createDto.FollowupActionID,
                ServiceTypeID = createDto.ServiceTypeID,
                FormStatusID = createDto.FormStatusID,
                FailureDetectedDate = createDto.FailureDetectedDate,
                ResponseDate = createDto.ResponseDate,
                ArrivalDate = createDto.ArrivalDate,
                CompletionDate = createDto.CompletionDate,
                IsDeleted = false,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                CreatedBy = 1, // Replace with actual user ID from authentication
                UpdatedBy = 1  // Replace with actual user ID from authentication
            };

            _context.ServiceReportForms.Add(serviceReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetServiceReport), new { id = serviceReport.ID }, serviceReport);
        }

        // PUT: api/ServiceReport/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateServiceReport(int id, UpdateServiceReportDto updateDto)
        {
            var serviceReport = await _context.ServiceReportForms.FindAsync(id);

            if (serviceReport == null || serviceReport.IsDeleted)
            {
                return NotFound();
            }

            serviceReport.CustomerID = updateDto.CustomerID;
            serviceReport.ProjectNoID = updateDto.ProjectNoID;
            serviceReport.SystemID = updateDto.SystemID;
            serviceReport.LocationID = updateDto.LocationID;
            serviceReport.FollowupActionID = updateDto.FollowupActionID;
            serviceReport.ServiceTypeID = updateDto.ServiceTypeID;
            serviceReport.FormStatusID = updateDto.FormStatusID;
            serviceReport.FailureDetectedDate = updateDto.FailureDetectedDate;
            serviceReport.ResponseDate = updateDto.ResponseDate;
            serviceReport.ArrivalDate = updateDto.ArrivalDate;
            serviceReport.CompletionDate = updateDto.CompletionDate;
            serviceReport.UpdatedDate = DateTime.UtcNow;
            serviceReport.UpdatedBy = 1; // Replace with actual user ID from authentication

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceReportExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/ServiceReport/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceReport(int id)
        {
            var serviceReport = await _context.ServiceReportForms.FindAsync(id);
            if (serviceReport == null || serviceReport.IsDeleted)
            {
                return NotFound();
            }

            serviceReport.IsDeleted = true;
            serviceReport.UpdatedDate = DateTime.UtcNow;
            serviceReport.UpdatedBy = 1; // Replace with actual user ID from authentication

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceReportExists(int id)
        {
            return _context.ServiceReportForms.Any(e => e.ID == id && !e.IsDeleted);
        }
    }
}