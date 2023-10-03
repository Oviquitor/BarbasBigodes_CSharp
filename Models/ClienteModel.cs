using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbasBigodes.Models
{
    class ClienteModel
    {
        public ClienteModel()
        {
            CriadoEm = DateTime.Now;
            AlteradoEm = DateTime.Now;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Celular { get; set; }
        public string TelefoneFixo { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AlteradoEm { get; set; }
    }
}
