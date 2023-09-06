using Castle.Components.DictionaryAdapter.Xml;
using Servico1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Braga
{
    class GlobalExceptionHandler
    {
        private static Log logAtual;
        private static bool podeRegistrar;

        public static void Attach(Log log)
        {
            podeRegistrar = true;
            logAtual = log;
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            
            HandleException(e.Exception);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception);
        }

        private static void HandleException(object ex)
        {
            if(ex is Exception excecao)
            {
                if (podeRegistrar)
                {
                    logAtual.registrar("----------EXCEÇÃO----------");
                    logAtual.registrar("EXCEÇÃO: " + excecao.Message);
                    logAtual.registrar("MÉTODO QUE GEROU A EXCEÇÃO: " + excecao.TargetSite);
                    logAtual.registrar("DATA/HORA DA EXCEÇÃO: " + DateTime.Now.ToString("HH:mm:ss dd-MM-yy"));
                    logAtual.registrar("TRILHA DA EXCEÇÃO: " + excecao.StackTrace);
                    logAtual.registrar("---------------------------");
                    MessageBox.Show("Occoreu um erro, fale com o suporte.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    podeRegistrar = false;
                }
            }
            else
            {
                logAtual.registrar("Tratamento de exceção não suportada.");
                MessageBox.Show("Occoreu um erro, fale com o suporte.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}


