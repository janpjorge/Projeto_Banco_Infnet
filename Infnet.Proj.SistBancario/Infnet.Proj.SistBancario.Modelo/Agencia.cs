using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistBancario.Modelo;
using SistBancario.Enums;
using SistBancario.Interfaces;
using SistBancario.Repositorios;
using SistBancario.Excecoes;
using SistBancario;

namespace Infnet.Proj.SistBancario.Modelo
{
    public class Agencia
    {
        static Int32 ultimoNumeroConta = 0;

        int iD;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        Endereco endereco;
        public Endereco Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        private void AlteraStatusConta(IConta conta, StatusConta status)
        {
            conta.Status = status;
        }

        public IConta[] RetornaContas()
        {
            return RepositorioContas.Instance.RetornaContas(ID);
        }

        public IConta RetornaConta(int numeroConta)
        {
            return RepositorioContas.Instance.RetornaConta(numeroConta);
        }

        public int CriarConta(Cliente[] clientes)
        {
            double renda = 0;
            foreach (var cliente in clientes)
                if (cliente is PessoaFisica)
                    renda += (cliente as PessoaFisica).Renda;
                else if (cliente is PessoaJuridica)
                    renda += (cliente as PessoaJuridica).Receita;

            IConta conta = CriarContaPorPerfil(clientes, renda);
            AlteraStatusConta(conta, StatusConta.Aberta);

            RepositorioContas.Instance.Adiciona(conta);

            return ultimoNumeroConta;
        }

        private IConta CriarContaPorPerfil(Cliente[] clientes,double renda)
        {
            if (renda < 1500)
                return new ContaSimples(ID, ++ultimoNumeroConta, clientes);
            else
                return new ContaEspecial(ID, ++ultimoNumeroConta, renda * 0.75, clientes);
        }


        public void BloquearConta(int numeroConta)
        {
            try
            {
                IConta conta = RepositorioContas.Instance.RetornaConta(numeroConta);

                VerificarDisponibilidadeConta(conta);

                AlteraStatusConta(conta, StatusConta.Bloqueada);
            }
            catch { throw; }
        }

        public void FecharConta(int numeroConta)
        {
            try
            {
                IConta conta = RepositorioContas.Instance.RetornaConta(numeroConta);

                VerificarDisponibilidadeConta(conta);

                AlteraStatusConta(conta, StatusConta.Fechada);
            }
            catch { throw; }
        }

        private static void VerificarDisponibilidadeConta(IConta conta)
        {
            if (conta == null)
                throw new OperacaoNaoEfetuadaEx("Operação não pôde ser efetuada. Conta Inexistente.");

            if (conta.Status != StatusConta.Aberta)
                throw new OperacaoNaoEfetuadaEx("Operação não pôde ser efetuada. Conta fechada ou bloqueada.");

            if (conta.ExistePendencias())
                throw new OperacaoNaoEfetuadaEx("Operação não pôde ser efetuada. Existem pendência nessa conta.");
        }
    }
}
