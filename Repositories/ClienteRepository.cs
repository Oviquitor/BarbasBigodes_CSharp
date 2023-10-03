using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using BarbasBigodes.Models;
using BarbasBigodes.Core;

namespace BarbasBigodes.Repositories
{
    class ClienteRepository
    {
        private SqlConnection sqlConnection;
        public ClienteRepository(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        public void Salvar(ClienteModel cliente)
        {
            if(cliente.Id == 0)
            {
                Adicionar(cliente);
            }
            else
            {
                Alterar(cliente);
            }
        }

        private void Adicionar(ClienteModel cliente)
        {
            var sql = @"Insert Into Clientes
                            (Nome, Endereco, Bairro, Cidade, UF, Celular, TelefoneFixo, CriadoEm, AlteradoEm)
                          values
                            (@nome, @endereco, @bairro, @cidade, @uf, @celular, @telefoneFixo, @criadoEm, @alteradoEm)
            ";
            var cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@endereco", cliente.Endereco);
            cmd.Parameters.AddWithValue("@bairro", cliente.Bairro);
            cmd.Parameters.AddWithValue("@cidade", cliente.Cidade);
            cmd.Parameters.AddWithValue("@uf", cliente.UF);
            cmd.Parameters.AddWithValue("@celular", cliente.Celular);
            cmd.Parameters.AddWithValue("@telefoneFixo", cliente.TelefoneFixo);
            cmd.Parameters.AddWithValue("@criadoEm", cliente.CriadoEm);
            cmd.Parameters.AddWithValue("@alteradoEm", cliente.AlteradoEm);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        private void Alterar(ClienteModel cliente)
        {
            var sql = @"Update Clientes set 
                            Nome = @nome,
                            Endereco = @endereco,
                            Bairro = @bairro,
                            Cidade = @cidade,
                            UF = @uf,
                            Celular = @celular
                            TelefoneFixo = @telefoneFixo
                            AlteradoEm = @alteradoEm
            ";
            var cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@endereco",cliente.Endereco);
            cmd.Parameters.AddWithValue("@bairro", cliente.Bairro);
            cmd.Parameters.AddWithValue("@cidade", cliente.Cidade);
            cmd.Parameters.AddWithValue("@uf", cliente.UF);
            cmd.Parameters.AddWithValue("@celular", cliente.Celular);
            cmd.Parameters.AddWithValue("@telefoneFixo", cliente.TelefoneFixo);
            cmd.Parameters.AddWithValue("@alteradoEm", cliente.AlteradoEm);

            cmd.ExecuteNonQuery();
            cmd.Dispose();

        }

        public List<ClienteModel> ObterCliente()
        {
            var clientes = new List<ClienteModel>();
            var sql = @"Select Id, Nome, Endereco, Bairro, Cidade, UF, Celular,TelefoneFixo, CriadoEm, AlteradoEm
                           from Clientes
                           Order by Nome
            ";
            var cmd = new SqlCommand(sql, sqlConnection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var cliente = new ClienteModel();
                cliente.Id = reader.GetInt32(0);
                cliente.Nome = reader.GetString(1);
                cliente.Endereco = reader.GetString(2);
                cliente.Bairro = reader.GetString(3);
                cliente.Cidade = reader.GetString(4);
                cliente.UF = reader.GetString(5);
                cliente.Celular = reader.GetString(6);
                cliente.TelefoneFixo = reader.GetString(7);
                cliente.CriadoEm = reader.GetDateTime(8);
                cliente.AlteradoEm = reader.GetDateTime(9);
            }

            reader.Close();
            cmd.Dispose();

            return clientes;
        }

        private void Excluir(ClienteModel cliente)
        {
            var sql = @"Delete From Clientes where Id = @id";
            var cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@id", cliente.Id);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
    }
}
