using System.Linq;
using Dtos;
using GigHub.Areas.Identity.Data;
using GigHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GigHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FollowController : ControllerBase
    {
        UserManager<ApplicationUser> _userManager;
        GigHubIdentityDbContext _context;

        public FollowController(UserManager<ApplicationUser> userManager, GigHubIdentityDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpPost]
        public ActionResult Follow(FollowingDto dto)
        {
            var userId = _userManager.GetUserId(User);

            if (_context.Followings.Any(f => f.UserId == userId && f.FollowedUserId == dto.FollowUserId)) return BadRequest("You are already following this user.");

            var follow = new Follow
            {
                UserId = userId,
                FollowedUserId = dto.FollowUserId
            };

            _context.Followings.Add(follow);
            _context.SaveChanges();

            return Ok();
        }
    }
}