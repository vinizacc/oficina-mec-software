using Braga;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Servico1
{
    internal class UsuariosDAO
    {
        //public List<Usuarios> usuarios = new List<Usuarios>();
        //string connectionString = "datasource=localhost;port=3306;username=root;password=fAd8qv]LYn2R3TH!;database=mydb; pooling = false; convert zero datetime=True";
        string connectionString = Conect.conn;
        public List<Usuarios> getAllUsuarios()
        {
            // começamos com a criação de uma lista 
            List<Usuarios> usuarios = new List<Usuarios>();

            // conectando com o servidor SQL
            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            // coleção de sql para reunir usuarios
            MySqlCommand command = new MySqlCommand("SELECT * FROM USUARIO", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Usuarios a = new Usuarios
                    {
                        ID = reader.GetInt32(0),
                        USUARIO = reader.GetString(1),
                        SENHA = reader.GetString(2)
                    };
                    usuarios.Add(a);
                }
            }
            connection.Close();

            return usuarios;
        }

        public Login.validacao validarLogin(string searchUsuario, string searchSenha)
        {
            // começamos com a criação de uma lista 
            List<Usuarios> usuarios = new List<Usuarios>();

            // conectando com o servidor SQL
            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            // coleção de sql para reunir usuarios
            MySqlCommand command = new MySqlCommand("SELECT * FROM USUARIO", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Usuarios a = new Usuarios
                    {
                        ID = reader.GetInt32(0),
                        USUARIO = reader.GetString(1),
                        SENHA = reader.GetString(2),
                        PRIVILEGIO = reader.GetInt32(3)
                    };
                    usuarios.Add(a);
                }
            }

            connection.Close();

            
            Login.validacao v = new Login.validacao();
            
            bool validar = false;
            Usuarios userRetorno = new Usuarios(); 

            foreach (Usuarios u in usuarios)
            {
                if (u.USUARIO == searchUsuario && u.SENHA == searchSenha)
                {
                    validar = true;
                    
                    userRetorno = u;
                }
            }
            v.validarLogin = validar;
            v.usuario = userRetorno;

            return v;
        }

        public List<Usuarios> procurarLogin(string searchTerm)
        {
            // começamos com a criação de uma lista 
            List<Usuarios> usuarios = new List<Usuarios>();

            // conectando com o servidor SQL
            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            String searchPhrase = "%" + searchTerm + "%";

            // coleção de sql para reunir usuarios
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM USUARIO WHERE USUARIO = @search";
            command.Parameters.AddWithValue("@search", searchTerm);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Usuarios a = new Usuarios
                    {
                        ID = reader.GetInt32(0),
                        USUARIO = reader.GetString(1),
                        SENHA = reader.GetString(2)
                    };
                    usuarios.Add(a);
                }
            }
            connection.Close();

            return usuarios;
        }

        public List<Usuarios> procurarUsuarios(string searchTerm)
        {
            // começamos com a criação de uma lista 
            List<Usuarios> usuarios = new List<Usuarios>();

            if (searchTerm != null && searchTerm != "")
            {
                // conectando com o servidor SQL
                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();
                String searchPhrase = "%" + searchTerm + "%";

                // coleção de sql para reunir usuarios
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "SELECT * FROM USUARIO WHERE USUARIO LIKE @search";
                command.Parameters.AddWithValue("@search", searchPhrase);
                command.Connection = connection;

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Usuarios a = new Usuarios
                        {
                            ID = reader.GetInt32(0),
                            USUARIO = reader.GetString(1),
                            SENHA = reader.GetString(2)
                        };
                        usuarios.Add(a);
                    }
                }
                connection.Close();

            }

            return usuarios;
        }

        public int procurarPrivilegioDoUsuario(string searchTerm)
        {
            
            Usuarios u = new Usuarios();

            if (searchTerm != null && searchTerm != "")
            {
                // conectando com o servidor SQL
                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();
                String searchPhrase = "%" + searchTerm + "%";

                // coleção de sql para reunir usuarios
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "SELECT * FROM USUARIO WHERE USUARIO LIKE @search";
                command.Parameters.AddWithValue("@search", searchPhrase);
                command.Connection = connection;

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        u.ID = reader.GetInt32(0);
                        u.USUARIO = reader.GetString(1);
                        u.SENHA = reader.GetString(2);
                        u.PRIVILEGIO = reader.GetInt32(3);
                        
                    }
                }
                connection.Close();

            }

            return u.PRIVILEGIO;
        }

        public void deletarUsuarios(string searchTerm)
        {
            // começamos com a criação de uma lista 
            List<Usuarios> usuarios = new List<Usuarios>();

            // conectando com o servidor SQL
            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            // coleção de sql para reunir usuarios
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "DELETE FROM USUARIO WHERE USUARIO=@search";
            command.Parameters.AddWithValue("@search", searchTerm);
            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public bool validarRegistro(string searchTerm)
        {
            List<Usuarios> usuarios = procurarLogin(searchTerm);

            foreach (Usuarios u in usuarios)
            {
                if (u.USUARIO == searchTerm)
                {
                    return false;
                }
            }

            return true;
        }

        public bool insertRegistro(string searchUsuario, string searchSenha, int searchConta)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            /*String searchPhrase = "%" + searchTerm + "%"*/
            ;

            // coleção de sql para reunir usuarios
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "INSERT INTO `USUARIO`(ID, USUARIO, SENHA, PRIVILEGIO) VALUES (0,@searchUsuario,@searchSenha,@searchConta)";
            command.Parameters.AddWithValue("@searchUsuario", searchUsuario);
            command.Parameters.AddWithValue("@searchSenha", searchSenha);
            command.Parameters.AddWithValue("@searchConta", searchConta);
            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
            return false;
        }

        //Mudar a senha
        public void updateRegistro(string searchUsuario, string searchSenha)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            MySqlCommand command = new MySqlCommand();
            //UPDATE `USUARIO` SET `ID`= null,`USUARIO`= 'adm',`SENHA`= '12345' WHERE `USUARIO` = 'adm'
            //UPDATE Inventory SET Inventorynumber=@Inventorynumber,Inventory_Name=@Inventory_Name, Quantity =@Quantity ,
            //Location =@Location,Category =@Category WHERE Inventorynumber =@Inventorynumber";

            command.CommandText = "UPDATE USUARIO SET SENHA = @searchSenha WHERE USUARIO = @searchUsuario";
            command.Parameters.AddWithValue("@searchUsuario", searchUsuario);
            command.Parameters.AddWithValue("@searchSenha", searchSenha);
            command.Connection = connection;
            command.ExecuteNonQuery();

            connection.Close();

        }
    }
}
