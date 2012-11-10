using System.Linq;
using SistBancario.Enums;
using SistBancario.Modelo;

namespace SistBancario.Repositorios
{
    public class RepositorioClientes : IRepositorio<Cliente>
    {
        RepositorioClientes()
        {

        }
        
        public static RepositorioClientes Instance
        {
            get
            {
                if (instance == null)
                    instance = new RepositorioClientes();

                return instance as RepositorioClientes;
            }
        }

        public Cliente[] RetornaClientes(StatusConta statusConta)
        {
            var res = from cc in RepositorioContas.Instance.RetornaTodos()
                      from cliente in RetornaTodos()
                      where cc.Clientes.Contains(cliente)
                      && cc.Status == statusConta
                      select cliente;

            return res.ToArray();
        }

        public Cliente[] RetornaClientes(int agencia)
        {
            var res = from cc in RepositorioContas.Instance.RetornaContas(agencia) 
                      from cliente in RetornaTodos()
                      where cc.Clientes.Contains(cliente)
                      select cliente;

            return res.ToArray();
        }

    }
}

