using OdontoCloud.Domain.Entities;
using OdontoCloud.InfrastructureTests.Utilitaries;
using Xunit;

namespace OdontoCloud.Infrastructure.Repositories.Tests
{
    public class DetalheDetalheAtendimentoRepositoryTests
    {
        Atendimento primeiroAtendimento = new Atendimento
        {
            Descricao = "Limpeza",
            Data = new DateTime(2023, 04, 28),
            IdCliente = 1,
            IdFuncionario = 1,
            Situacao = "Finalizado",
            TempoDuracao = 60,
            Valor = 100
        };

        DetalheAtendimento primeiroDetalheAtendimento = new DetalheAtendimento
        {
            IdAtendimento = 1,
            IdItem = 1,
            QuantidadeItem = 10
        };

        Atendimento segundoAtendimento = new Atendimento
        {
            Descricao = "Obturação",
            Data = new DateTime(2023, 04, 28),
            IdCliente = 1,
            IdFuncionario = 1,
            Situacao = "Finalizado",
            TempoDuracao = 90,
            Valor = 150
        };

        DetalheAtendimento segundoDetalheAtendimento = new DetalheAtendimento
        {
            IdAtendimento = 2,
            IdItem = 2,
            QuantidadeItem = 6
        };

        [Fact]
        public void TestAdd()
        {
            //Arrange
            var repositoryAtendimento        = new AtendimentoRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            var repositoryDetalheAtendimento = new DetalheAtendimentoRepository(OdontoCloudTestUtil.GetDbContextInMemory());

            //Act
            repositoryAtendimento.Save(primeiroAtendimento);
            var detalheAtendimentoResult = repositoryDetalheAtendimento.Save(primeiroDetalheAtendimento);

            //Assert
            Assert.True(detalheAtendimentoResult.Id == 1);
        }

        [Fact]
        public void TestUpdate()
        {
            //Arrange
            var repositoryAtendimento        = new AtendimentoRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            var repositoryDetalheAtendimento = new DetalheAtendimentoRepository(OdontoCloudTestUtil.GetDbContextInMemory());

            //Act
            repositoryAtendimento.Save(primeiroAtendimento);
            var id = repositoryDetalheAtendimento.Save(primeiroDetalheAtendimento).Id;

            DetalheAtendimento detalheAtendimentoFindById = repositoryDetalheAtendimento.FindById(id);
            detalheAtendimentoFindById.QuantidadeItem = 30;
            repositoryDetalheAtendimento.Update(detalheAtendimentoFindById);

            //Assert
            Assert.True(repositoryDetalheAtendimento.FindById(id).QuantidadeItem == 30);
        }

        [Fact]
        public void TestDeleteById()
        {
            //Arrange
            var repositoryAtendimento        = new AtendimentoRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            var repositoryDetalheAtendimento = new DetalheAtendimentoRepository(OdontoCloudTestUtil.GetDbContextInMemory());

            //Act
            repositoryAtendimento.Save(primeiroAtendimento);
            repositoryDetalheAtendimento.Save(primeiroDetalheAtendimento);

            repositoryAtendimento.Save(segundoAtendimento);
            var id = repositoryDetalheAtendimento.Save(segundoDetalheAtendimento).Id;
            repositoryDetalheAtendimento.DeleteById(id);
            var count = repositoryDetalheAtendimento.Count();

            //Assert
            Assert.True(count == 1);
        }

        [Fact]
        public void TestCount()
        {
            //Arrange
            var repositoryAtendimento        = new AtendimentoRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            var repositoryDetalheAtendimento = new DetalheAtendimentoRepository(OdontoCloudTestUtil.GetDbContextInMemory());

            //Act
            repositoryAtendimento.Save(primeiroAtendimento);
            repositoryAtendimento.Save(segundoAtendimento);
            repositoryDetalheAtendimento.Save(primeiroDetalheAtendimento);
            repositoryDetalheAtendimento.Save(segundoDetalheAtendimento);
            var count = repositoryDetalheAtendimento.Count();

            //Assert
            Assert.True(count == 2);
        }

        [Fact]
        public void TestFindAll()
        {
            //Arrange
            var repositoryAtendimento        = new AtendimentoRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            var repositoryDetalheAtendimento = new DetalheAtendimentoRepository(OdontoCloudTestUtil.GetDbContextInMemory());

            //Act
            repositoryAtendimento.Save(primeiroAtendimento);
            repositoryAtendimento.Save(segundoAtendimento);
            repositoryDetalheAtendimento.Save(primeiroDetalheAtendimento);
            repositoryDetalheAtendimento.Save(segundoDetalheAtendimento);
            List<DetalheAtendimento> atendimentoList = repositoryDetalheAtendimento.FindAll();

            //Assert
            Assert.True(atendimentoList.First<DetalheAtendimento>().QuantidadeItem == 10);
            Assert.True(atendimentoList.Count == 2);
        }

        [Fact]
        public void TestFindById()
        {
            //Arrange
            var repositoryAtendimento        = new AtendimentoRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            var repositoryDetalheAtendimento = new DetalheAtendimentoRepository(OdontoCloudTestUtil.GetDbContextInMemory());

            //Act
            repositoryAtendimento.Save(primeiroAtendimento);
            var id = repositoryDetalheAtendimento.Save(primeiroDetalheAtendimento).Id;
            DetalheAtendimento detalheAtendimentoFindById = repositoryDetalheAtendimento.FindById(id);

            //Assert
            Assert.True(detalheAtendimentoFindById.QuantidadeItem == 10);
        }
    }
}