using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceReportSystem.Data;
using ServiceReportSystem.Models;

namespace ServiceReportSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionTakenWarehouseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ActionTakenWarehouseController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActionTakenWarehouse>>> GetActionTakenWarehouses()
        {
            return await _context.ActionTakenWarehouses
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }
    }
}