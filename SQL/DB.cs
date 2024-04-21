using System.Data.SqlClient;

namespace SQL
{
    public abstract class DB
    {
        private string _connectionString;
        protected SqlConnection _connection;

        public DB(string server, string dbName, string user, string password)
        {
            _connectionString = $"Data Source={server}; Initial Catalog={dbName}; User={user}; Password={password}";
        }

        public void Connect()
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }

        public void Close()
        {
            // evitar cerrar una conexión cuando no hay una sesión abierta
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
                _connection.Close();
        }
    }
}
