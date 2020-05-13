using ProjectManager.DataAccess.Interfaces;

namespace ProjectManager.DataAccess.Factory
{
    public class ProjectDBHandlerFactory
    {
        private string connectionString;

        public ProjectDBHandlerFactory(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IProjectDBHandler CreateDatabase()
        {
            IProjectDBHandler database = new PostgreSQLDataAccess(connectionString);
            return database;
        }
    }
}
