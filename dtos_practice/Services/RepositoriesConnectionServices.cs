using dtos_practice.Models.Domains;
using dtos_practice.Repositories.Contracts;
using dtos_practice.Repositories.Services;

namespace dtos_practice.Services
{
    public static class RepositoriesConnectionServices
    {
        public static void RepositoryConnection(this IServiceCollection services) {
            services.AddScoped<IGenericCrud<UserModel>, UserRepository>();
        }
    }
}
