using API.extensions;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public DateOnly DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastActive { get; set; } = DateTime.UtcNow;
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Photo> Photos { get; set; } = new List<Photo>();
        public List<UserLike> LikedByUsers { get; set; } = new List<UserLike>();
        public List<UserLike> LikedUsers { get; set; } = new List<UserLike>();
        public List<Message> MessagesSent { get; set; }
        public List<Message> MessagesReceived { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
 
        // The method must be named GetAge so that AutoMapper can automatically use it
        // // when mapping AppUser to MemberDto for the Age property.
        // public int GetAge()
        // {
        //     return DateOfBirth.CalculateAge();
        // }
    }
}
