using Braga;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Servico1
{
    internal class ClientesDAO
    {
        
        //string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=fAd8qv]LYn2R3TH!;database=mydb; pooling = false; convert zero datetime=True";

        string connectionString = Conect.conn;

        public List<Clientes> getAllClientes()
        {
            
            // começamos com a criação de uma lista 
            List<Clientes> clientes = new List<Clientes>();

            // conectando com o servidor SQL
            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            // coleção de sql para reunir usuarios
            MySqlCommand command = new MySqlCommand("SELECT ID_PF, NOME as 'Nome', ENDERECO as 'Endereço', CELULAR as 'Telefone', DT_CADASTRO as 'Dt de cadastro', DOC_PESSOAL as 'Documento', DESCRICAO as 'Descrição', N_NF as 'Notas' FROM PESSOA_FISICA", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Clientes a = new Clientes
                    {
                        ID_PF = reader.GetInt32(0),
                        NOME = reader.GetString(1),
                        ENDERECO = reader.GetString(2),
                        CELULAR = reader.GetString(3),
                        DT_CADASTRO = reader.GetString(4),
                        DOC_PESSOAL = reader.GetString(5),
                        DESCRICAO = reader.GetString(6),
                        N_NF = reader.GetInt32(7)
                    };
                    clientes.Add(a);
                }
            }
            connection.Close();

            return clientes;
        }

        public List<Clientes> procurarClienteEspecificoPorNomeRetornLista(string searchTerm)
        {
            // começamos com a criação de uma lista 
            List<Clientes> clientes = new List<Clientes>();

            if (searchTerm != null && searchTerm != "")
            {
                // conectando com o servidor SQL
                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();
                String searchPhrase = "%" + searchTerm + "%";

                // coleção de sql para reunir usuarios
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "SELECT * FROM PESSOA_FISICA WHERE NOME = @search";
                command.Parameters.AddWithValue("@search", searchPhrase);
                command.Connection = connection;

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Clientes a = new Clientes
                        {
                            ID_PF = reader.GetInt32(0),
                            NOME = reader.GetString(1),
                            ENDERECO = reader.GetString(2),
                            CELULAR = reader.GetString(3),
                            DT_CADASTRO = reader.GetString(4),
                            DOC_PESSOAL = reader.GetString(5),
                            DESCRICAO = reader.GetString(6),
                            N_NF = reader.GetInt32(7)
                        };
                        clientes.Add(a);
                    }
                }
                connection.Close();

            }

            return clientes;
        }

        public List<Clientes> procurarClientePeloNomeRetornLista(string searchTerm)
        {
            // começamos com a criação de uma lista 
            List<Clientes> clientes = new List<Clientes>();

            if (searchTerm != null && searchTerm != "")
            {
                // conectando com o servidor SQL
                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();

                // coleção de sql para reunir usuarios
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "SELECT * FROM PESSOA_FISICA WHERE NOME LIKE @search";
                String searchPhrase = searchTerm + "%";
                command.Parameters.AddWithValue("@search", searchPhrase);
                command.Connection = connection;

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Clientes a = new Clientes
                        {
                            ID_PF = reader.GetInt32(0),
                            NOME = reader.GetString(1),
                            ENDERECO = reader.GetString(2),
                            CELULAR = reader.GetString(3),
                            DT_CADASTRO = reader.GetString(4),
                            DOC_PESSOAL = reader.GetString(5),
                            DESCRICAO = reader.GetString(6),
                            N_NF = reader.GetInt32(7)
                        };
                        clientes.Add(a);
                    }
                }
                connection.Close();

            }

            return clientes;
        }

        public List<Clientes> procurarClientePeloDocRetornaLista(string searchTerm)
        {
            // começamos com a criação de uma lista 
            List<Clientes> clientes = new List<Clientes>();

            if (searchTerm != null && searchTerm != "")
            {
                // conectando com o servidor SQL
                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();
                String searchPhrase = "%" + searchTerm + "%";

                // coleção de sql para reunir usuarios
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "SELECT * FROM PESSOA_FISICA WHERE DOC_PESSOAL LIKE @search";
                command.Parameters.AddWithValue("@search", searchPhrase);
                command.Connection = connection;

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Clientes a = new Clientes
                        {
                            ID_PF = reader.GetInt32(0),
                            NOME = reader.GetString(1),
                            ENDERECO = reader.GetString(2),
                            CELULAR = reader.GetString(3),
                            DT_CADASTRO = reader.GetString(4),
                            DOC_PESSOAL = reader.GetString(5),
                            DESCRICAO = reader.GetString(6),
                            N_NF = reader.GetInt32(7)
                        };
                        clientes.Add(a);
                    }
                }
                connection.Close();

            }

            return clientes;
        }
        public bool procuraNomeParaValidar(string searchNome)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT NOME FROM PESSOA_FISICA WHERE NOME = @searchNome";
            command.Parameters.AddWithValue("@searchNome", searchNome);

            command.Connection = connection;

            bool validacao = true;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    validacao = false;
                    //CLIENTE EXISTE PELA PROCURA DE NOME, LOGO CADASTRAR
                }
            }

            connection.Close();

            return validacao;

        }
        public bool procuraDocParaValidar(string searchDoc)
        {

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT DOC_PESSOAL FROM PESSOA_FISICA WHERE DOC_PESSOAL = @searchDoc";
            command.Parameters.AddWithValue("@searchDoc", searchDoc);

            command.Connection = connection;

            bool validacao = true;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    validacao = false;
                    //CLIENTE EXISTE PELA PROCURA DE DOC, LOGO NÃO CADASTRAR
                    //SE ESTÁ FALSE SIGNIFICA QUE O READER PUXOU UMA LINHA, LOGO EXISTE O CADASTRO
                }
            }

            connection.Close();

            return validacao;
        }

        public int insertClienteParaPdV(string searchNome, string searchEndereco, string searchCelular, string searchDt_Cadastro, string searchDocumento, string searchDescricao, int searchN_NF)
        {
            try
            {
                if (validaTodosCamposExistem(searchNome, searchEndereco, searchCelular, searchDt_Cadastro, searchDocumento, searchDescricao, searchN_NF))
                {
                    if (procuraDocParaValidar(searchDocumento) && procuraNomeParaValidar(searchNome))
                    {
                        MySqlConnection connection = new MySqlConnection(connectionString);

                        connection.Open();

                        MySqlCommand command = new MySqlCommand();

                        command.CommandText = "INSERT INTO `PESSOA_FISICA`" +
                                                "(ID_PF, NOME, ENDERECO, CELULAR, DT_CADASTRO, DOC_PESSOAL, DESCRICAO, N_NF) " +
                                                "VALUES (0, @searchNome, @searchEndereco, @searchCelular, @searchDt_Cadastro, @searchDocumento, @searchDescricao, @searchN_NF)";
                        command.Parameters.AddWithValue("@searchNome", searchNome);
                        command.Parameters.AddWithValue("@searchEndereco", searchEndereco);
                        command.Parameters.AddWithValue("@searchCelular", searchCelular);
                        command.Parameters.AddWithValue("@searchDt_Cadastro", searchDt_Cadastro);
                        command.Parameters.AddWithValue("@searchDocumento", searchDocumento);
                        command.Parameters.AddWithValue("@searchDescricao", searchDescricao);
                        command.Parameters.AddWithValue("@searchN_NF", searchN_NF);
                        command.Connection = connection;
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    else if (!procuraDocParaValidar(searchDocumento)) { return 1; }
                    else if (!procuraNomeParaValidar(searchNome)) { return 2; }
                    else if (!procuraDocParaValidar(searchDocumento) && !procuraNomeParaValidar(searchNome)) { return 3; }
                }
                else
                {
                    return 0;
                }
                return 4;
            }
            catch (Exception ex)
            {
                return 5;
                MessageBox.Show("Ocorreu um erro. " + ex.Message);
            }
        }

        public bool insertCliente(string searchNome, string searchEndereco, string searchCelular, string searchDt_Cadastro, string searchDocumento, string searchDescricao, int searchN_NF)
        {
            bool validar = false;
            if (validaTodosCamposExistem(searchNome, searchEndereco, searchCelular, searchDt_Cadastro, searchDocumento, searchDescricao, searchN_NF))
            {
                

                if (procuraNomeParaValidar(searchNome))
                {
                    MySqlConnection connection = new MySqlConnection(connectionString);

                    connection.Open();

                    MySqlCommand command = new MySqlCommand();

                    command.CommandText = "INSERT INTO `PESSOA_FISICA`" +
                                            "(ID_PF, NOME, ENDERECO, CELULAR, DT_CADASTRO, DOC_PESSOAL, DESCRICAO, N_NF) " +
                                            "VALUES (0, @searchNome, @searchEndereco, @searchCelular, @searchDt_Cadastro, @searchDocumento, @searchDescricao, @searchN_NF)";
                    command.Parameters.AddWithValue("@searchNome", searchNome);
                    command.Parameters.AddWithValue("@searchEndereco", searchEndereco);
                    command.Parameters.AddWithValue("@searchCelular", searchCelular);
                    command.Parameters.AddWithValue("@searchDt_Cadastro", searchDt_Cadastro);
                    command.Parameters.AddWithValue("@searchDocumento", searchDocumento);
                    command.Parameters.AddWithValue("@searchDescricao", searchDescricao);
                    command.Parameters.AddWithValue("@searchN_NF", searchN_NF);
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                    MessageBox.Show("Perfil cadastrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    connection.Close();
                    validar = true;
                }
                else
                {
                    MessageBox.Show("Já existe esse cliente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            return validar;
        }

        private bool validaTodosCamposExistem(string searchNome, string searchEndereco, string searchCelular, string searchDt_Cadastro, string searchDocumento, string searchDescricao, int searchN_NF)
        {
            if (searchNome != "" && searchEndereco != "" && searchCelular != "" && searchDt_Cadastro != "" && searchDocumento != "" && searchDescricao != "" && searchN_NF >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string dataHoje()
        {
            string hoje = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss");
            return hoje;
        }

        public AutoCompleteStringCollection autoCompleteSource(string searchNome)
        {

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            MySqlCommand command = new MySqlCommand();

            string termo = searchNome + "%";

            command.CommandText = "SELECT NOME FROM PESSOA_FISICA WHERE NOME LIKE @searchNome";
            command.Parameters.AddWithValue("@searchNome", termo);
            command.Connection = connection;

            AutoCompleteStringCollection myColection = new AutoCompleteStringCollection();

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    myColection.Add(reader.GetString(0));
                }
            }

            connection.Close();
            return myColection;
        }

        public List<Clientes> procurarClientePorDataRetornaLista(List<DateTime> listaDatas)
        {

            List<Clientes> clientes = new List<Clientes>();

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

                command.CommandText = "SELECT * FROM PESSOA_FISICA WHERE DATE(DT_CADASTRO) BETWEEN STR_TO_DATE(@datainicial,'%d,%m,%Y') and STR_TO_DATE(@datafinal,'%d,%m,%Y') order by NOME";
                command.Parameters.AddWithValue("@datainicial", dataI);
                command.Parameters.AddWithValue("@datafinal", dataF);

                command.Connection = connection;

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Clientes a = new Clientes
                        {
                            ID_PF = reader.GetInt32(0),
                            NOME = reader.GetString(1),
                            ENDERECO = reader.GetString(2),
                            CELULAR = reader.GetString(3),
                            DT_CADASTRO = reader.GetString(4),
                            DOC_PESSOAL = reader.GetString(5),
                            DESCRICAO = reader.GetString(6),
                            N_NF = reader.GetInt32(7)
                        };
                        clientes.Add(a);
                    }
                }
                connection.Close();
            }


            return clientes;
        }
       
        //public string updateCliente(string id, string nomeAtual, string docAtual, string nomeNovo, string end, string tel, string doc, string desc)
        //{
        //    string validacao = "";
        //    bool podeAtualizar = false;

        //    if (nomeAtual == nomeNovo && docAtual == doc)
        //    {
        //        //o nome NÃO mudou E o doc NÃO mudou
        //        //ATUALIZA SEM VERIFICAR
        //        podeAtualizar = true;
        //    }
        //    else if (nomeAtual != nomeNovo)
        //    {
        //        // o nome mudou
        //        //ATUALIZA VERIFICANDO O NOME

        //        //A FUNCAO RETORNA TRUE SE NÃO EXISTE REGISTRO DE NOME NO BANCO DE DADOS
        //        if (procuraNomeParaValidar(nomeNovo)) { podeAtualizar = true; }
        //    }
        //    else if (docAtual != doc)
        //    {
        //        //o doc mudou
        //        //ATUALIZA VERIFICANDO O DOC
        //        if (procuraDocParaValidar(doc)) { podeAtualizar = true; }
        //    }
        //    else
        //    {
        //        //os dois mudaram
        //        //ATUALIZA VERIFICANDO OS DOIS
        //        if (procuraNomeParaValidar(nomeNovo) && procuraDocParaValidar(doc)) { podeAtualizar = true; }
        //    }

        //    if (podeAtualizar)
        //    {

        //        int queryRetorno = 0;

        //        MySqlConnection connection = new MySqlConnection(connectionString);

        //        connection.Open();

        //        MySqlCommand command = new MySqlCommand();

        //        command.CommandText = "UPDATE PESSOA_FISICA SET NOME = @nomeNovo, ENDERECO = @end, CELULAR = @tel, DOC_PESSOAL = @doc, DESCRICAO = @desc WHERE ID_PF = @id;";
        //        command.Parameters.AddWithValue("@id", id);
        //        command.Parameters.AddWithValue("@nomeNovo", nomeNovo);
        //        command.Parameters.AddWithValue("@end", end);
        //        command.Parameters.AddWithValue("@tel", tel);
        //        command.Parameters.AddWithValue("@doc", doc);
        //        command.Parameters.AddWithValue("@desc", desc);
        //        command.Connection = connection;
        //        queryRetorno = command.ExecuteNonQuery();
        //        connection.Close();

        //        if (queryRetorno == 0 || queryRetorno == -1)
        //        {
        //            MessageBox.Show("UPDATE FALHO no query");
        //        }
        //    }

        //    if (!podeAtualizar) { validacao = "Atualização falhou"; }
        //    else { validacao = "Atualização deu certo"; }
        //    return validacao;
        //}

        public string updateCliente(string id, string nomeAtual, string docAtual, string nomeNovo, string end, string tel, string doc, string desc)
        {
            string validacao = "";

            int queryRetorno = 0;

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            MySqlCommand command = new MySqlCommand();

            command.CommandText = "UPDATE PESSOA_FISICA SET NOME = @nomeNovo, ENDERECO = @end, CELULAR = @tel, DOC_PESSOAL = @doc, DESCRICAO = @desc WHERE ID_PF = @id;";
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@nomeNovo", nomeNovo);
            command.Parameters.AddWithValue("@end", end);
            command.Parameters.AddWithValue("@tel", tel);
            command.Parameters.AddWithValue("@doc", doc);
            command.Parameters.AddWithValue("@desc", desc);
            command.Connection = connection;
            queryRetorno = command.ExecuteNonQuery();
            connection.Close();

            if (queryRetorno == 0 || queryRetorno == -1)
            {
                MessageBox.Show("UPDATE FALHO no query");
            }

            return validacao = "Atualização deu certo";
        }

        private bool validaApenasNumeros(string num)
        {
            if (Regex.IsMatch(num.ToString(), @"^[0-9]+$"))
            {
                return true;
            }
            return false;
        }

        private bool validaApenasLetras(string palavra)
        {
            if (Regex.IsMatch(palavra, @"^[a-zA-Z]+$"))
            {
                return true;
            }
            return false;
        }

        public bool validarCamposCadastro(string nome, string doc)
        {
            bool validar = true;

            if (nome != "" && doc != "")
            {
                if (nome.Length > 45 || !Regex.IsMatch(nome, @"^[a-zA-ZÀ-ú ]+$"))
                {
                    MessageBox.Show("O campo NOME incorreto", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    //lblWarning.Text = "O campo nome deve ter menos de 45 letras"; 
                    validar = false;
                }
                else if (doc.Length > 15 || !Regex.IsMatch(doc, @"^[0-9xX]+$"))
                {
                    MessageBox.Show("O campo DOCUMENTO incorreto", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    //lblWarning.Text = "O campo documento deve ter menos de 15 letras";
                    validar = false;
                }
            }
            else
            {
                MessageBox.Show("Pelo menos os campos NOME e DOCUMENTO precisam ser preenchidos", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                //lblWarning.Text = "Os campos devem ser preenchidos. (Menos no campo descrição)";
                validar = false;
            }

            return validar;
        }

        public bool deleteCliente(string id)
        {
            int queryRetorno = 0;

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            MySqlCommand command = new MySqlCommand();

            command.CommandText = "DELETE FROM PESSOA_FISICA WHERE ID_PF = @id";
            command.Parameters.AddWithValue("@id", id);
            command.Connection = connection;
            queryRetorno = command.ExecuteNonQuery();
            connection.Close();

            if (queryRetorno < 1)
            {
                
                return false;
            }

            return true;
        }

        public int buscaNumeroNota(int id)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            MySqlCommand command = new MySqlCommand();

            command.CommandText = "SELECT N_NF FROM PESSOA_FISICA WHERE ID_PF = @id";
            command.Parameters.AddWithValue("@id", id);
            command.Connection = connection;

            int n = 0;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Clientes a = new Clientes
                    {
                        N_NF = reader.GetInt32(0)
                    };
                    n = a.N_NF;
                }
            }

            connection.Close();
            return n;
        }

        internal void adicionarNumeroNota(int id)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            MySqlCommand command = new MySqlCommand();

            command.CommandText = "UPDATE PESSOA_FISICA SET N_NF = N_NF + 1 WHERE ID_PF = @id";
            command.Parameters.AddWithValue("@id", id);
            command.Connection = connection;
            command.ExecuteReader();

            connection.Close();
        }

        internal object procurarClientePeloTelRetornaLista(string searchTerm)
        {
            // começamos com a criação de uma lista 
            List<Clientes> clientes = new List<Clientes>();

            if (searchTerm != null && searchTerm != "")
            {
                // conectando com o servidor SQL
                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();
                String searchPhrase = "%" + searchTerm + "%";

                // coleção de sql para reunir usuarios
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "SELECT * FROM PESSOA_FISICA WHERE CELULAR LIKE @search";
                command.Parameters.AddWithValue("@search", searchPhrase);
                command.Connection = connection;

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Clientes a = new Clientes
                        {
                            ID_PF = reader.GetInt32(0),
                            NOME = reader.GetString(1),
                            ENDERECO = reader.GetString(2),
                            CELULAR = reader.GetString(3),
                            DT_CADASTRO = reader.GetString(4),
                            DOC_PESSOAL = reader.GetString(5),
                            DESCRICAO = reader.GetString(6),
                            N_NF = reader.GetInt32(7)
                        };
                        clientes.Add(a);
                    }
                }
                connection.Close();

            }

            return clientes;
        }
    }
}
