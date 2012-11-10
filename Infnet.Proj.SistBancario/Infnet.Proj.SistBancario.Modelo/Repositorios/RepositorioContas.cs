using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistBancario.Repositorios;
using SistBancario.Interfaces;
using SistBancario.Modelo;

namespace SistBancario.Repositorios
{
    public class RepositorioContas: IRepositorio<IConta>
    {
        RepositorioContas()
        {

        }

        public static RepositorioContas Instance
        {
            get
            {
                if (instance == null)
                    instance = new RepositorioContas();

                return instance as RepositorioContas;
            }
        }

        public IConta[] RetornaContas(Cliente cliente)
        {
            var res = from cc in RetornaTodos()
                      where cc.Clientes.Contains(cliente)                      
                      select cc;

            return res.ToArray();
        }

        public IConta[] RetornaContas(int agencia)
        {
            var res = from cc in RetornaTodos()
                      where cc.Agencia == agencia
                      select cc;

            return res.ToArray();
        }

        public IConta RetornaConta(int numeroConta)
        {
            var res = from cc in RetornaTodos()
                      where cc.NumeroConta == numeroConta
                      select cc;

            return res.FirstOrDefault();
        }
    }
}
