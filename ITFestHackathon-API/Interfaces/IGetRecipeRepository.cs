﻿using HealthIQ.DTOs;
using HealthIQ.Responses;

namespace HealthIQ.Interfaces
{
    public interface IGetRecipeRepository
    {
        Task<IEnumerable<GetRecipeResponse>> GetRecipesAsyncRepo();
        Task<IEnumerable<GetRecipeResponse>> GetRecipesForUser(int idUser);
    }
}