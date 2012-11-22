using System;
using Infnet.Proj.SistBancario.Modelo;
using SistBancario.Modelo;

namespace Infnet.Proj.SistBancario.Teste
{
    public static class Fabrica
    {
        private static Random rand = new Random();

        public static Agencia CriaAgencia()
        {
            Agencia retVal = new Agencia();

            retVal.Endereco = new Endereco() 
            {
                Bairro = "Centro",
                CEP = 00000000,
                Cidade = "Rio de Janeiro",
                Complemento = String.Empty,
                Logradouro = "Primeiro de Março",
                Numero = 1,
                TipoDeLogradouro = "Rua",
                UF = "RJ",
            };

            retVal.ID = rand.Next(1,100);

            return retVal;
        }

        public static Cliente CriaCliente(bool EPessoaFisica)
        {
            Cliente retVal = null;

            if (EPessoaFisica)
                retVal = new PessoaFisica(rand.Next(10000).ToString(), rand.Next(600, 1000), 0001);
            else
                retVal = new PessoaJuridica(rand.Next(10000).ToString(), rand.Next(10000, 100000), 0002);

            return retVal;
        }
    }
}
