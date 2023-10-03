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
using BarbasBigodes.Models;
using BarbasBigodes.Repositories;

namespace BarbasBigodes.Views
{
    public partial class FrmBarbeiros : Form
    {
        private BarbeiroModel barbeiroModel = null;        
        public FrmBarbeiros()
        {
            InitializeComponent();
        }

        private void Inicio()
        {
            OcultarBotoes();
            btnAdicionar.Visible = true;
            DesabilitarCaixasDeTexto();
            tabControl1.SelectedTab = tabBarbeiros;
            LimparCaixasDeTexto();
            barbeiroModel = null;
            grdBarbeiros.DataSource = ObterBarbeiros();

        }
        private void OcultarBotoes()
        {
            btnAbandonar.Visible = false;
            btnAdicionar.Visible = false;
            btnAlterar.Visible = false;
            btnExcluir.Visible = false;
            btnSalvar.Visible = false;
        }
        private void DesabilitarCaixasDeTexto()
        {
            txtNome.ReadOnly = false;
            mskCelular01.ReadOnly = true;
            mskCelular02.ReadOnly = true;
        }

        private void HabilitarCaixasDeTexto()
        {
            txtNome.ReadOnly = false;
            mskCelular01.ReadOnly = false;
            mskCelular02.ReadOnly = false;
        }

        private void LimparCaixasDeTexto()
        {
            txtNome.Clear();
            mskCelular01.Clear();
            mskCelular02.Clear();
        }

        private List<BarbeiroModel> ObterBarbeiros()
        {
            var cnn = ConexaoFactory.Abrir();
            var repo = new BarbeiroRepository(cnn);
            var barbeiros = repo.ObterBarbeiros();
            cnn.Close();
            return barbeiros;
        }

        private void btnNovoBarbeiro_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabBarbeiro;
            HabilitarCaixasDeTexto();
            OcultarBotoes();
            btnSalvar.Visible = true;
            btnAbandonar.Visible = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            barbeiroModel = new BarbeiroModel();
            var cnn = ConexaoFactory.Abrir();
            var repo = new BarbeiroRepository(cnn);

            txtNome.Text = barbeiroModel.Nome;
            mskCelular01.Text = barbeiroModel.Celular01;
            mskCelular02.Text = barbeiroModel.Celular02;

            repo.Salvar(barbeiroModel);
            cnn.Close();
            Inicio();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            barbeiroModel = new BarbeiroModel();
            HabilitarCaixasDeTexto();
            LimparCaixasDeTexto();
            OcultarBotoes();
            btnSalvar.Visible = true;
            btnAbandonar.Visible = true;
            txtNome.Focus();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            HabilitarCaixasDeTexto();
            txtNome.Focus();
            OcultarBotoes();
            btnSalvar.Visible = true;
            btnAbandonar.Visible = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show($"Deseja excluir o barbeiro: '{barbeiroModel.Nome}'?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                var cnn = ConexaoFactory.Abrir();
                var repo = new BarbeiroRepository(cnn);
                repo.Excluir(barbeiroModel);
                cnn.Close();
                Inicio();
            }
        }

        private void btnAbandonar_Click(object sender, EventArgs e)
        {
            Inicio();
        }

        private void FrmBarbeiros_Load(object sender, EventArgs e)
        {
            Inicio();
        }

        private void grdBarbeiros_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LimparCaixasDeTexto();
            var index = e.RowIndex;

            if (index < 0)
            {
                return;
            }

            var barbeiros = (List<BarbeiroModel>)grdBarbeiros.DataSource;
            barbeiroModel = barbeiros[index];

            txtNome.Text = barbeiroModel.Nome;
            mskCelular01.Text = barbeiroModel.Celular01;
            mskCelular02.Text = barbeiroModel.Celular02;

            tabControl1.SelectedTab = tabBarbeiro;
            OcultarBotoes();
            btnAdicionar.Visible = true;
            btnAlterar.Visible = true;
            btnExcluir.Visible = true;
            btnAbandonar.Visible = true;
        }
    }
}
