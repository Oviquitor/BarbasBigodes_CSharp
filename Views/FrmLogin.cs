using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BarbasBigodes.Core;
using BarbasBigodes.Repositories;

namespace BarbasBigodes.Views
{
    public partial class FrmLogin : Form
    { 
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {

            try
            {
                var connection = ConexaoFactory.Abrir();
                var repository = new UsuarioRepository(connection);
                App.Usuario = repository.ObterUsuarioPor(txtUsuario.Text, txtSenha.Text);

                if (App.Usuario != null)
                {
                    Close();
                }
                else
                {
                    MessageBox.Show("Usuário ou Senha incorreto", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtUsuario.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                txtSenha.Focus();
                e.Handled = true;
            }
        }

        private void txtSenha_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnEntrar.Focus();
                e.Handled = true;
            }
        }
    }
}
