using Braga;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Servico1
{
    public class Log
    {
        public string caminhoENome;
        public string barra = "\r\n----------------------------------\r\n";
        public string nome;
        
        public void iniciaArquivoLog()
        {
            string mainFolder = @".\Log\";
            caminhoENome = mainFolder + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + ".txt";
            
            string texto = "Log do arquivo - " + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss");
            nome = DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss");

            using (StreamWriter sw = new StreamWriter(caminhoENome))
            {
                sw.WriteLine(texto);
                sw.WriteLine(barra);
            }
        }

        public string registrar(string texto)
        {
            string conteudoAtual = File.ReadAllText(caminhoENome);

            string novoConteudo = conteudoAtual + Environment.NewLine + texto;

            File.WriteAllText(caminhoENome, novoConteudo);
            
            return novoConteudo;

        }

    }
}
