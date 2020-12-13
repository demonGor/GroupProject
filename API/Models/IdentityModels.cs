using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;

namespace API.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        { }
        

        public static ApplicationDbContext Create()
        {
            var a = new ApplicationDbContext();
             a.Database.Initialize(true);
            return a;

        }
         static ApplicationDbContext()
        {
            Database.SetInitializer(new AppDbInitializer());
        }
    }

    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем две роли
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };

            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);

            // создаем пользователей
            var admin = new ApplicationUser { Email = "administrator", UserName = "administrator" };
            string password1 = "password";
            var user = new ApplicationUser { Email = "vasya", UserName = "vasya" };
            string password2 = "123456";
            var result1 = userManager.Create(admin, password1);
            var result2= userManager.Create(user, password2);
            // если создание пользователя прошло успешно
            if (result1.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
               
            }
            if (result2.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(user.Id, role2.Name);

            }
            base.Seed(context);
            context.SaveChanges();
        }
    }
}