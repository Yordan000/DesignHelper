using Microsoft.AspNetCore.Identity;

namespace DesignHelper.Infrastructure.Data
{
    public class ApplicationUser : IdentityUser
    {
        public List<UserProject> UsersProjects { get; set; } = new List<UserProject>();
    }
}
