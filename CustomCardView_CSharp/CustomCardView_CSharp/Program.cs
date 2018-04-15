using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomCardView_CSharp
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Custom());  /*
                                               Marcos:

                                               - Pode alternar entre Model ou
                                               Custom (Model é o modelo PDM e
                                               Custom é a nossa implementação)

                                               Iniciar com Custom para criação
                                               do cartão TAG com acesso ao 
                                               Banco de Dados SQL Server 2012
                                               e testes.

                                               OBS.: Custom Form de testes.
                                            */
        }
    }
}
