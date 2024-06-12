using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserControlApi.Model;

namespace UserControlApi.Data
{
    public class UserControlDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public UserControlDbContext(DbContextOptions<UserControlDbContext> options): base(options){}
    }
}
