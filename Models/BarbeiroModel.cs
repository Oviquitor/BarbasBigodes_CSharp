using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbasBigodes.Models
{
    class BarbeiroModel
    {
        public BarbeiroModel()
        {
            CriadoEm = DateTime.Now;
            AlteradoEm = DateTime.Now;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Celular01 { get; set; }
        public string Celular02 { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AlteradoEm { get; set; }
       
    }
}
