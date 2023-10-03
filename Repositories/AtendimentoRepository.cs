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
    class AtendimentoRepository
    {
        private SqlConnection sqlConnection;

        public AtendimentoRepository(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        public void Salvar(AtendimentoModel atendimento)
        {
            if(atendimento.Id == 0)
            {
                Adicionar(atendimento);
            }
            else
            {

            }
        }

        private void Adicionar(AtendimentoModel atendimento)
        {
            var sql = @"Insert into Atendimentos 
                            (Data, Total, CriadoEm, AlteradoEm)
                          values
                            (@data, @total, @criadoEm, @alteradoEm)
            ";

            var cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@data", atendimento.Data);
            cmd.Parameters.AddWithValue("@total", atendimento.Total);
            cmd.Parameters.AddWithValue("@criadoEm", atendimento.CriadoEm);
            cmd.Parameters.AddWithValue("@alteradoEm", atendimento.AlteradoEm);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        private void Alterar(AtendimentoModel atendimento)
        {
            var sql = @"Update Atendimentos set
                            Data = @data,
                            Total = @total,
                            AlteradoEm = @alteradoEm
                         where
                            Id = @id
            ";

            var cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@id", atendimento.Id);
            cmd.Parameters.AddWithValue("@data", atendimento.Data);
            cmd.Parameters.AddWithValue("@total", atendimento.Total);
            cmd.Parameters.AddWithValue("@criadoEm", atendimento.CriadoEm);
            cmd.Parameters.AddWithValue("@alteradoEm", atendimento.AlteradoEm);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public void Excluir (AtendimentoModel atendimento)
        {
            var sql = @"Delete from Atendimentos where Id = @id";
            var cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@id", atendimento.Id);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public List<AtendimentoModel> ObterLista()
        {
            var atendimentos = new List<AtendimentoModel>();

            var sql = @"Select Id, Data, Total, CriadoEm, AlteradoEm 
                            from Atendimentos
                          Order by Nome
            ";
            var cmd = new SqlCommand(sql, sqlConnection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var atendimento = new AtendimentoModel();
                atendimento.Id = reader.GetInt32(0);
                atendimento.Data = reader.GetDateTime(1);
                atendimento.Total = reader.GetDecimal(2);
                atendimento.CriadoEm = reader.GetDateTime(3);
                atendimento.AlteradoEm = reader.GetDateTime(4);

                atendimentos.Add(atendimento);
            }

            reader.Close();
            cmd.Dispose();

            return atendimentos;
        }
    }
}
