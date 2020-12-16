using System.Linq;
using GigHub.Areas.Identity.Data;
using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GigHub.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController : ControllerBase
    {
        private readonly GigHubIdentityDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AttendancesController(GigHubIdentityDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public ActionResult Attend(AttendanceDto dto)
        {
            var userId = _userManager.GetUserId(User);

            if (_context.Attendances.Any(a => a.GigId == dto.GigId && a.AttendeeId == userId)) return BadRequest("The attendance already exists.");

            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}