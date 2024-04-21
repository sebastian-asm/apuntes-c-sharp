using System.Data.SqlClient;

namespace SQL
{
    public class BeerDB : DB
    {
        public BeerDB(string server, string dbName, string user, string password) : base(server, dbName, user, password) { }

        public List<Beer> GetAll()
        {
            List<Beer> beers = new List<Beer>();
            string query = "SELECT id, name, brandId FROM Beer";

            Connect();
            SqlCommand cmd = new SqlCommand(query, _connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // los números entre () indican la posición de la columna en la db
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int brandId = reader.GetInt32(2);
                beers.Add(new Beer(id, name, brandId));
            }
            Close();
            return beers;
        }

        public Beer Get(int id)
        {
            Beer beer = null;
            string query = "SELECT id, name, brandId FROM Beer WHERE id=@id";

            Connect();
            SqlCommand cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString(1);
                int brandId = reader.GetInt32(2);
                beer = new Beer(id, name, brandId);
            }
            Close();
            return beer;
        }

        public void Add(Beer beer)
        {
            string query = "INSERT INTO Beer(name, brandId) VALUES(@name, @brandId)";
            Connect();
            SqlCommand cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@name", beer.name);
            cmd.Parameters.AddWithValue("@brandId", beer.brandId);
            // ejecutar la query sin esperar un resultado
            cmd.ExecuteNonQuery();
            Close();
        }

        public void Edit(Beer beer)
        {
            string query = "UPDATE Beer SET name=@name, brandId=@brandId WHERE id=@id";
            Connect();
            SqlCommand cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@name", beer.name);
            cmd.Parameters.AddWithValue("@brandId", beer.brandId);
            cmd.Parameters.AddWithValue("@id", beer.id);
            cmd.ExecuteNonQuery();
            Close();
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM Beer WHERE id=@id";
            Connect();
            SqlCommand cmd = new SqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Close();
        }
    }
}
