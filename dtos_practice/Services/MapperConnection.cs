using dtos_practice.Mappers;

namespace dtos_practice.Services
{
    public static class MapperConnection
    {
        public static void ServerMapperConnection(this IServiceCollection services)
        {
            services.AddSingleton<UserMapper>();
        }
    }
}
