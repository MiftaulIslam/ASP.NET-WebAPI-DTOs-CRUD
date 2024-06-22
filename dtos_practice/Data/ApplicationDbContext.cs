using dtos_practice.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace dtos_practice.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<UserModel> Users { get; set; }
    }
}
