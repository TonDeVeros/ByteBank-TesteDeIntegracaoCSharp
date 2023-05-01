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
    public class ClienteRepositorioTestes
    {
        private readonly IClienteRepositorio _repositorio;

        public ClienteRepositorioTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            //Com a adicao desse construtor não preciso mais instanciar o código no arrange
            var servico = new ServiceCollection();
            servico.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            var provedor = servico.BuildServiceProvider();
            _repositorio = provedor.GetService<IClienteRepositorio>();

        }


        [Fact]
        public void ObterTodosClientes()
        {
            //Arrange
            //var _repositorio = new ClienteRepositorio();

            //Act 
            List<Cliente> lista = _repositorio.ObterTodos();

            Assert.NotNull(lista);
            Assert.Equal(3, lista.Count());
        }

        [Fact]
        public void TestaObterClientePorId()
        {
            //Arrange

            //Act
            var cliente = _repositorio.ObterPorId(1);

            //Assert
            Assert.NotNull(cliente);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestaObterClientesPorVariosId(int id)
        {
            //Arrange

            //Act
            var cliente = _repositorio.ObterPorId(id);

            //Assert
            Assert.NotNull(cliente);
        }
    }
}
