using ITFestHackathon_API.Infrastructure;
using ITFestHackathon_API.Interfaces;
using ITFestHackathon_API.Repositories.Ingredients;
using ITFestHackathon_API.Repositories.IngredientsType;
using ITFestHackathon_API.Repositories.Recipe;
using ITFestHackathon_API.Repositories.Disease;
using ITFestHackathon_API.Repositories.User;
using ITFestHackathon_API.Repositories.Diseases;
using ITFestHackathon_API.Repositories.Advice;

namespace ITFestHackathon_API
{
    public static class MyConfigServiceCollection
    {
        public static IServiceCollection AddMyDependencyGroup(
             this IServiceCollection services)
        {
            services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
            //--------------------------------------------------------------------
            //USER
            services.AddScoped<IRegisterUserRepository, RegisterUserRepository>();
            services.AddScoped<ILoginUserRepository, LoginUserRepository>();
            services.AddScoped<IInsertUserInformationRepository, InsertUserInformationRepository>();
            //--------------------------------------------------------------------
            //INGREDIENTS
            services.AddScoped<IAddIngredientRepository, AddIngredientRepository>();
            services.AddScoped<IGetIngredientsRepository, GetIngredientsRepository>();
            services.AddScoped<IDeleteIngredientRepository, DeleteIngredientRepository>();
            services.AddScoped<IUpdateIngredientRepository, UpdateIngredientRepository>();
            //--------------------------------------------------------------------
            //INGREDIENTS TYPE
            services.AddScoped<IDeleteIngredientTypeRepository, DeleteIngredientTypeRepository>();
            services.AddScoped<IGetIngredientTypesRepository, GetIngredientTypesRepository>();
            services.AddScoped<IAddIngredientTypeRepository, AddIngredientTypeRepository>();
            services.AddScoped<IUpdateIngredientTypeRepository, UpdateIngredientTypeRepository>();
            //--------------------------------------------------------------------
            //RECIPE
            services.AddScoped<IGetRecipeRepository, GetRecipeRepository>();
            services.AddScoped<IDeleteRecipeRepository, DeleteRecipeRepository>();
            services.AddScoped<IAddRecipeRepository, AddRecipeRepository>();
            services.AddScoped<IUpdateRecipeRepository, UpdateRecipeRepository>();
            //--------------------------------------------------------------------
            //DISEASES
            services.AddScoped<IGetDiseasesRepository, GetDiseasesRepository>();
            services.AddScoped<IDeleteDiseaseRepository, DeleteDiseaseRepository>();
            services.AddScoped<IAddDiseaseRepository, AddDiseaseRepository>();
            services.AddScoped<IUpdateDiseaseRepository, UpdateDiseaseRepository>();
            //--------------------------------------------------------------------
            //ADVICES
            services.AddScoped<IGetAdvicesRepository, GetAdvicesRepository>();







            return services;
        }
    }
}
