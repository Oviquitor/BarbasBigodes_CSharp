﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbasBigodes.Models
{
    class AtendimentoModel
    {
        public AtendimentoModel()
        {
            Data = DateTime.Now;
            CriadoEm = DateTime.Now;
            AlteradoEm = DateTime.Now;
        }

        public int Id { get; set; }
        public AgendamentoModel Agendamento { get; set; }
        public UsuarioModel Usuario { get; set; }
        public ClienteModel Cliente { get; set; }
        public DateTime Data { get; set; }
        public decimal Total { get; set; }
        public decimal Valor { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AlteradoEm { get; set; }


    }
}
