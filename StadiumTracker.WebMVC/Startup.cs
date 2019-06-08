using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using StadiumTracker.Data;

[assembly: OwinStartupAttribute(typeof(StadiumTracker.WebMVC.Startup))]
namespace StadiumTracker.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            string adminRole = "Admin";
            string userRole = "User";

            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists(adminRole))
            {
                var role = new IdentityRole(adminRole);
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "admin@example.com";
                user.Email = "admin@example.com";

                string userPWD = "password";

                var userCreationResult = UserManager.Create(user, userPWD);

                if (userCreationResult.Succeeded)
                    UserManager.AddToRole(user.Id, adminRole);
            }

            if (!roleManager.RoleExists(userRole))
            {
                var role = new IdentityRole(userRole);
                roleManager.Create(role);
            }
        }
    }
}
