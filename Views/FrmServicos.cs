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
    public partial class FrmServicos : Form
    {
        private ServicoModel servicoModel = null;
        public FrmServicos()
        {
            InitializeComponent();
        }

        private void Inicio()
        {
            OcultarTodosBotoes();
            btnAdicionar.Visible = true;
            DesabilitarDigitação();
            tabControl1.SelectedTab = tabServicos;
            LimparCaixasDeTexto();

            servicoModel = null;
            grdServicos.DataSource = ObterServicos();
        }

        private void OcultarTodosBotoes()
        {
            btnAbandonar.Visible = false;
            btnAdicionar.Visible = false;
            btnAlterar.Visible = false;
            btnExcluir.Visible = false;
            btnSalvar.Visible = false;
        }

        private void DesabilitarDigitação()
        {
            txtNome.ReadOnly = true;
            nudComissao.ReadOnly = true;
            nudValor.ReadOnly = true;
        }

        private void HabilitarDigtação()
        {
            txtNome.ReadOnly = false;
            nudComissao.ReadOnly = false;
            nudValor.ReadOnly = false;
        }

        private void LimparCaixasDeTexto()
        {
            txtNome.Clear();
            nudValor.Value = 0;
            nudComissao.Value = 0;
        }

        private List<ServicoModel> ObterServicos()
        {
            var cnn = ConexaoFactory.Abrir();
            var repo = new ServicoRepository(cnn);
            var servicos = repo.ObterServicos();
            cnn.Close();
            return servicos;
        }

        private void btnNovoServico_Click(object sender, EventArgs e)
        {
            HabilitarDigtação();
            OcultarTodosBotoes();
            btnSalvar.Visible = true;
            btnAbandonar.Visible = true;
            tabControl1.SelectedTab = tabServico;
            txtNome.Focus();

            servicoModel = new ServicoModel();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var cnn = ConexaoFactory.Abrir();

            var repo = new ServicoRepository(cnn);

            servicoModel.Descricao = txtNome.Text;
            servicoModel.AliquotaComissao = nudComissao.Value;
            servicoModel.Valor = nudValor.Value;

            repo.Salvar(servicoModel);
            cnn.Close();
            Inicio();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            HabilitarDigtação();
            LimparCaixasDeTexto();
            OcultarTodosBotoes();
            btnSalvar.Visible = true;
            btnAbandonar.Visible = true;
            txtNome.Focus();

            servicoModel = new ServicoModel();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            HabilitarDigtação();
            txtNome.Focus();
            OcultarTodosBotoes();
            btnSalvar.Visible = true;
            btnAbandonar.Visible = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show($"Deseja excluir o serviço '{servicoModel.Descricao}'?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
            {
                //abriu uma conexcao
                var cnn = ConexaoFactory.Abrir();
                var repo = new ServicoRepository(cnn);
                repo.Excluir(servicoModel);
                cnn.Close();
                Inicio();
            }
        }

        private void btnAbandonar_Click(object sender, EventArgs e)
        {
            Inicio();
        }

        private void FrmServicos_Load(object sender, EventArgs e)
        {
            Inicio();
        }

        private void grdServicos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LimparCaixasDeTexto();
            // qual a linha que foi clicada 'RowIndex'
            var index = e.RowIndex;

            if (index < 0)
            {
                //return vazio ele sai do evento
                return;
            }
            //abril a lista
            var servicos = (List<ServicoModel>)grdServicos.DataSource;
            //qual componete foi selecionado index
            servicoModel = servicos[index];

            txtNome.Text = servicoModel.Descricao;
            nudValor.Value = servicoModel.Valor;
            nudComissao.Value = servicoModel.AliquotaComissao;

            tabControl1.SelectedTab = tabServico;

            OcultarTodosBotoes();
            btnAdicionar.Visible = true;
            btnAlterar.Visible = true;
            btnExcluir.Visible = true;
            btnAbandonar.Visible = true;
        }
    }
}
