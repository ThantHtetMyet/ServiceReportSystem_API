using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceReportSystem.Data;
using ServiceReportSystem.Models;

namespace ServiceReportSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueReportWarehouseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IssueReportWarehouseController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IssueReportWarehouse>>> GetIssueReportWarehouses()
        {
            return await _context.IssueReportWarehouses
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }
    }
}