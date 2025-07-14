using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceReportSystem.Data;
using ServiceReportSystem.Models;

namespace ServiceReportSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectNoWarehouseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectNoWarehouseController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectNoWarehouse>>> GetProjectNoWarehouses()
        {
            return await _context.ProjectNoWarehouses
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }
    }
}