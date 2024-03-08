using ITFestHackathon_API.Infrastructure;
using ITFestHackathon_API.Interfaces;
using ITFestHackathon_API.Repositories;

namespace ITFestHackathon_API
{
    public static class MyConfigServiceCollection
    {
        public static IServiceCollection AddMyDependencyGroup(
             this IServiceCollection services)
        {
            services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
            services.AddScoped<IRegisterUserRepository, RegisterUserRepository>();
            services.AddScoped<ILoginUserRepository, LoginUserRepository>();
            services.AddScoped<IInsertUserInformationRepository, InsertUserInformationRepository>();
            services.AddScoped<IAddIngredientAdminRepository, AddIngredientAdminRepository>();
            return services;
        }
    }
}
