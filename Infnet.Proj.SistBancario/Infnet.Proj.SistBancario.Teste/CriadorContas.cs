using SistBancario.Interfaces;

namespace SistBancario.Teste
{
   public class CriadorContas
    {
       public static IConta[] contas;
       public static void CriarContasSimples()
       {
           contas = new IConta[5];
           for (int i = 0; i < 5; i++)
               contas[i] = new ContaSimples(1, i, 1000);

           contas[4].Status = Enums.StatusConta.Bloqueada;
       }

       public static void CriarContasEspeciais()
       {
           contas = new IConta[5];
           for (int i = 0; i < 5; i++)
               contas[i] = new ContaEspecial(1, i, 300,500);


           contas[4].Status = Enums.StatusConta.Bloqueada;
       }
    }
}
