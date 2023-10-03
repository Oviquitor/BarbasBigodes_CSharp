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
    class ServicoRepository
    {
        private SqlConnection sqlConnection;
        public ServicoRepository (SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        public void Salvar(ServicoModel servico)
        {
            if(servico.Id == 0)
            {
                Adicionar(servico);
            }
            else
            {
                Alterar(servico);
            }
        }

        private void Adicionar(ServicoModel servico)
        {
            var sql = @"Insert Into Servicos
                            (Descricao, Valor, AliquotaComissao, CriadoEm, AlteradoEm)
                        values
                            (@descricao, @valor, @aliquotaComissao, @criadoEm, @alteradoEm)
            ";

            var cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@descricao", servico.Descricao);
            cmd.Parameters.AddWithValue("@valor", servico.Valor);
            cmd.Parameters.AddWithValue("@aliquotaComissao", servico.AliquotaComissao);
            cmd.Parameters.AddWithValue("@criadoEm", servico.CraidoEm);
            cmd.Parameters.AddWithValue("@alteradoEm", servico.AlteradoEm);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        private void Alterar(ServicoModel servico)
        {
            var sql = @"Update Servicos set
                            Descricao = @descricao,
                            Valor = @valor,
                            AliquotaComissao = @aliquotaComissao,
                            AlteradoEm = @alteradoEm,
                          where
                            Id = @id
            ";

            var cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@id", servico.Id);
            cmd.Parameters.AddWithValue("@descricao", servico.Descricao);
            cmd.Parameters.AddWithValue("@valor", servico.Valor);
            cmd.Parameters.AddWithValue("@aliquotaComissao", servico.AliquotaComissao);
            cmd.Parameters.AddWithValue("@alteradoEm", servico.AlteradoEm);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public List<ServicoModel> ObterServicos()
        {
            var servicos = new List<ServicoModel>();
            var sql = @"Select Id, Descricao, Valor, AliquotaComissao, CriadoEm, AlteradoEm
                              from Servicos
                            Order by Nome
            ";
            var cmd = new SqlCommand(sql, sqlConnection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var servico = new ServicoModel();
                servico.Id = reader.GetInt32(0);
                servico.Descricao = reader.GetString(1);
                servico.Valor = reader.GetDecimal(2);
                servico.AliquotaComissao = reader.GetDecimal(3);
                servico.CraidoEm = reader.GetDateTime(4);
                servico.AlteradoEm = reader.GetDateTime(5);

                servicos.Add(servico);
            }
            reader.Close();
            cmd.Dispose();

            return servicos;
        }

        public void Excluir(ServicoModel servico)
        {
            var sql = @"Delete from Servicos where Id = @id";
            var cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@id", servico.Id);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
    }
}
