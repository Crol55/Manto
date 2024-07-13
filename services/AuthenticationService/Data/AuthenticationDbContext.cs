using AuthenticationService.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Data
{
    public class AuthenticationDbContext: DbContext
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> dbContextOptions)
            :base(dbContextOptions)
        { 
        
        }

        public DbSet<User> User { get; set; }
    }
}
