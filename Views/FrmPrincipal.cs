using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarbasBigodes.Views
{
    public partial class FrmPrincipal : Form
    {
        private FrmUsuarios frmUsuarios = null;
        private FrmServicos frmServicos = null;
        private FrmClientes frmClientes = null;
        private FrmBarbeiros frmBarbeiros = null;
        private FrmAtendimentos frmAtendimentos = null;
        private FrmAgendamentos frmAgendamentos = null;
        public FrmPrincipal()
        {
            InitializeComponent();
            lblUsuario.Text = "Usuário: " + App.Usuario.Nome;
        }

        private void mnuClientes_Click(object sender, EventArgs e)
        {
            if (frmClientes == null || frmClientes.IsDisposed)
            {
                frmClientes = new FrmClientes();
                frmClientes.MdiParent = this;
            }

            frmClientes.Show();
        }

        private void mnuBarbeiros_Click(object sender, EventArgs e)
        {
            if(frmBarbeiros == null || frmBarbeiros.IsDisposed)
            {
                frmBarbeiros = new FrmBarbeiros();
                frmBarbeiros.MdiParent = this;
            }

            frmBarbeiros.Show();
        }

        private void mnuUsuarios_Click(object sender, EventArgs e)
        {
            if(frmUsuarios == null || frmUsuarios.IsDisposed)
            {
                frmUsuarios = new FrmUsuarios();
                frmUsuarios.MdiParent = this;
            }

            frmUsuarios.Show();
        }

        private void mnuCadastroServicos_Click(object sender, EventArgs e)
        {
            if(frmServicos == null || frmServicos.IsDisposed)
            {
                frmServicos = new FrmServicos();
                frmServicos.MdiParent = this;
            }

            frmServicos.Show();
        }

        private void mnuAgendamentos_Click(object sender, EventArgs e)
        {
            if(frmAgendamentos == null || frmAgendamentos.IsDisposed)
            {
                frmAgendamentos = new FrmAgendamentos();
                frmAgendamentos.MdiParent = this;
            }

            frmAgendamentos.Show();
        }

        private void mnuAtendimentos_Click(object sender, EventArgs e)
        {
            if(frmAtendimentos == null || frmAtendimentos.IsDisposed)
            {
                frmAtendimentos = new FrmAtendimentos();
                frmAtendimentos.MdiParent = this;
            }

            frmAtendimentos.Show();
        }
    }
}
