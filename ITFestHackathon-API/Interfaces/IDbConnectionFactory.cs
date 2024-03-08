using System.Data;

namespace ITFestHackathon_API.Interfaces
{
    public interface IDbConnectionFactory
    {
        public IDbConnection ConnectToDataBase();
    }
}
