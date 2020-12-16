using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Models
{
    public class Follow
    {
        public ApplicationUser User { get; set; }
        public ApplicationUser FollowedUser { get; set; }

        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string FollowedUserId { get; set; }
    }
}