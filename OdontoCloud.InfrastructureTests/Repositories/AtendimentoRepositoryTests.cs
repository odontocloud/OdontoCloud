using OdontoCloud.Domain.Entities;
using OdontoCloud.InfrastructureTests.Utilitaries;
using Xunit;

namespace OdontoCloud.Infrastructure.Repositories.Tests
{
    public class AtendimentoRepositoryTests
    {
        Atendimento primeiroAtendimento = new Atendimento
        {
            Descricao = "Limpeza",
            Data = new DateTime(2023, 04, 28),
            IdCliente = 1,
            Situacao = "Finalizado",
            TempoDuracao = 60,
            Valor = 100
        };

        Atendimento segundoAtendimento = new Atendimento
        {
            Descricao = "Obturação",
            Data = new DateTime(2023, 04, 28),
            IdCliente = 1,
            Situacao = "Finalizado",
            TempoDuracao = 90,
            Valor = 150
        };

        [Fact]
        public void TestAdd()
        {
            //Arrange
            var repository = new AtendimentoRepository(OdontoCloudTestUtil.GetDbContextInMemory());

            //Act
            var atendimentoResult = repository.Save(primeiroAtendimento);

            //Assert
            Assert.True(atendimentoResult.Id == 1);
        }

        [Fact]
        public void TestUpdate()
        {
            //Arrange
            var repository = new AtendimentoRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            
            //Act
            var id = repository.Save(primeiroAtendimento).Id;
            Atendimento atendimentoFindById = repository.FindById(id);
            atendimentoFindById.Descricao = "Limpeza e escovação";
            repository.Update(atendimentoFindById);

            //Assert
            Assert.True(repository.FindById(id).Descricao == "Limpeza e escovação");
        }

        [Fact]
        public void TestDeleteById()
        {
            //Arrange
            var repository = new AtendimentoRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            
            //Act
            repository.Save(primeiroAtendimento);
            var id = repository.Save(segundoAtendimento).Id;
            repository.DeleteById(id);
            var count = repository.Count();

            //Assert
            Assert.True(count == 1);
        }

        [Fact]
        public void TestCount()
        {
            //Arrange
            var repository = new AtendimentoRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            
            //Act
            repository.Save(primeiroAtendimento);
            repository.Save(segundoAtendimento);
            var count = repository.Count();

            //Assert
            Assert.True(count == 2);
        }

        [Fact]
        public void TestFindAll()
        {
            //Arrange
            var repository = new AtendimentoRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            
            //Act
            repository.Save(primeiroAtendimento);
            repository.Save(segundoAtendimento);
            List<Atendimento> atendimentoList = repository.FindAll();

            //Assert
            Assert.True(atendimentoList.Count == 2);
        }

        [Fact]
        public void TestFindById()
        {
            //Arrange
            var repository = new AtendimentoRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            
            //Act
            var id = repository.Save(primeiroAtendimento).Id;
            Atendimento atendimentoFindById = repository.FindById(id);

            //Assert
            Assert.True(atendimentoFindById.Descricao == "Limpeza");
        }
    }
}