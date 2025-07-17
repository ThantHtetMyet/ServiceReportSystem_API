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
                .Include(s => s.ProjectNo)
                .Include(s => s.System)
                .Include(s => s.Location)
                .Include(s => s.ServiceType)
                    .ThenInclude(st => st.ServiceTypeWarehouse)
                .Include(s => s.FormStatus)
                    .ThenInclude(fs => fs.FormStatusWarehouse)
                .Where(s => !s.IsDeleted)
                .Select(s => new ServiceReportDto
                {
                    JobNumber = s.JobNumber,
                    Customer = s.Customer,
                    SystemName = s.System.Name,
                    LocationName = s.Location.Name,
                    ProjectNoID = s.ProjectNoID,
                    ProjectNumberName = s.ProjectNo.ProjectNumber,
                    ServiceType = s.ServiceType.Select(st => new ServiceTypeDto
                    {
                        Id = st.ServiceTypeWarehouseID,
                        Name = st.ServiceTypeWarehouse.Name,
                        Remark = st.Remark
                    }).ToList(),
                    FormStatus = s.FormStatus.Select(fs => new FormStatusDto
                    {
                        Id = fs.FormStatusWarehouseID,
                        Name = fs.FormStatusWarehouse.Name,
                        Remark = fs.Remark
                    }).ToList()
                })
                .ToListAsync();

            return Ok(serviceReports);
        }


        // GET: api/ServiceReport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceReportDto>> GetServiceReport(Guid id)
        {
            var serviceReport = await _context.ServiceReportForms
                .Include(s => s.Customer)
                .Include(s => s.ProjectNo)
                .Include(s => s.System)
                .Include(s => s.Location)
                .Include(s => s.FollowupAction)
                .Include(s => s.ServiceType)
                    .ThenInclude(st => st.ServiceTypeWarehouse)
                .Include(s => s.FormStatus)
                    .ThenInclude(fs => fs.FormStatusWarehouse)
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
                Customer = serviceReport.Customer,
                ProjectNoID = serviceReport.ProjectNoID,
                SystemID = serviceReport.SystemID,
                SystemName = serviceReport.System.Name,
                LocationID = serviceReport.LocationID,
                LocationName = serviceReport.Location.Name,
                FollowupActionID = serviceReport.FollowupActionID,
                FollowupActionNo = serviceReport.FollowupAction.FollowupActionNo,
                FailureDetectedDate = serviceReport.FailureDetectedDate,
                ResponseDate = serviceReport.ResponseDate,
                ArrivalDate = serviceReport.ArrivalDate,
                CompletionDate = serviceReport.CompletionDate,
                CreatedDate = serviceReport.CreatedDate,
                CreatedByUserName = serviceReport.CreatedByUser.FirstName,
                UpdatedDate = serviceReport.UpdatedDate,
                UpdatedByUserName = serviceReport.UpdatedByUser.FirstName,
                ServiceType = serviceReport.ServiceType.Select(st => new ServiceTypeDto
                {
                    Id = st.ServiceTypeWarehouseID,
                    Name = st.ServiceTypeWarehouse.Name,
                    Remark = st.Remark
                }).ToList(),
                FormStatus = serviceReport.FormStatus.Select(fs => new FormStatusDto
                {
                    Id = fs.FormStatusWarehouseID,
                    Name = fs.FormStatusWarehouse.Name,
                    Remark = fs.Remark
                }).ToList()
            };

            return dto;
        }
        [HttpGet("NextJobNumber")]
        public async Task<ActionResult<string>> GetNextJobNumber()
        {
            var latestJobNumber = await _context.ServiceReportForms
                .Where(s => s.JobNumber != null)
                .OrderByDescending(s => s.CreatedDate) // Change to order by CreatedDate instead of ID
                .Select(s => s.JobNumber)
                .FirstOrDefaultAsync();

            // Generate the next job number
            string nextJobNumber;
            if (string.IsNullOrEmpty(latestJobNumber))
            {
                nextJobNumber = "M001"; // Initial job number
            }
            else
            {
                // Extract the numeric part and increment
                int currentNumber = int.Parse(latestJobNumber.Substring(2));
                nextJobNumber = $"M{(currentNumber + 1):D3}"; // Format with leading zeros
            }

            return Ok(new { jobNumber = nextJobNumber });
        }

        // POST: api/ServiceReport
        [HttpPost]
        public async Task<ActionResult<ServiceReportDto>> CreateServiceReport([FromBody] CreateServiceReportDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Get the latest job number
            var latestJobNumber = await _context.ServiceReportForms
                .Where(s => s.JobNumber != null)
                .OrderByDescending(s => s.ID)
                .Select(s => s.JobNumber)
                .FirstOrDefaultAsync();

            // Generate the next job number
            string nextJobNumber;
            if (string.IsNullOrEmpty(latestJobNumber))
            {
                nextJobNumber = "M001";
            }
            else
            {
                int currentNumber = int.Parse(latestJobNumber.Substring(2));
                nextJobNumber = $"M{(currentNumber + 1):D3}";
            }

            // Map DTO to Entity
            var serviceReport = new ServiceReportForm
            {
                ID = Guid.NewGuid(),
                JobNumber = nextJobNumber,
                Customer = createDto.Customer,
                ProjectNoID = createDto.ProjectNoID,
                SystemID = createDto.SystemID,
                LocationID = createDto.LocationID,
                FollowupActionID = createDto.FollowupActionID,
                FailureDetectedDate = createDto.FailureDetectedDate,
                ResponseDate = createDto.ResponseDate,
                ArrivalDate = createDto.ArrivalDate,
                CompletionDate = createDto.CompletionDate,
                IsDeleted = false,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                CreatedBy = Guid.Parse(createDto.CreatedBy),
                UpdatedBy = Guid.Parse(createDto.CreatedBy)
            };

            // Add related entities
            serviceReport.IssueReported = new List<IssueReported>
            {
                new IssueReported
                {
                    IssueReportWarehouseID = createDto.IssueReported[0].Id,
                    Remark = createDto.IssueReported[0].Remark,
                    ServiceReportFormID = serviceReport.ID,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    CreatedBy = Guid.Parse(createDto.CreatedBy),
                    UpdatedBy = Guid.Parse(createDto.CreatedBy),
                    IsDeleted = false,
                }
            };

            serviceReport.IssueFound = new List<IssueFound>
            {
                new IssueFound
                {
                    IssueFoundWarehouseID = createDto.IssueFound[0].Id,
                    ServiceReportFormID = serviceReport.ID,
                    Remark = createDto.IssueFound[0].Remark,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    CreatedBy = Guid.Parse(createDto.CreatedBy),
                    UpdatedBy = Guid.Parse(createDto.CreatedBy),
                    IsDeleted = false,
                }
            };

            serviceReport.ActionTaken = new List<ActionTaken>
            {
                new ActionTaken
                {
                    ActionTakenWarehouseID = createDto.ActionTaken[0].Id,
                    ServiceReportFormID = serviceReport.ID,
                    Remark = createDto.ActionTaken[0].Remark,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    CreatedBy = Guid.Parse(createDto.CreatedBy),
                    UpdatedBy = Guid.Parse(createDto.CreatedBy),
                    IsDeleted = false,
                }
            };

            serviceReport.ServiceType = new List<ServiceType>
            {
                new ServiceType
                {
                    ServiceTypeWarehouseID = createDto.ServiceType[0].Id,
                    Remark = createDto.ServiceType[0].Remark,
                    ServiceReportFormID = serviceReport.ID,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    CreatedBy = Guid.Parse(createDto.CreatedBy),
                    UpdatedBy = Guid.Parse(createDto.CreatedBy),
                    IsDeleted = false,
                }
            };

            serviceReport.FurtherActionTaken = new List<FurtherActionTaken>
            {
                new FurtherActionTaken
                {
                    FurtherActionTakenWarehouseID = createDto.FurtherAction[0].Id,
                    ServiceReportFormID = serviceReport.ID,
                    Remark = createDto.FurtherAction[0].Remark,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    CreatedBy = Guid.Parse(createDto.CreatedBy),
                    UpdatedBy = Guid.Parse(createDto.CreatedBy),
                    IsDeleted = false,
                }
            };

            serviceReport.FormStatus = new List<FormStatus>
            {
                new FormStatus
                {
                    FormStatusWarehouseID = createDto.FormStatus[0].Id,
                    ServiceReportFormID = serviceReport.ID,
                    Remark = createDto.FormStatus[0].Remark,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    CreatedBy = Guid.Parse(createDto.CreatedBy),
                    UpdatedBy = Guid.Parse(createDto.CreatedBy),
                    IsDeleted = false,
                }
            };

            // Add the ServiceReportForm to the DbContext
            _context.ServiceReportForms.Add(serviceReport);

            // Save all changes
            await _context.SaveChangesAsync();

            var responseDto = new ServiceReportDto
            {
                ID = serviceReport.ID,
                JobNumber = serviceReport.JobNumber,
                Customer = serviceReport.Customer,
                FailureDetectedDate = serviceReport.FailureDetectedDate,
                ResponseDate = serviceReport.ResponseDate,
                ArrivalDate = serviceReport.ArrivalDate,
                CompletionDate = serviceReport.CompletionDate
            };

            return CreatedAtAction(nameof(GetServiceReport), new { id = serviceReport.ID }, responseDto);
        }
        // In UpdateServiceReport method - parameter should be Guid
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateServiceReport(Guid id, UpdateServiceReportDto updateDto)
        {
            var serviceReport = await _context.ServiceReportForms.FindAsync(id);

            if (serviceReport == null || serviceReport.IsDeleted)
            {
                return NotFound();
            }

            serviceReport.Customer = updateDto.Customer;
            serviceReport.ProjectNoID = updateDto.ProjectNoID;
            serviceReport.SystemID = updateDto.SystemID;
            serviceReport.LocationID = updateDto.LocationID;
            serviceReport.FollowupActionID = updateDto.FollowupActionID;
            serviceReport.FailureDetectedDate = updateDto.FailureDetectedDate;
            serviceReport.ResponseDate = updateDto.ResponseDate;
            serviceReport.ArrivalDate = updateDto.ArrivalDate;
            serviceReport.CompletionDate = updateDto.CompletionDate;
            serviceReport.UpdatedDate = DateTime.UtcNow;
            serviceReport.UpdatedBy = Guid.Parse(updateDto.UpdatedBy);

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

        // In DeleteServiceReport method - parameter should be Guid
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceReport(Guid id)
        {
            var serviceReport = await _context.ServiceReportForms.FindAsync(id);
            if (serviceReport == null || serviceReport.IsDeleted)
            {
                return NotFound();
            }

            serviceReport.IsDeleted = true;
            serviceReport.UpdatedDate = DateTime.UtcNow;
            //serviceReport.UpdatedBy = 1; // Replace with actual user ID from authentication

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceReportExists(Guid id)
        {
            return _context.ServiceReportForms.Any(e => e.ID == id && !e.IsDeleted);
        }
    }
}