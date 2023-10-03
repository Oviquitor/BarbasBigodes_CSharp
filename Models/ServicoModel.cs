using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbasBigodes.Models
{
    class ServicoModel
    {
        public ServicoModel()
        {
            CraidoEm = DateTime.Now;
            AlteradoEm = DateTime.Now;
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public decimal AliquotaComissao { get; set; }
        public DateTime AlteradoEm { get; set; }
        public DateTime CraidoEm { get; set; }

    }
}
