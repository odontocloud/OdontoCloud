using OdontoCloud.Domain.Entities;
using OdontoCloud.InfrastructureTests.Utilitaries;
using Xunit;

namespace OdontoCloud.Infrastructure.Repositories.Tests
{
    public class ClienteRepositoryTests
    {
        Cliente clientePaulinPinho = new Cliente
        {
            CPF = "12345678910",
            RG = "12354646",
            Nome = "Paulin Pinho"
        };

        Cliente clienteDanilin = new Cliente
        {
            CPF = "98765432110",
            RG = "87464842",
            Nome = "Danilin"
        };

        [Fact]
        public void TestAdd()
        {
            //Arrange
            var repository = new ClienteRepository(OdontoCloudTestUtil.GetDbContextInMemory());

            //Act
            var clienteResult = repository.Save(clientePaulinPinho);

            //Assert
            Assert.True(clienteResult.Id == 1);
        }

        [Fact]
        public void TestUpdate()
        {
            //Arrange
            var repository = new ClienteRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            
            //Act
            var id = repository.Save(clientePaulinPinho).Id;
            Cliente clienteFindById = repository.FindById(id);
            clienteFindById.Nome = "Paulin Pinho Júnior";
            repository.Update(clienteFindById);

            //Assert
            Assert.True(repository.FindById(id).Nome == "Paulin Pinho Júnior");
        }

        [Fact]
        public void TestDeleteById()
        {
            //Arrange
            var repository = new ClienteRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            
            //Act
            repository.Save(clientePaulinPinho);
            var id = repository.Save(clienteDanilin).Id;
            repository.DeleteById(id);
            var count = repository.Count();

            //Assert
            Assert.True(count == 1);
        }

        [Fact]
        public void TestCount()
        {
            //Arrange
            var repository = new ClienteRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            
            //Act
            repository.Save(clientePaulinPinho);
            repository.Save(clienteDanilin);
            var count = repository.Count();

            //Assert
            Assert.True(count == 2);
        }

        [Fact]
        public void TestFindAll()
        {
            //Arrange
            var repository = new ClienteRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            
            //Act
            repository.Save(clientePaulinPinho);
            repository.Save(clienteDanilin);
            List<Cliente> clienteList = repository.FindAll();

            //Assert
            Assert.True(clienteList.Count == 2);
        }

        [Fact]
        public void TestFindById()
        {
            //Arrange
            var repository = new ClienteRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            
            //Act
            var id = repository.Save(clientePaulinPinho).Id;
            Cliente clienteFindAll = repository.FindById(id);

            //Assert
            Assert.True(clienteFindAll.Nome == "Paulin Pinho");
        }
    }
}