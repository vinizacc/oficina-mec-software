using Braga;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace Servico1
{
    internal class ServicosDAO
    {
        //string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=fAd8qv]LYn2R3TH!;database=mydb; pooling = false; convert zero datetime=True";
        string connectionString = Conect.conn;
        public List<JObject> getAllServicosNaoPago()
        {
            List<JObject> retornar = new List<JObject>();

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();
            // puxar o num_nota
            string query = "SELECT ordem_servico.ID_N_SERVICO, pessoa_fisica.NOME, ordem_servico.TIPO_PAG, ordem_servico.VALOR_PAGO, ordem_servico.VALOR_TOTAL, ordem_servico.DATA, ordem_servico.NUM_NOTA FROM ordem_servico INNER JOIN pessoa_fisica ON pessoa_fisica.ID_PF = ordem_servico.ID_CLIENTE WHERE ordem_servico.PAGO = 0 AND (EXCLUIDO != 1 OR EXCLUIDO is null) ORDER BY pessoa_fisica.NOME ASC, ordem_servico.DATA DESC";

            MySqlCommand command = new MySqlCommand(query, connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    JObject novaLinha = new JObject();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        //reader.GetName(i).ToString(), reader.GetValue(i).ToString()
                        if (reader.GetName(i).ToString() == "DATA")
                        {
                            var data = DateTime.ParseExact(reader.GetValue(i).ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            var dataC = data.ToString("dd/MM/yyyy");

                            novaLinha.Add(reader.GetName(i).ToString(), dataC);
                        }
                        else if (reader.GetName(i).ToString() == "TIPO_PAG")
                        {
                            string tipo = reader.GetValue(i).ToString();
                            if (tipo == "0") { novaLinha.Add(reader.GetName(i).ToString(), "Dinheiro"); }
                            else if (tipo == "1") { novaLinha.Add(reader.GetName(i).ToString(), "Débito"); }
                            else if (tipo == "2") { novaLinha.Add(reader.GetName(i).ToString(), "Crédito"); }
                        }
                        else
                        {
                            novaLinha.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                        }
                    }

                    retornar.Add(novaLinha);
                }
            }

            connection.Close();

            return retornar;
        }
        public List<JObject> getAllServicos()
        {
            List<JObject> retornar = new List<JObject>();

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();
            // puxar o num_nota
            string query = "SELECT ordem_servico.ID_N_SERVICO, pessoa_fisica.NOME, ordem_servico.TIPO_PAG, ordem_servico.VALOR_PAGO, ordem_servico.VALOR_TOTAL, ordem_servico.DATA, ordem_servico.NUM_NOTA FROM ordem_servico INNER JOIN pessoa_fisica ON pessoa_fisica.ID_PF = ordem_servico.ID_CLIENTE WHERE EXCLUIDO != 1 OR EXCLUIDO is null ORDER BY pessoa_fisica.NOME ASC, ordem_servico.DATA DESC";
            MySqlCommand command = new MySqlCommand(query, connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    JObject novaLinha = new JObject();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        //reader.GetName(i).ToString(), reader.GetValue(i).ToString()
                        if (reader.GetName(i).ToString() == "DATA")
                        {
                            var data = DateTime.ParseExact(reader.GetValue(i).ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            var dataC = data.ToString("dd/MM/yyyy");

                            novaLinha.Add(reader.GetName(i).ToString(), dataC);
                        }
                        else if (reader.GetName(i).ToString() == "TIPO_PAG")
                        {
                            string tipo = reader.GetValue(i).ToString();
                            if (tipo == "0") { novaLinha.Add(reader.GetName(i).ToString(), "Dinheiro"); }
                            else if (tipo == "1") { novaLinha.Add(reader.GetName(i).ToString(), "Débito"); }
                            else if (tipo == "2") { novaLinha.Add(reader.GetName(i).ToString(), "Crédito"); }
                        }
                        else
                        {
                            novaLinha.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                        }
                    }

                    retornar.Add(novaLinha);
                }
            }

            connection.Close();

            return retornar;
        }
        public List<JObject> getServicosByIdNaoAtivos(int id)
        {
            try
            {
                List<JObject> lista = new List<JObject>();

                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                MySqlCommand command = new MySqlCommand();

                command.CommandText = "SELECT pessoa_fisica.NOME, ordem_servico.VALOR_PAGO, " +
                                       "ordem_servico.VALOR_TOTAL, ordem_servico.NUM_NOTA, " +
                                       "ordem_servico.DATA, " +
                                       "ordem_servico.ID_N_SERVICO " +
                                       "FROM ordem_servico " +
                                       "INNER JOIN pessoa_fisica " +
                                       "ON pessoa_fisica.ID_PF = ordem_servico.ID_CLIENTE " +
                                       "WHERE ID_CLIENTE = @searchTerm AND EXCLUIDO = 1";
                command.Parameters.AddWithValue("@searchTerm", id);
                command.Connection = connection;

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        JObject novaLinha = new JObject();

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            if (reader.GetName(i).ToString() == "EXCLUIDO")
                            {
                                string verificador = reader.GetValue(i).ToString();
                                if (verificador == "True")
                                {
                                    novaLinha.Add(reader.GetName(i).ToString(), "Sim");
                                }
                                else
                                {
                                    novaLinha.Add(reader.GetName(i).ToString(), "Não");
                                }
                            }
                            else
                            {
                                novaLinha.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());

                            }
                        }

                        lista.Add(novaLinha);
                    }
                }

                connection.Close();

                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("O cliente não tem notas para busca.");
            }
            List<JObject> listaVazia = new List<JObject>();
            return listaVazia;
        }
        public List<JObject> getServicosByIdAtivos(int id)
        {
            try
            {
                List<JObject> lista = new List<JObject>();

                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                MySqlCommand command = new MySqlCommand();

                command.CommandText = "SELECT pessoa_fisica.NOME, ordem_servico.VALOR_PAGO, " +
                                       "ordem_servico.VALOR_TOTAL, ordem_servico.NUM_NOTA, " +
                                       "ordem_servico.DATA, " +
                                       "ordem_servico.ID_N_SERVICO " +
                                       "FROM ordem_servico " +
                                       "INNER JOIN pessoa_fisica " +
                                       "ON pessoa_fisica.ID_PF = ordem_servico.ID_CLIENTE " +
                                       "WHERE ID_CLIENTE = @searchTerm AND (EXCLUIDO != 1 OR EXCLUIDO is null)";
                command.Parameters.AddWithValue("@searchTerm", id);
                command.Connection = connection;

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        JObject novaLinha = new JObject();

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            novaLinha.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                        }

                        lista.Add(novaLinha);
                    }
                }

                connection.Close();

                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("O cliente não tem notas para busca.");
            }
            List<JObject> listaVazia = new List<JObject>();
            return listaVazia;
        }
        public bool reativarNota(string id) 
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "UPDATE ordem_servico SET EXCLUIDO = 0 WHERE ID_N_SERVICO = @searchTerm";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@searchTerm", id);
            int resultCommand = command.ExecuteNonQuery();
            
            if ( resultCommand != 1)
            {
                return false;
            }
            else
            {
                return true;
            }

            connection.Close();
            
            return false;
        }
        public List<JObject> getServicoByNameNaoPago(string name)
        {
            List<JObject> retornar = new List<JObject>();

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            string searchterm = name + "%";

            string query = "SELECT ordem_servico.ID_N_SERVICO, pessoa_fisica.NOME, ordem_servico.TIPO_PAG, ordem_servico.VALOR_PAGO, ordem_servico.VALOR_TOTAL, ordem_servico.DATA, ordem_servico.NUM_NOTA FROM ordem_servico INNER JOIN pessoa_fisica ON pessoa_fisica.ID_PF = ordem_servico.ID_CLIENTE WHERE pessoa_fisica.NOME LIKE @searchterm AND ordem_servico.PAGO = 0 AND (EXCLUIDO != 1 OR EXCLUIDO is null)";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@searchterm", searchterm);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    JObject novaLinha = new JObject();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        //reader.GetName(i).ToString(), reader.GetValue(i).ToString()
                        if (reader.GetName(i).ToString() == "DATA")
                        {
                            var data = DateTime.ParseExact(reader.GetValue(i).ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            var dataC = data.ToString("dd/MM/yyyy");

                            novaLinha.Add(reader.GetName(i).ToString(), dataC);
                        }
                        else if (reader.GetName(i).ToString() == "TIPO_PAG")
                        {
                            string tipo = reader.GetValue(i).ToString();
                            if (tipo == "0") { novaLinha.Add(reader.GetName(i).ToString(), "Dinheiro"); }
                            else if (tipo == "1") { novaLinha.Add(reader.GetName(i).ToString(), "Débito"); }
                            else if (tipo == "2") { novaLinha.Add(reader.GetName(i).ToString(), "Crédito"); }
                        }
                        else
                        {
                            novaLinha.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                        }
                    }

                    retornar.Add(novaLinha);
                }
            }

            connection.Close();

            return retornar;
        }

        public List<JObject> getServicoByName(string name)
        {
            List<JObject> retornar = new List<JObject>();

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            string searchterm = name + "%";

            string query = "SELECT ordem_servico.ID_N_SERVICO, pessoa_fisica.NOME, ordem_servico.TIPO_PAG, ordem_servico.VALOR_PAGO, ordem_servico.VALOR_TOTAL, ordem_servico.DATA, ordem_servico.NUM_NOTA FROM ordem_servico INNER JOIN pessoa_fisica ON pessoa_fisica.ID_PF = ordem_servico.ID_CLIENTE WHERE pessoa_fisica.NOME LIKE @searchterm AND (EXCLUIDO != 1 OR EXCLUIDO is null)";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@searchterm", searchterm);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    JObject novaLinha = new JObject();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        //reader.GetName(i).ToString(), reader.GetValue(i).ToString()
                        if (reader.GetName(i).ToString() == "DATA")
                        {
                            var data = DateTime.ParseExact(reader.GetValue(i).ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            var dataC = data.ToString("dd/MM/yyyy");

                            novaLinha.Add(reader.GetName(i).ToString(), dataC);
                        }
                        else if (reader.GetName(i).ToString() == "TIPO_PAG")
                        {
                            string tipo = reader.GetValue(i).ToString();
                            if (tipo == "0") { novaLinha.Add(reader.GetName(i).ToString(), "Dinheiro"); }
                            else if (tipo == "1") { novaLinha.Add(reader.GetName(i).ToString(), "Débito"); }
                            else if (tipo == "2") { novaLinha.Add(reader.GetName(i).ToString(), "Crédito"); }
                        }
                        else
                        {
                            novaLinha.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                        }
                    }

                    retornar.Add(novaLinha);
                }
            }

            connection.Close();

            return retornar;
        }

        public List<JObject> getServicosByDatesNaoPago(List<DateTime> listaDatas)
        {
            List<JObject> retornar = new List<JObject>();

            DateTime hoje = DateTime.Now;

            if (listaDatas[0] <= listaDatas[1] && hoje >= listaDatas[1])
            {
                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();

                MySqlCommand command = new MySqlCommand();

                string dataI = listaDatas[0].Day.ToString();
                dataI += "," + listaDatas[0].Month.ToString();
                dataI += "," + listaDatas[0].Year.ToString();

                string dataF = listaDatas[1].Day.ToString();
                dataF += "," + listaDatas[1].Month.ToString();
                dataF += "," + listaDatas[1].Year.ToString();

                command.CommandText = "SELECT ordem_servico.ID_N_SERVICO, pessoa_fisica.NOME, ordem_servico.TIPO_PAG, ordem_servico.VALOR_PAGO, ordem_servico.VALOR_TOTAL, ordem_servico.DATA, ordem_servico.NUM_NOTA FROM ordem_servico INNER JOIN pessoa_fisica ON pessoa_fisica.ID_PF = ordem_servico.ID_CLIENTE WHERE DATE(ordem_servico.DATA) BETWEEN STR_TO_DATE(@datainicial,'%d,%m,%Y') and STR_TO_DATE(@datafinal,'%d,%m,%Y') AND ordem_servico.PAGO = 0 AND (EXCLUIDO != 1 OR EXCLUIDO is null) ORDER BY ordem_servico.DATA DESC";
                command.Parameters.AddWithValue("@datainicial", dataI);
                command.Parameters.AddWithValue("@datafinal", dataF);

                command.Connection = connection;

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        JObject novaLinha = new JObject();

                        for (int i = 0; i < reader.FieldCount; i++)
                        {

                            //reader.GetName(i).ToString(), reader.GetValue(i).ToString()
                            if (reader.GetName(i).ToString() == "DATA")
                            {
                                var data = DateTime.ParseExact(reader.GetValue(i).ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                                var dataC = data.ToString("dd/MM/yyyy");

                                novaLinha.Add(reader.GetName(i).ToString(), dataC);
                            }
                            else if (reader.GetName(i).ToString() == "TIPO_PAG")
                            {
                                string tipo = reader.GetValue(i).ToString();
                                if (tipo == "0") { novaLinha.Add(reader.GetName(i).ToString(), "Dinheiro"); }
                                else if (tipo == "1") { novaLinha.Add(reader.GetName(i).ToString(), "Débito"); }
                                else if (tipo == "2") { novaLinha.Add(reader.GetName(i).ToString(), "Crédito"); }
                            }
                            else
                            {
                                novaLinha.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                            }
                        }

                        retornar.Add(novaLinha);
                    }
                }
                connection.Close();
            }

            return retornar;
        }


        public List<JObject> getServicosByDates(List<DateTime> listaDatas)
        {
            List<JObject> retornar = new List<JObject>();

            DateTime hoje = DateTime.Now;

            if (listaDatas[0] <= listaDatas[1] && hoje >= listaDatas[1])
            {
                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();

                MySqlCommand command = new MySqlCommand();

                string dataI = listaDatas[0].Day.ToString();
                dataI += "," + listaDatas[0].Month.ToString();
                dataI += "," + listaDatas[0].Year.ToString();

                string dataF = listaDatas[1].Day.ToString();
                dataF += "," + listaDatas[1].Month.ToString();
                dataF += "," + listaDatas[1].Year.ToString();

                command.CommandText = "SELECT ordem_servico.ID_N_SERVICO, pessoa_fisica.NOME, ordem_servico.TIPO_PAG, ordem_servico.VALOR_PAGO, ordem_servico.VALOR_TOTAL, ordem_servico.DATA, ordem_servico.NUM_NOTA FROM ordem_servico INNER JOIN pessoa_fisica ON pessoa_fisica.ID_PF = ordem_servico.ID_CLIENTE WHERE DATE(ordem_servico.DATA) BETWEEN STR_TO_DATE(@datainicial,'%d,%m,%Y') and STR_TO_DATE(@datafinal,'%d,%m,%Y') ORDER BY ordem_servico.DATA DESC";
                command.Parameters.AddWithValue("@datainicial", dataI);
                command.Parameters.AddWithValue("@datafinal", dataF);

                command.Connection = connection;

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        JObject novaLinha = new JObject();

                        for (int i = 0; i < reader.FieldCount; i++)
                        {

                            //reader.GetName(i).ToString(), reader.GetValue(i).ToString()
                            if (reader.GetName(i).ToString() == "DATA")
                            {
                                var data = DateTime.ParseExact(reader.GetValue(i).ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                                var dataC = data.ToString("dd/MM/yyyy");

                                novaLinha.Add(reader.GetName(i).ToString(), dataC);
                            }
                            else if (reader.GetName(i).ToString() == "TIPO_PAG")
                            {
                                string tipo = reader.GetValue(i).ToString();
                                if (tipo == "0") { novaLinha.Add(reader.GetName(i).ToString(), "Dinheiro"); }
                                else if (tipo == "1") { novaLinha.Add(reader.GetName(i).ToString(), "Débito"); }
                                else if (tipo == "2") { novaLinha.Add(reader.GetName(i).ToString(), "Crédito"); }
                            }
                            else
                            {
                                novaLinha.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                            }
                        }

                        retornar.Add(novaLinha);
                    }
                }
                connection.Close();
            }

            return retornar;
        }


        public List<JObject> getServicosByExactDatesNaoPago(DateTime dataAnterior, DateTime dataAtual)
        {
            List<JObject> retornar = new List<JObject>();

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            MySqlCommand command = new MySqlCommand();

            command.CommandText = "SELECT ordem_servico.ID_N_SERVICO, pessoa_fisica.NOME, " +
                                        "ordem_servico.TIPO_PAG, ordem_servico.VALOR_PAGO, " +
                                        "ordem_servico.VALOR_TOTAL, ordem_servico.DATA, " +
                                        "ordem_servico.NUM_NOTA " +
                                "FROM ordem_servico INNER JOIN pessoa_fisica ON pessoa_fisica.ID_PF = ordem_servico.ID_CLIENTE " +
                                "WHERE DATE (ordem_servico.DATA)=@dataAtual AND ordem_servico.PAGO = 0 AND (EXCLUIDO != 1 OR EXCLUIDO is null)" +
                                "ORDER BY ordem_servico.DATA DESC";

            command.Parameters.AddWithValue("@dataAtual", dataAtual);

            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    JObject novaLinha = new JObject();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {

                        //reader.GetName(i).ToString(), reader.GetValue(i).ToString()
                        if (reader.GetName(i).ToString() == "DATA")
                        {
                            var data = DateTime.ParseExact(reader.GetValue(i).ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            var dataC = data.ToString("dd/MM/yyyy");

                            novaLinha.Add(reader.GetName(i).ToString(), dataC);
                        }
                        else if (reader.GetName(i).ToString() == "TIPO_PAG")
                        {
                            string tipo = reader.GetValue(i).ToString();
                            if (tipo == "0") { novaLinha.Add(reader.GetName(i).ToString(), "Dinheiro"); }
                            else if (tipo == "1") { novaLinha.Add(reader.GetName(i).ToString(), "Débito"); }
                            else if (tipo == "2") { novaLinha.Add(reader.GetName(i).ToString(), "Crédito"); }
                        }
                        else
                        {
                            novaLinha.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                        }
                    }

                    retornar.Add(novaLinha);
                }
            }

            connection.Close();


            MySqlConnection connection1 = new MySqlConnection(connectionString);

            connection1.Open();

            MySqlCommand command1 = new MySqlCommand();

            command1.CommandText = "SELECT ordem_servico.ID_N_SERVICO, pessoa_fisica.NOME, " +
                                        "ordem_servico.TIPO_PAG, ordem_servico.VALOR_PAGO, " +
                                        "ordem_servico.VALOR_TOTAL, ordem_servico.DATA, " +
                                        "ordem_servico.NUM_NOTA " +
                                "FROM ordem_servico INNER JOIN pessoa_fisica ON pessoa_fisica.ID_PF = ordem_servico.ID_CLIENTE " +
                                "WHERE DATE (ordem_servico.DATA) = @dataAnterior AND ordem_servico.PAGO = 0 " +
                                "ORDER BY ordem_servico.DATA DESC";

            command1.Parameters.AddWithValue("@dataAnterior", dataAnterior);

            command1.Connection = connection1;

            using (MySqlDataReader reader = command1.ExecuteReader())
            {
                while (reader.Read())
                {
                    JObject novaLinha = new JObject();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {

                        //reader.GetName(i).ToString(), reader.GetValue(i).ToString()
                        if (reader.GetName(i).ToString() == "DATA")
                        {
                            var data = DateTime.ParseExact(reader.GetValue(i).ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            var dataC = data.ToString("dd/MM/yyyy");

                            novaLinha.Add(reader.GetName(i).ToString(), dataC);
                        }
                        else if (reader.GetName(i).ToString() == "TIPO_PAG")
                        {
                            string tipo = reader.GetValue(i).ToString();
                            if (tipo == "0") { novaLinha.Add(reader.GetName(i).ToString(), "Dinheiro"); }
                            else if (tipo == "1") { novaLinha.Add(reader.GetName(i).ToString(), "Débito"); }
                            else if (tipo == "2") { novaLinha.Add(reader.GetName(i).ToString(), "Crédito"); }
                        }
                        else
                        {
                            novaLinha.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                        }
                    }

                    retornar.Add(novaLinha);
                }
            }


            return retornar;
        }


        public List<JObject> getServicosByExactDates(DateTime dataAnterior, DateTime dataAtual)
        {
            List<JObject> retornar = new List<JObject>();

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            MySqlCommand command = new MySqlCommand();

            command.CommandText = "SELECT ordem_servico.ID_N_SERVICO, pessoa_fisica.NOME, " +
                                        "ordem_servico.TIPO_PAG, ordem_servico.VALOR_PAGO, " +
                                        "ordem_servico.VALOR_TOTAL, ordem_servico.DATA, " +
                                        "ordem_servico.NUM_NOTA " +
                                "FROM ordem_servico INNER JOIN pessoa_fisica ON pessoa_fisica.ID_PF = ordem_servico.ID_CLIENTE " +
                                "WHERE DATE (ordem_servico.DATA) = @dataAtual " +
                                "ORDER BY ordem_servico.DATA DESC";

            command.Parameters.AddWithValue("@dataAtual", dataAtual);

            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    JObject novaLinha = new JObject();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {

                        //reader.GetName(i).ToString(), reader.GetValue(i).ToString()
                        if (reader.GetName(i).ToString() == "DATA")
                        {
                            var data = DateTime.ParseExact(reader.GetValue(i).ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            var dataC = data.ToString("dd/MM/yyyy");

                            novaLinha.Add(reader.GetName(i).ToString(), dataC);
                        }
                        else if (reader.GetName(i).ToString() == "TIPO_PAG")
                        {
                            string tipo = reader.GetValue(i).ToString();
                            if (tipo == "0") { novaLinha.Add(reader.GetName(i).ToString(), "Dinheiro"); }
                            else if (tipo == "1") { novaLinha.Add(reader.GetName(i).ToString(), "Débito"); }
                            else if (tipo == "2") { novaLinha.Add(reader.GetName(i).ToString(), "Crédito"); }
                        }
                        else
                        {
                            novaLinha.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                        }
                    }

                    retornar.Add(novaLinha);
                }
            }

            connection.Close();


            MySqlConnection connection1 = new MySqlConnection(connectionString);

            connection1.Open();

            MySqlCommand command1 = new MySqlCommand();

            command1.CommandText = "SELECT ordem_servico.ID_N_SERVICO, pessoa_fisica.NOME, " +
                                        "ordem_servico.TIPO_PAG, ordem_servico.VALOR_PAGO, " +
                                        "ordem_servico.VALOR_TOTAL, ordem_servico.DATA, " +
                                        "ordem_servico.NUM_NOTA " +
                                "FROM ordem_servico INNER JOIN pessoa_fisica ON pessoa_fisica.ID_PF = ordem_servico.ID_CLIENTE " +
                                "WHERE DATE (ordem_servico.DATA) = @dataAnterior " +
                                "ORDER BY ordem_servico.DATA DESC";

            command1.Parameters.AddWithValue("@dataAnterior", dataAnterior);

            command1.Connection = connection1;

            using (MySqlDataReader reader = command1.ExecuteReader())
            {
                while (reader.Read())
                {
                    JObject novaLinha = new JObject();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {

                        //reader.GetName(i).ToString(), reader.GetValue(i).ToString()
                        if (reader.GetName(i).ToString() == "DATA")
                        {
                            var data = DateTime.ParseExact(reader.GetValue(i).ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            var dataC = data.ToString("dd/MM/yyyy");

                            novaLinha.Add(reader.GetName(i).ToString(), dataC);
                        }
                        else if (reader.GetName(i).ToString() == "TIPO_PAG")
                        {
                            string tipo = reader.GetValue(i).ToString();
                            if (tipo == "0") { novaLinha.Add(reader.GetName(i).ToString(), "Dinheiro"); }
                            else if (tipo == "1") { novaLinha.Add(reader.GetName(i).ToString(), "Débito"); }
                            else if (tipo == "2") { novaLinha.Add(reader.GetName(i).ToString(), "Crédito"); }
                        }
                        else
                        {
                            novaLinha.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                        }
                    }

                    retornar.Add(novaLinha);
                }
            }


            return retornar;
        }

        public DataTable getListaByDates(string dataInicial, string dataFinal, string tipoPag, string statusPag)
        {
            int intTipoPag;
            if (tipoPag == "Débito") { intTipoPag = 1; }
            else if (tipoPag == "Crédito") { intTipoPag = 2; }
            else if (tipoPag == "Dinheiro") { intTipoPag = 0; }
            else { intTipoPag = -1; } //  Qualquer tipo de pagamento.

            int intStatus;
            if (statusPag == "Pago") { intStatus = 1; }
            else if (statusPag == "Não pago") { intStatus = 0; }
            else { intStatus = -1; } // Qualquer status de pagamento.
            string textoComando;

            if (intTipoPag == -1 && intStatus == -1) //Nada varia 
            {
                textoComando = "SELECT ordem_servico.DATA, ordem_servico.VALOR_PAGO, ordem_servico.VALOR_TOTAL, ordem_servico.TIPO_PAG, ordem_servico.PAGO, pessoa_fisica.NOME FROM ordem_servico INNER JOIN pessoa_fisica ON ordem_servico.ID_CLIENTE = pessoa_fisica.ID_PF WHERE ordem_servico.DATA BETWEEN STR_TO_DATE(@dataInicial, '%Y-%m-%d') and STR_TO_DATE(@dataFinal,'%Y-%m-%d') AND (EXCLUIDO != 1 OR EXCLUIDO is null) order by pessoa_fisica.NOME ASC";
            }
            else if (intTipoPag == -1) //  Status varia
            {
                textoComando = "SELECT ordem_servico.DATA, ordem_servico.VALOR_PAGO, ordem_servico.VALOR_TOTAL, ordem_servico.TIPO_PAG, ordem_servico.PAGO, pessoa_fisica.NOME FROM ordem_servico INNER JOIN pessoa_fisica ON ordem_servico.ID_CLIENTE = pessoa_fisica.ID_PF WHERE ordem_servico.DATA BETWEEN STR_TO_DATE(@dataInicial, '%Y-%m-%d') and STR_TO_DATE(@dataFinal,'%Y-%m-%d') AND ordem_servico.PAGO = @intStatus AND (EXCLUIDO != 1 OR EXCLUIDO is null) order by pessoa_fisica.NOME ASC";
            }
            else if (intStatus == -1) // Tipo pag varia 
            {
                textoComando = "SELECT ordem_servico.DATA, ordem_servico.VALOR_PAGO, ordem_servico.VALOR_TOTAL, ordem_servico.TIPO_PAG, ordem_servico.PAGO, pessoa_fisica.NOME FROM ordem_servico INNER JOIN pessoa_fisica ON ordem_servico.ID_CLIENTE = pessoa_fisica.ID_PF WHERE ordem_servico.DATA BETWEEN STR_TO_DATE(@dataInicial, '%Y-%m-%d') and STR_TO_DATE(@dataFinal,'%Y-%m-%d') AND ordem_servico.TIPO_PAG = @intTipoPag AND (EXCLUIDO != 1 OR EXCLUIDO is null) order by pessoa_fisica.NOME ASC";
            }
            else //Os dois variam 
            {
                textoComando = "SELECT ordem_servico.DATA, ordem_servico.VALOR_PAGO, ordem_servico.VALOR_TOTAL, ordem_servico.TIPO_PAG, ordem_servico.PAGO, pessoa_fisica.NOME FROM ordem_servico INNER JOIN pessoa_fisica ON ordem_servico.ID_CLIENTE = pessoa_fisica.ID_PF WHERE ordem_servico.DATA BETWEEN STR_TO_DATE(@dataInicial, '%Y-%m-%d') and STR_TO_DATE(@dataFinal,'%Y-%m-%d') AND ordem_servico.TIPO_PAG = @intTipoPag AND ordem_servico.PAGO = @intStatus AND (EXCLUIDO != 1 OR EXCLUIDO is null) order by pessoa_fisica.NOME ASC";
            }

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            MySqlCommand command = new MySqlCommand();

            command.CommandText = textoComando;
            command.Parameters.AddWithValue("@dataInicial", dataInicial);
            command.Parameters.AddWithValue("@dataFinal", dataFinal);
            command.Parameters.AddWithValue("@intTipoPag", intTipoPag);
            command.Parameters.AddWithValue("@intStatus", intStatus);

            command.Connection = connection;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            return dt;
        }


        public List<JObject> getServicosByPaymentTypeNaoPago(int selectedIndex)
        {
            List<JObject> retornar = new List<JObject>();

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            string query = "SELECT ordem_servico.ID_N_SERVICO, pessoa_fisica.NOME, ordem_servico.TIPO_PAG, ordem_servico.VALOR_PAGO, ordem_servico.VALOR_TOTAL, ordem_servico.DATA, ordem_servico.NUM_NOTA  FROM ordem_servico INNER JOIN pessoa_fisica ON pessoa_fisica.ID_PF = ordem_servico.ID_CLIENTE WHERE ordem_servico.TIPO_PAG = @searchterm AND ordem_servico.PAGO = 0 AND (EXCLUIDO != 1 OR EXCLUIDO is null)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@searchterm", selectedIndex);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    JObject novaLinha = new JObject();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        //reader.GetName(i).ToString(), reader.GetValue(i).ToString()
                        if (reader.GetName(i).ToString() == "DATA")
                        {
                            var data = DateTime.ParseExact(reader.GetValue(i).ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            var dataC = data.ToString("dd/MM/yyyy");

                            novaLinha.Add(reader.GetName(i).ToString(), dataC);
                        }
                        else if (reader.GetName(i).ToString() == "TIPO_PAG")
                        {
                            string tipo = reader.GetValue(i).ToString();
                            if (tipo == "0") { novaLinha.Add(reader.GetName(i).ToString(), "Dinheiro"); }
                            else if (tipo == "1") { novaLinha.Add(reader.GetName(i).ToString(), "Débito"); }
                            else if (tipo == "2") { novaLinha.Add(reader.GetName(i).ToString(), "Crédito"); }
                        }
                        else
                        {
                            novaLinha.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                        }
                    }

                    retornar.Add(novaLinha);
                }
            }

            connection.Close();

            return retornar;

            throw new NotImplementedException();
        }


        public List<JObject> getServicosByPaymentType(int selectedIndex)
        {
            List<JObject> retornar = new List<JObject>();

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            string query = "SELECT ordem_servico.ID_N_SERVICO, pessoa_fisica.NOME, ordem_servico.TIPO_PAG, ordem_servico.VALOR_PAGO, ordem_servico.VALOR_TOTAL, ordem_servico.DATA, ordem_servico.NUM_NOTA  FROM ordem_servico INNER JOIN pessoa_fisica ON pessoa_fisica.ID_PF = ordem_servico.ID_CLIENTE WHERE ordem_servico.TIPO_PAG = @searchterm AND (EXCLUIDO != 1 OR EXCLUIDO is null)";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@searchterm", selectedIndex);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    JObject novaLinha = new JObject();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        //reader.GetName(i).ToString(), reader.GetValue(i).ToString()
                        if (reader.GetName(i).ToString() == "DATA")
                        {
                            var data = DateTime.ParseExact(reader.GetValue(i).ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            var dataC = data.ToString("dd/MM/yyyy");

                            novaLinha.Add(reader.GetName(i).ToString(), dataC);
                        }
                        else if (reader.GetName(i).ToString() == "TIPO_PAG")
                        {
                            string tipo = reader.GetValue(i).ToString();
                            if (tipo == "0") { novaLinha.Add(reader.GetName(i).ToString(), "Dinheiro"); }
                            else if (tipo == "1") { novaLinha.Add(reader.GetName(i).ToString(), "Débito"); }
                            else if (tipo == "2") { novaLinha.Add(reader.GetName(i).ToString(), "Crédito"); }
                        }
                        else
                        {
                            novaLinha.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                        }
                    }

                    retornar.Add(novaLinha);
                }
            }

            connection.Close();

            return retornar;

            throw new NotImplementedException();
        }


        public List<JObject> getServicosByNameAndPaymentTypeNaoPago(string name, int selectedIndex)
        {
            List<JObject> retornar = new List<JObject>();

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            name = name + "%";

            string query = "SELECT ordem_servico.ID_N_SERVICO, pessoa_fisica.NOME, ordem_servico.TIPO_PAG, ordem_servico.VALOR_PAGO, ordem_servico.VALOR_TOTAL, ordem_servico.DATA, ordem_servico.NUM_NOTA FROM ordem_servico INNER JOIN pessoa_fisica ON pessoa_fisica.ID_PF = ordem_servico.ID_CLIENTE WHERE pessoa_fisica.NOME LIKE @searchName AND ordem_servico.TIPO_PAG = @searchIndex AND ordem_servico.PAGO = 0 AND (EXCLUIDO != 1 OR EXCLUIDO is null)";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@searchName", name);
            command.Parameters.AddWithValue("@searchIndex", selectedIndex);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    JObject novaLinha = new JObject();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        //reader.GetName(i).ToString(), reader.GetValue(i).ToString()
                        if (reader.GetName(i).ToString() == "DATA")
                        {
                            var data = DateTime.ParseExact(reader.GetValue(i).ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            var dataC = data.ToString("dd/MM/yyyy");

                            novaLinha.Add(reader.GetName(i).ToString(), dataC);
                        }
                        else if (reader.GetName(i).ToString() == "TIPO_PAG")
                        {
                            string tipo = reader.GetValue(i).ToString();
                            if (tipo == "0") { novaLinha.Add(reader.GetName(i).ToString(), "Dinheiro"); }
                            else if (tipo == "1") { novaLinha.Add(reader.GetName(i).ToString(), "Débito"); }
                            else if (tipo == "2") { novaLinha.Add(reader.GetName(i).ToString(), "Crédito"); }
                        }
                        else
                        {
                            novaLinha.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                        }
                    }

                    retornar.Add(novaLinha);
                }
            }

            connection.Close();

            return retornar;
            throw new NotImplementedException();
        }


        public List<JObject> getServicosByNameAndPaymentType(string name, int selectedIndex)
        {
            List<JObject> retornar = new List<JObject>();

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            name = name + "%";

            string query = "SELECT ordem_servico.ID_N_SERVICO, pessoa_fisica.NOME, ordem_servico.TIPO_PAG, ordem_servico.VALOR_PAGO, ordem_servico.VALOR_TOTAL, ordem_servico.DATA, ordem_servico.NUM_NOTA FROM ordem_servico INNER JOIN pessoa_fisica ON pessoa_fisica.ID_PF = ordem_servico.ID_CLIENTE WHERE pessoa_fisica.NOME LIKE @searchName AND ordem_servico.TIPO_PAG = @searchIndex AND (EXCLUIDO != 1 OR EXCLUIDO is null)";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@searchName", name);
            command.Parameters.AddWithValue("@searchIndex", selectedIndex);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    JObject novaLinha = new JObject();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        //reader.GetName(i).ToString(), reader.GetValue(i).ToString()
                        if (reader.GetName(i).ToString() == "DATA")
                        {
                            var data = DateTime.ParseExact(reader.GetValue(i).ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            var dataC = data.ToString("dd/MM/yyyy");

                            novaLinha.Add(reader.GetName(i).ToString(), dataC);
                        }
                        else if (reader.GetName(i).ToString() == "TIPO_PAG")
                        {
                            string tipo = reader.GetValue(i).ToString();
                            if (tipo == "0") { novaLinha.Add(reader.GetName(i).ToString(), "Dinheiro"); }
                            else if (tipo == "1") { novaLinha.Add(reader.GetName(i).ToString(), "Débito"); }
                            else if (tipo == "2") { novaLinha.Add(reader.GetName(i).ToString(), "Crédito"); }
                        }
                        else
                        {
                            novaLinha.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                        }
                    }

                    retornar.Add(novaLinha);
                }
            }

            connection.Close();

            return retornar;
            throw new NotImplementedException();
        }


        public List<JObject> changeStatusPagou(int id_linha)
        {
            //UPDATE ordem_servico SET PAGO = 1 WHERE ID_N_SERVICO =

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "UPDATE ordem_servico SET PAGO = 1 WHERE ID_N_SERVICO = @searchTerm";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@searchTerm", id_linha);
            command.ExecuteNonQuery();
            connection.Close();

            connection.Open();
            query = "UPDATE ordem_servico SET VALOR_PAGO = (SELECT VALOR_TOTAL FROM ordem_servico WHERE ID_N_SERVICO = @searchTerm) WHERE ID_N_SERVICO = @searchTerm";
            MySqlCommand command1 = new MySqlCommand(query, connection);
            command1.Parameters.AddWithValue("@searchTerm", id_linha);
            command1.ExecuteNonQuery();
            connection.Close();

            return getAllServicosNaoPago();
        }

        public void testeInsert(List<string[,]> listaDados)
        {
            JArray jsonArray = new JArray();
            foreach (string[,] linha in listaDados)
            {
                JArray innerArray = new JArray();
                for (int i = 0; i < linha.GetLength(0); i++)
                {
                    JArray innerInnerArray = new JArray();
                    for (int jo = 0; jo < linha.GetLength(1); jo++)
                    {
                        innerInnerArray.Add(linha[i, jo]);
                    }
                    innerArray.Add(innerInnerArray);
                }
                jsonArray.Add(innerArray);

            }

            JObject j = new JObject();

            j.Add("listaDados", jsonArray);

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = "INSERT INTO ORDEM_SERVICO (LISTA_DADOS) VALUES(CONVERT(@listaDados using utf8mb4))";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@listaDados", j);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void insertOrdemServico(int id, List<string[,]> listaDados, string dt, string valorPago, string valorTotal, int numeroNota, string tipoPag, int pagou, string fileNameAndPath)
        {

            JArray jsonArray = new JArray();
            foreach (string[,] linha in listaDados)
            {
                JArray innerArray = new JArray();
                for (int i = 0; i < linha.GetLength(0); i++)
                {
                    JArray innerInnerArray = new JArray();
                    for (int jo = 0; jo < linha.GetLength(1); jo++)
                    {
                        innerInnerArray.Add(linha[i, jo]);
                    }
                    innerArray.Add(innerInnerArray);
                }
                jsonArray.Add(innerArray);

            }

            JObject j = new JObject();

            j.Add("listaDados", jsonArray);

            string fileName = Path.GetFileName(fileNameAndPath);

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = "INSERT INTO ORDEM_SERVICO(ID_CLIENTE, LISTA_DADOS, DATA, VALOR_PAGO, VALOR_TOTAL, NUM_NOTA, TIPO_PAG, PAGO, NOME_ARQ) " +
                                            "VALUES (@id, @lista, @dt, @valorPago, @valorTotal, @numeroNota, @tipoPag, @pagou, @fileNameAndPath)";

            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@lista", j);
            command.Parameters.AddWithValue("@dt", DateTime.Parse(dt));
            command.Parameters.AddWithValue("@valorPago", valorPago);
            command.Parameters.AddWithValue("@valorTotal", valorTotal);
            command.Parameters.AddWithValue("@numeroNota", numeroNota);
            command.Parameters.AddWithValue("@tipoPag", Convert.ToInt32(tipoPag));
            command.Parameters.AddWithValue("@pagou", pagou);
            command.Parameters.AddWithValue("@fileNameAndPath", fileNameAndPath);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public string getPathByIdServico(string idServico)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string path = "";

            string query = "SELECT NOME_ARQ FROM ordem_servico WHERE ID_N_SERVICO = @searchterm";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@searchterm", idServico);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    path = reader.GetString(0);
                }
            }

            connection.Close();

            return path;

            //SELECT NOME_ARQ FROM ordem_servico WHERE ID_N_SERVICO =
            //return "";
        }

        public void ocultaTodasNotasDoClientPeloId(int id)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "SELECT ID_N_SERVICO FROM ordem_servico WHERE ID_CLIENTE = @searchterm";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@searchTerm", id);

            using (MySqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (reader.GetName(i) == "ID_N_SERVICO")
                        {
                            ocultaNota(Convert.ToInt32(reader.GetValue(i).ToString()));
                        }
                    }
                }
            }
            connection.Close();
        }
        public void ocultaNota(int id)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "UPDATE ordem_servico SET EXCLUIDO = 1 WHERE ID_N_SERVICO = @searchTerm";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@searchTerm", id);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
