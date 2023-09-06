using Braga;
using MySql.Data.MySqlClient;

namespace Servico1
{
    internal class OficinaDAO
    {
        //string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=fAd8qv]LYn2R3TH!;database=mydb; pooling = false; convert zero datetime=True";
        string connectionString = Conect.conn;

        public Oficina getOficinaValues()
        {
            // começamos com a criação de uma lista 
            Oficina of = new Oficina();

            // conectando com o servidor SQL
            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            // coleção de sql para reunir usuarios
            MySqlCommand command = new MySqlCommand("SELECT ID as ULTIMO_ID, VALOR_DIAG_OFICINA,VALOR_DIAG_FORA,VALOR_KM FROM OFICINA WHERE ID=(SELECT MAX(ID) FROM OFICINA)", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    of.ID = reader.GetInt32(0);
                    of.VALOR_DIAG_OFICINA = reader.GetFloat(1);
                    of.VALOR_DIAG_FORA = reader.GetFloat(2);
                    of.VALOR_KM = reader.GetFloat(3);
                }
            }
            connection.Close();

            return of;
        }

        public bool updateValues(Oficina of)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();
            MySqlCommand command = new MySqlCommand();

            command.CommandText = "UPDATE OFICINA SET VALOR_DIAG_OFICINA = @valorOf, VALOR_DIAG_FORA = @valorFora, VALOR_KM = @valorKm WHERE ID = @id";
            command.Parameters.AddWithValue("@id", of.ID);
            command.Parameters.AddWithValue("@valorOf", of.VALOR_DIAG_OFICINA);
            command.Parameters.AddWithValue("@valorFora", of.VALOR_DIAG_FORA);
            command.Parameters.AddWithValue("@valorKm", of.VALOR_KM);

            command.Connection = connection;

            int queryRetorno = 0;
            queryRetorno = command.ExecuteNonQuery();

            if (queryRetorno == 0 || queryRetorno == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
