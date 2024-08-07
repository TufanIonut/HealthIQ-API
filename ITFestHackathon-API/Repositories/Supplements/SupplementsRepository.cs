﻿
using Dapper;
using HealthIQ.DTOs;
using HealthIQ.Interfaces;
using HealthIQ.Requests;
using HealthIQ.Responses;
using System.Data;

namespace HealthIQ.Repositories
{
    public class SupplementsRepository : ISupplementsRepository
    {

        private readonly IDbConnectionFactory _dbConnectionFactory;
        public SupplementsRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<PillsResponse>> GetPills()
        {
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var result = await connection.QueryAsync<PillsResponse>("GetPills",  commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<bool> insertMeds(MedsDTO meds)
        {
             
        var parameters = new DynamicParameters();
            parameters.Add("@IdUser", meds.IdUser);
            parameters.Add("@PillName", meds.PillName);
            parameters.Add("@TakingHour", meds.TakingHour);
            parameters.Add("@TimesPerDay", meds.TimesPerDay);
            parameters.Add("@Taken", meds.Taken);
            parameters.Add("@Success", dbType: DbType.Boolean, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("InsertMedication", parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<bool>("Success");
                return result;
            }
        }
        public async Task<IEnumerable<MedsResponse>> GetMeds()
        {
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var result = await connection.QueryAsync<MedsResponse>("GetMedication", commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<int> DeleteMeds(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdMedication", id);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("DeleteMeds", parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("Success");
                return result;
            }
        }
        public async Task<int> ToogleTaken(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdMedication", id);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("ToggleMedicationTaken", parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("Success");
                return result;
            }
        }
        public async Task<IEnumerable<ManufacturerResponse>> GetManufacturers()
        {
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var result = await connection.QueryAsync<ManufacturerResponse>("GetManufacturers", commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<int> InsertPillAsync(AddPillRequest addPillRequest)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PillName", addPillRequest.PillName);
            parameters.Add("@Manufacturer_Name", addPillRequest.Manufacturer_Name);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("InsertPill", parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("Success");
                return result;
            }
        }
    }
}
