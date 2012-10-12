using SistBancario.Interfaces;

namespace SistBancario.Teste
{
   public class RepositorioContas
    {
       public IConta[] contas = new IConta[10];
       public RepositorioContas()
       {
           for (int i = 0; i < 5; i++)
               contas[i] = new ContaSimples(1, i, 1000);
       }
    }
}
