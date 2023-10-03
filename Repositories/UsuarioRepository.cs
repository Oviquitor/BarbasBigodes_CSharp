using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using BarbasBigodes.Core;
using BarbasBigodes.Models;

namespace BarbasBigodes.Repositories
{
    class UsuarioRepository
    {
        private SqlConnection sqlConnection;
        public UsuarioRepository(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
            CriarAdmin();
        }

        public UsuarioModel ObterUsuarioPor(String nome, String senha)
        {
            UsuarioModel usuario = null;
            string senhaCriptografada = Criptografia.ObterHash(senha);
            string sql = @"Select 
                              Id, Nome, CriadoEm, AlteradoEm 
                          From 
                              Usuarios 
                          where 
                              Nome = @nome and Senha = @senha
            ";

            var cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@senha", senhaCriptografada);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuario = new UsuarioModel();
                usuario.Id = reader.GetInt32(0);
                usuario.Nome = reader.GetString(1);
                usuario.CriadoEm = reader.GetDateTime(2);
                usuario.AlteradoEm = reader.GetDateTime(3);
            }

            reader.Close();
            cmd.Dispose();

            return usuario;
        }
            
        public void CriarAdmin()
        {
            var nome = "Admin";
            var senha = "123";
            var usuario = ObterUsuarioPor(nome, senha);

            if(usuario == null)
            {
                var hash = Criptografia.ObterHash(senha);
                var sql = @"Insert into Usuarios
                                (Nome, Senha, CriadoEm, AlteradoEm)
                              values
                                (@nome, @hash, @criadoEm, @alteradoEm)
                ";
                var command = new SqlCommand(sql, sqlConnection);
                command.Parameters.AddWithValue("@nome", nome);
                command.Parameters.AddWithValue("@hash", hash);
                command.Parameters.AddWithValue("@criadoEm", DateTime.Now);
                command.Parameters.AddWithValue("@alteradoEm", DateTime.Now);

                command.ExecuteNonQuery();
                command.Dispose();
            }
        }

        public void Salvar(UsuarioModel usuario)
        {
            if(usuario.Id == 0)
            {
                Adicionar(usuario);
            }
            else
            {
                Alterar(usuario);
            }
        }

        private void Adicionar(UsuarioModel usuario)
        {
            var sql = @"Insert Into Usuarios
                           (Nome, Senha, CriadoEm, AlteradoEm)
                        values
                            (@nome, @senha, @criadoEm, @alteradoEm)
            ";
            var hash = Criptografia.ObterHash(usuario.Senha);
            var cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@nome", usuario.Nome);
            cmd.Parameters.AddWithValue("@senha", hash);
            cmd.Parameters.AddWithValue("@criadoEm", usuario.CriadoEm);
            cmd.Parameters.AddWithValue("@alteradoEm", usuario.AlteradoEm);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        private void Alterar(UsuarioModel usuario)
        {
            var sql = @"Update Usuarios set 
                            Nome = @nome,
                            Senha = @hash,
                            AlteradoEm = @alteradoEm
                          where
                             Id = @id
            ";

            var hash = Criptografia.ObterHash(usuario.Senha);
            var cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@nome", usuario.Nome);
            cmd.Parameters.AddWithValue("@hash", hash);
            cmd.Parameters.AddWithValue("@alteradoEm", DateTime.Now);
            cmd.Parameters.AddWithValue("@id", usuario.Id);
        }

        public List<UsuarioModel> ObterUsuarios()
        {
            var usuarios = new List<UsuarioModel>();
            var sql = @"Select Id, Nome, CriadoEm, AlteradoEm
                            from Usuarios
                         where Nome != 'admin' 
                         Order by Nome
            ";

            var cmd = new SqlCommand(sql, sqlConnection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var usuario = new UsuarioModel();
                usuario.Id = reader.GetInt32(0);
                usuario.Nome = reader.GetString(1);
                usuario.CriadoEm = reader.GetDateTime(2);
                usuario.AlteradoEm = reader.GetDateTime(3);
                usuarios.Add(usuario);
            }

            reader.Close();
            cmd.Dispose();

            return usuarios;
        }
    }
}
