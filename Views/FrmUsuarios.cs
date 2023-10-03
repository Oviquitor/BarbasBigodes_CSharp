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
    public partial class FrmUsuarios : Form
    {
        private UsuarioModel usuarioModel = null;
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void Inicio()
        {
            OcultarBotoes();
            btnAdicionar.Visible = true;
            DesabilitarCaixasDeTexto();
            tabControl1.SelectedTab = tabUsuarios;
            LimparCaixasDeTexto();
            usuarioModel = null;
            grdUsuarios.DataSource = ObterUsuarios();
            
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
            txtSenha.ReadOnly = true;
            txtConfirmarSenha.ReadOnly = true;
        }

        private void HabilitarCaixasDeTexto()
        {
            txtNome.ReadOnly = false;
            txtSenha.ReadOnly = false;
            txtConfirmarSenha.ReadOnly = false;
        }

        private void LimparCaixasDeTexto()
        {
            txtNome.Clear();
            txtSenha.Clear();
            txtConfirmarSenha.Clear();
        }

        private List<UsuarioModel> ObterUsuarios()
        {
            var conexao = ConexaoFactory.Abrir();
            var repository = new UsuarioRepository(conexao);
            var usuarios = repository.ObterUsuarios();
            conexao.Close();
            return usuarios;
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            Inicio();
        }

        private void grdUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LimparCaixasDeTexto();
            var index = e.RowIndex;

            if(index < 0)
            {
                return;
            }
            var usuarios = (List<UsuarioModel>)grdUsuarios.DataSource;
            usuarioModel = usuarios[index];
            txtNome.Text = usuarioModel.Nome;

            tabControl1.SelectedTab = tabUsuario;
            HabilitarCaixasDeTexto();
            OcultarBotoes();
            btnAdicionar.Visible = true;
            btnAlterar.Visible = true;
            btnExcluir.Visible = true;
            btnAbandonar.Visible = true;
        }

        private void btnNovoUsuario_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabUsuario;
            OcultarBotoes();
            btnSalvar.Visible = true;
            btnAbandonar.Visible = true;
            HabilitarCaixasDeTexto();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtSenha.Text != txtConfirmarSenha.Text)
            {
                MessageBox.Show("Senhas diferentes", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSenha.Clear();
                txtConfirmarSenha.Clear();
                txtSenha.Focus();
            }
            else
            {
                usuarioModel = new UsuarioModel();
                var conexao = ConexaoFactory.Abrir();
                var repository = new UsuarioRepository(conexao);

                usuarioModel.Nome = txtNome.Text.Trim();
                usuarioModel.Senha = txtSenha.Text;

                repository.Salvar(usuarioModel);
                conexao.Close();
                Inicio();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            HabilitarCaixasDeTexto();
            LimparCaixasDeTexto();
            OcultarBotoes();
            btnSalvar.Visible = true;
            btnAbandonar.Visible = true;
            txtNome.Focus();
            usuarioModel = new UsuarioModel();
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

        }

        private void btnAbandonar_Click(object sender, EventArgs e)
        {
            Inicio();
        }
    }
}
