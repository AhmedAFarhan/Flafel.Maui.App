using Flafel.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace Flafel.Infrastructure.Helpers
{
    public class InitialDatabase(ApplicationDbContext dbContext)
    {
        public async Task InitializeAsync()
        {
            try
            {                
                // Apply migrations
                await dbContext.Database.MigrateAsync();

                // Seed data if database is empty
                if (!await dbContext.SystemUsers.AnyAsync())
                {
                    var hasher = new PasswordHasher<SystemUser>();

                    var roleId = RoleId.Of(Guid.Parse("ccb0068a-211a-4b9c-ad86-b9e47c9054d4"));
                    var role = new Role()
                    {
                        Id = roleId,
                        Name = "Admin"
                    };

                    var userId = SystemUserId.Of(Guid.Parse("87d78e5f-3cdb-44a3-b88c-2a41e2079db0"));
                    var systemUser = new SystemUser()
                    {
                        Id = userId,
                        UserName = "admin",
                        PasswordHash = hasher.HashPassword(null, "010011"),
                        CrewId = null,
                    };

                    var userRole = systemUser.AddUserRole(roleId);

                    userRole.AddPermission(RolePermission.READ);


                    await dbContext.Roles.AddAsync(role);
                    await dbContext.SystemUsers.AddAsync(systemUser);

                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw; 
            }
        }
    }
}
