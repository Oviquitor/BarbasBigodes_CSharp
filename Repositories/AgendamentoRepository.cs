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
    class AgendamentoRepository
    {
        private SqlConnection sqlConnection;

        public AgendamentoRepository(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        public void Salvar(AgendamentoModel agendamento)
        {
            if(agendamento.Id == 0)
            {
                Adicionar(agendamento);
            }
            else
            {
                Alterar(agendamento);
            }
        }

        private void Adicionar(AgendamentoModel agendamento)
        {
            var sql = @"Insert into Agendamentos 
                            (Data, Status, Total, CriadoEm, AlteradoEm)
                          values
                            (@data, @status, @total, @criadoEm, @alteradoEm)
            ";

            var cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@data", agendamento.Data);
            cmd.Parameters.AddWithValue("@status", agendamento.Status);
            cmd.Parameters.AddWithValue("@total", agendamento.Total);
            cmd.Parameters.AddWithValue("@criadoEm", agendamento.CriadoEm);
            cmd.Parameters.AddWithValue("@alteradoEm", agendamento.AlteradoEm);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        private void Alterar(AgendamentoModel agendamento)
        {
            var sql = @"Update Agendamentos set
                            Data = @data,
                            Status = @status,
                            Total = @total,
                            AlteradoEm = @alteradoEm
                         where
                            Id = @id
            ";

            var cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@data", agendamento.Data);
            cmd.Parameters.AddWithValue("@status", agendamento.Status);
            cmd.Parameters.AddWithValue("@total", agendamento.Total);
            cmd.Parameters.AddWithValue("@alteradoEm", agendamento.AlteradoEm);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public void Excluir(AgendamentoModel agendamento)
        {
            var sql = @"Delete from Agendamentos where Id = @id";
            var cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@id", agendamento.Id);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public List<AgendamentoModel> ObterAgendamentos()
        {
            var agendamentos = new List<AgendamentoModel>();
            var sql = @"Select Id, UsuarioId, ClienteId, Data, Status, Total, CriadoEm, AlteradoEm
                            from Agendamentos
                        where Order by ClienteId
            ";

            var cmd = new SqlCommand(sql, sqlConnection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var agendamento = new AgendamentoModel();
                agendamento.Id = reader.GetInt32(0);
                //agendamento.Usuario = reader.GetInt32(1);
                //agendamento.Cliente = reader.GetInt32(2);
                agendamento.Data = reader.GetDateTime(3);
                agendamento.Status = reader.GetString(4);
                agendamento.Total = reader.GetDecimal(5);
                agendamento.CriadoEm = reader.GetDateTime(6);
                agendamento.AlteradoEm = reader.GetDateTime(7);

                agendamentos.Add(agendamento);
            }

            reader.Close();
            cmd.Dispose();

            return agendamentos;
        }
    }
}
