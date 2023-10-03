using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using BarbasBigodes.Views;

namespace BarbasBigodes
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


            var login = new FrmLogin();
            login.ShowDialog();

            if(App.Usuario != null)
            {
                Application.Run(new FrmPrincipal());
            }
        }
    }
}
