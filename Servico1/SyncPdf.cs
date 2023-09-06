using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Braga
{
    public class SyncPdf
    {
        public void sincronizar()
        {
            string ipAddress = "192.168.25.52"; // Endereço IP do computador remoto
            string folderPath = "C:\\Users\\Vinícius\\OneDrive\\Área de Trabalho\\Programa Backup\\Servico1\\bin\\Debug\\Pdf"; // Caminho da pasta no computador remoto

            WebClient client = new WebClient();
            // Define as credenciais, se necessário
            // client.Credentials = new NetworkCredential("username", "password");

            // Obtém a lista de arquivos no diretório remoto
            //client.
            //string files = client.QueryString.ToString();


            // Itera sobre cada arquivo encontrado
            //foreach (string file in files)
            //{
            //    // Faz o download do arquivo e o salva localmente
            //    client.DownloadFile($"\\\\{ipAddress}\\{folderPath}\\{file}", file);
            //    Console.WriteLine($"Download concluído: {file}");
            //}

            string caminhoPastaRemota = @"\\NomeDoComputador\NomeCompartilhamento\PastaRemota";

            try
            {
                string[] nomesArquivos = ObterNomesArquivosRemotos(caminhoPastaRemota);

                Console.WriteLine("Nomes dos arquivos na pasta remota:");
                foreach (string nomeArquivo in nomesArquivos)
                {
                    Console.WriteLine(nomeArquivo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }


        }

        static string[] ObterNomesArquivosRemotos(string caminhoPastaRemota)
        {
            string[] arquivos = Directory.GetFiles(caminhoPastaRemota);
            string[] nomesArquivos = new string[arquivos.Length];

            for (int i = 0; i < arquivos.Length; i++)
            {
                nomesArquivos[i] = Path.GetFileName(arquivos[i]);
            }

            return nomesArquivos;
        }
    }
}
