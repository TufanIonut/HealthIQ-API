using System.Data;

namespace HealthIQ.Interfaces
{
    public interface IDbConnectionFactory
    {
        public IDbConnection ConnectToDataBase();
    }
}
