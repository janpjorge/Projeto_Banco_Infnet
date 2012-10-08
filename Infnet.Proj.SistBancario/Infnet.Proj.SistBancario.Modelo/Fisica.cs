using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infnet.Proj.SistBancario.Modelo
{
    public class Fisica : Cliente 
    {
        public decimal Renda { get; set; }
        public int CPF { get; set; } 
    }
}
