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
    class BarbeiroRepository
    {
        private SqlConnection sqlConnection;
        
        public BarbeiroRepository(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        public void Salvar(BarbeiroModel barbeiro)
        {
            if (barbeiro.Id == 0)
            {
                Adicionar(barbeiro);
            }
            else
            {
                Alterar(barbeiro);
            }

        }
        private void Adicionar(BarbeiroModel barbeiro)
        {
            var sql = @"Insert Into Barbeiros
                            (Nome, Celular01, Celular02, CriadoEm, AlteradoEm)
                            values
                               (@nome, @celular01, @celular02, @criadoem, @alteradoem)";

            var cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@nome", barbeiro.Nome);
            cmd.Parameters.AddWithValue("@celular01", barbeiro.Celular01);
            cmd.Parameters.AddWithValue("@celular02", barbeiro.Celular02);
            cmd.Parameters.AddWithValue("@criadoem", barbeiro.CriadoEm);
            cmd.Parameters.AddWithValue("@alteradoem", barbeiro.AlteradoEm);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

        }

        private void Alterar(BarbeiroModel barbeiro)
        {
            var sql = @"Update Barbeiros set
                            Nome = @nome,
                            Celular01 = @celular01,
                            Celular02 = @celular02,
                            AlteradoEm = GetDate()
                         where
                            Id = @id";
            //gera uma conexção
            var cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@nome", barbeiro.Nome);
            cmd.Parameters.AddWithValue("@celular01", barbeiro.Celular01);
            cmd.Parameters.AddWithValue("@celular02", barbeiro.Celular02);
            cmd.Parameters.AddWithValue("@id", barbeiro.Id);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public List<BarbeiroModel> ObterBarbeiros()
        {
            var barbeiros = new List<BarbeiroModel>();
            var sql = @"Select Id, Nome, Celular01, Celular02, CriadoEm, AlteradoEm
                        from Barbeiros
                        Order by Nome";

            var cmd = new SqlCommand(sql, sqlConnection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var barbeiro = new BarbeiroModel();

                barbeiro.Id = reader.GetInt32(0);
                barbeiro.Nome = reader.GetString(1);
                barbeiro.Celular01 = reader.GetString(2);
                barbeiro.Celular02 = reader.GetString(3);
                barbeiro.CriadoEm = reader.GetDateTime(4);
                barbeiro.AlteradoEm = reader.GetDateTime(5);

                barbeiros.Add(barbeiro);
            }

            reader.Close();
            cmd.Dispose();

            return barbeiros;
        }

        public void Excluir(BarbeiroModel barbeiro)
        {
            var sql = @"Delete from Barbeiros where Id = @id";
            var cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@id", barbeiro.Id);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
    }
}
