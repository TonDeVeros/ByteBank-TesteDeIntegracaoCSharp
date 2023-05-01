using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ContaCorrenteRepositorioTestes
    {
        private readonly IContaCorrenteRepositorio _repositorio;

        public ContaCorrenteRepositorioTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            //Com a adicao desse construtor não preciso mais instanciar o código no arrange
            var servico = new ServiceCollection();
            servico.AddTransient<IContaCorrenteRepositorio, ContaCorrenteRepositorio>();
            var provedor = servico.BuildServiceProvider();
            _repositorio = provedor.GetService<IContaCorrenteRepositorio>();

        }


        [Fact]
        public void TestaAtualizaSaldoDeterminadaConta()
        {
            //Arrange
            var conta = _repositorio.ObterPorId(1);
            double saldoNovo = 15;
            conta.Saldo = saldoNovo;

            //Act
            var atualizado = _repositorio.Atualizar(1, conta);

            //Assert
            Assert.True(atualizado);
        }

        [Fact]
        public void TestaInsereUmaNovaContaCorrenteNoBD()
        {
            //Arrange
            var conta = new ContaCorrente()
            {
                Saldo = 10,
                Identificador = Guid.NewGuid(),
                Cliente = new Cliente
                {
                    Nome = "Antonio Santos",
                    CPF = "486.074.980-45",
                    Identificador = Guid.NewGuid(),
                    Profissao = "Desenvolvedor",
                    Id = 1
                },
                Agencia = new Agencia
                {
                    Nome = "Agencia SA",
                    Identificador = Guid.NewGuid(),
                    Id = 1,
                    Endereco = "Rua da Vitória, 15",
                    Numero = 687
                }
            };

            //Act
            var retorno = _repositorio.Adicionar(conta);

            //Assert
            Assert.True(retorno);


        }
    }
}
