using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infnet.Proj.SistBancario.Modelo
{
   public abstract class Cliente
    {
        public string Nome { get; set; }
        public List<Endereco> Enderecos { get; set; }
        public List<Telefone> Telefones { get; set; }
       
        
    }
}
