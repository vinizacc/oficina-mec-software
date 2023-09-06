using System.Data;
using System.Data.SqlClient;

namespace Servico1
{
    public class Conection
    {
        private SqlConnection _con;
        public SqlCommand Cmd;
        private SqlDataAdapter _da;
        private DataTable _dt;

        public Conection(string connectionstring = null)
        {
            _con = new SqlConnection(connectionstring ?? @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vinícius\source\repos\Servico1\Database1.mdf;Integrated Security=True");
            _con.Open();
        }

        public void SqlQuery(string queryText)
        {
            Cmd = new SqlCommand(queryText, _con);
        }

        public DataTable QueryEx()
        {
            _da = new SqlDataAdapter(Cmd);
            _dt = new DataTable();
            _da.Fill(_dt);
            return _dt;
        }
        public void NonQueryEx()
        {
            Cmd.ExecuteNonQuery();
        }
    }
}
