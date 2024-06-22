using dtos_practice.Data;
using Microsoft.EntityFrameworkCore;

namespace dtos_practice.Services
{
    public static class DbConnectionService
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            });

        }
    }
}
