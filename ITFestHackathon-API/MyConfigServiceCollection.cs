using HealthIQ.Infrastructure;
using HealthIQ.Interfaces;
using HealthIQ.Repositories.Ingredients;
using HealthIQ.Repositories.IngredientsType;
using HealthIQ.Repositories.Recipe;
using HealthIQ.Repositories.RecipeIngredients;
using HealthIQ.Repositories.Disease;
using HealthIQ.Repositories.User;
using HealthIQ.Repositories.Diseases;
using HealthIQ.Repositories.Advice;
using HealthIQ.Repositories.WaterConsumption;
using HealthIQ.Repositories.CalorieIntake;
using HealthIQ.Repositories.Exercise;
using HealthIQ.Repositories.Workout;
using HealthIQ.Services;
using HealthIQ.Repositories;

namespace HealthIQ
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
            services.AddScoped<IGetUserWeightsRepository, GetUserWeightsRepository>();
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
            services.AddScoped<IAddWaterConsumptionRepository, AddWaterConsumptionRepository>();
            //--------------------------------------------------------------------
            //CALORIE INTAKE
            services.AddScoped<IGetCalorieIntakeRepository, GetCalorieIntakeRepository>();
            //--------------------------------------------------------------------
            //EXERCISES - MUSCLES
            services.AddScoped<IGetExercisesWithMusclesRepository, GetExercisesWithMusclesRepository>();
            //--------------------------------------------------------------------
            //WORKOUT PLAN
            services.AddScoped<IGetWorkoutPlanRepository, GetWorkoutPlanRepository>();
            //--------------------------------------------------------------------
            //EMAIL
            services.AddScoped<IEmailService, EmailService>();
            //--------------------------------------------------------------------
            //GENETIC 
            services.AddScoped<IGeneticService, GeneticService>();
            //--------------------------------------------------------------------
            //Supplements
            services.AddScoped<ISupplementsRepository, SupplementsRepository>();
            return services;
        }
    }
}
