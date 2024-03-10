using ITFestHackathon_API.Infrastructure;
using ITFestHackathon_API.Interfaces;
using ITFestHackathon_API.Repositories.Ingredients;
using ITFestHackathon_API.Repositories.IngredientsType;
using ITFestHackathon_API.Repositories.Recipe;
using ITFestHackathon_API.Repositories.RecipeIngredients;
using ITFestHackathon_API.Repositories.Disease;
using ITFestHackathon_API.Repositories.User;
using ITFestHackathon_API.Repositories.Diseases;
using ITFestHackathon_API.Repositories.Advice;
using ITFestHackathon_API.Repositories.WaterConsumption;
using ITFestHackathon_API.Repositories.CalorieIntake;
using ITFestHackathon_API.Repositories.Exercise;
using ITFestHackathon_API.Repositories.Workout;

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
            services.AddScoped<IUpdateUserPointsRepository, UpdateUserPointsRepository>();
            services.AddScoped<IGetUserInfoRepository, GetUserInfoRepository>();
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
            //RECIPE - INGREDIENTS
            services.AddScoped<IAddRecipeWithIngredientsRepository,AddRecipeWithIngredientsRepository>();
            services.AddScoped<IDeleteRecipeWithIngredientsRepository, DeleteRecipeWithIngredientsRepository>();
            services.AddScoped<IGetRecipeIngredientsRepository, GetRecipeIngredientsRepository>();
            //--------------------------------------------------------------------
            //DISEASES
            services.AddScoped<IGetDiseasesRepository, GetDiseasesRepository>();
            services.AddScoped<IDeleteDiseaseRepository, DeleteDiseaseRepository>();
            services.AddScoped<IAddDiseaseRepository, AddDiseaseRepository>();
            services.AddScoped<IUpdateDiseaseRepository, UpdateDiseaseRepository>();
            //--------------------------------------------------------------------
            //ADVICES
            services.AddScoped<IGetAdvicesRepository, GetAdvicesRepository>();
            //--------------------------------------------------------------------
            //WATER CONSUMPTION
            services.AddScoped<IGetWaterConsumptionRepository, GetWaterConsumptionRepository>();
            services.AddScoped<IUpdateWaterConsumptionRepository, UpdateWaterConsumptionRepository>();
            //--------------------------------------------------------------------
            //CALORIE INTAKE
            services.AddScoped<IGetCalorieIntakeRepository, GetCalorieIntakeRepository>();
            //--------------------------------------------------------------------
            //EXERCISES - MUSCLES
            services.AddScoped<IGetExercisesWithMusclesRepository, GetExercisesWithMusclesRepository>();
            //--------------------------------------------------------------------
            //WORKOUT PLAN
            services.AddScoped<IGetWorkoutPlanRepository, GetWorkoutPlanRepository>();






            return services;
        }
    }
}
