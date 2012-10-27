using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistBancario.Enums;

namespace SistBancario.Modelo
{
    public class Telefone
    {
        public int DDD { get; set; }
        public int Numero { get; set; }
        public TipoTelefone Tipo { get; set; }
    }
}
