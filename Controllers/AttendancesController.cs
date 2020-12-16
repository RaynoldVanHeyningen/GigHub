using GigHub.Areas.Identity.Data;
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
        public ActionResult Attend([FromBody] int gigId)
        {
            var attendance = new Attendance
            {
                GigId = gigId,
                AttendeeId = _userManager.GetUserId(User)
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}