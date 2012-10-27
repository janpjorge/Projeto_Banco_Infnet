using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistBancario.Modelo
{
   public abstract class Cliente
    {

       public Cliente(string Nome)
       {
           this.Nome = Nome;
       }

        public string Nome { get; set; }
        public List<Endereco> Enderecos { get; set; }
        public List<Telefone> Telefones { get; set; }
       
        
    }
}
