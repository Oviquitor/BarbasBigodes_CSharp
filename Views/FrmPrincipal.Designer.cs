
namespace BarbasBigodes.Views
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.mnuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuCadastros = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBarbeiros = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadastroServicos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServicos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAgendamentos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAtendimentos = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuStrip
            // 
            this.mnuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCadastros,
            this.mnuServicos});
            this.mnuStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuStrip.Name = "mnuStrip";
            this.mnuStrip.Size = new System.Drawing.Size(1469, 24);
            this.mnuStrip.TabIndex = 0;
            this.mnuStrip.Text = "menuStrip1";
            // 
            // mnuCadastros
            // 
            this.mnuCadastros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClientes,
            this.mnuBarbeiros,
            this.mnuUsuarios,
            this.mnuCadastroServicos});
            this.mnuCadastros.Name = "mnuCadastros";
            this.mnuCadastros.Size = new System.Drawing.Size(71, 20);
            this.mnuCadastros.Text = "Cadastros";
            // 
            // mnuClientes
            // 
            this.mnuClientes.Name = "mnuClientes";
            this.mnuClientes.Size = new System.Drawing.Size(123, 22);
            this.mnuClientes.Text = "Clientes";
            this.mnuClientes.Click += new System.EventHandler(this.mnuClientes_Click);
            // 
            // mnuBarbeiros
            // 
            this.mnuBarbeiros.Name = "mnuBarbeiros";
            this.mnuBarbeiros.Size = new System.Drawing.Size(123, 22);
            this.mnuBarbeiros.Text = "Barbeiros";
            this.mnuBarbeiros.Click += new System.EventHandler(this.mnuBarbeiros_Click);
            // 
            // mnuUsuarios
            // 
            this.mnuUsuarios.Name = "mnuUsuarios";
            this.mnuUsuarios.Size = new System.Drawing.Size(123, 22);
            this.mnuUsuarios.Text = "Usuários";
            this.mnuUsuarios.Click += new System.EventHandler(this.mnuUsuarios_Click);
            // 
            // mnuCadastroServicos
            // 
            this.mnuCadastroServicos.Name = "mnuCadastroServicos";
            this.mnuCadastroServicos.Size = new System.Drawing.Size(123, 22);
            this.mnuCadastroServicos.Text = "Serviços";
            this.mnuCadastroServicos.Click += new System.EventHandler(this.mnuCadastroServicos_Click);
            // 
            // mnuServicos
            // 
            this.mnuServicos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAgendamentos,
            this.mnuAtendimentos});
            this.mnuServicos.Name = "mnuServicos";
            this.mnuServicos.Size = new System.Drawing.Size(62, 20);
            this.mnuServicos.Text = "Serviços";
            // 
            // mnuAgendamentos
            // 
            this.mnuAgendamentos.Name = "mnuAgendamentos";
            this.mnuAgendamentos.Size = new System.Drawing.Size(155, 22);
            this.mnuAgendamentos.Text = "Agendamentos";
            this.mnuAgendamentos.Click += new System.EventHandler(this.mnuAgendamentos_Click);
            // 
            // mnuAtendimentos
            // 
            this.mnuAtendimentos.Name = "mnuAtendimentos";
            this.mnuAtendimentos.Size = new System.Drawing.Size(155, 22);
            this.mnuAtendimentos.Text = "Atendimentos";
            this.mnuAtendimentos.Click += new System.EventHandler(this.mnuAtendimentos_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsuario});
            this.statusStrip1.Location = new System.Drawing.Point(0, 674);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1469, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(86, 17);
            this.lblUsuario.Text = "Usuário: Nome";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1469, 696);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mnuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuStrip;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barbas & Bigodes - Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mnuStrip.ResumeLayout(false);
            this.mnuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuStrip;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuario;
        private System.Windows.Forms.ToolStripMenuItem mnuCadastros;
        private System.Windows.Forms.ToolStripMenuItem mnuClientes;
        private System.Windows.Forms.ToolStripMenuItem mnuBarbeiros;
        private System.Windows.Forms.ToolStripMenuItem mnuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem mnuCadastroServicos;
        private System.Windows.Forms.ToolStripMenuItem mnuServicos;
        private System.Windows.Forms.ToolStripMenuItem mnuAgendamentos;
        private System.Windows.Forms.ToolStripMenuItem mnuAtendimentos;
    }
}