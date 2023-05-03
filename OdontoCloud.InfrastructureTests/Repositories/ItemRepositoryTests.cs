using OdontoCloud.Domain.Entities;
using OdontoCloud.InfrastructureTests.Utilitaries;
using Xunit;

namespace OdontoCloud.Infrastructure.Repositories.Tests
{
    public class ItemTests
    {
        Item sugador = new Item
        {
            IdFornecedor = 1,
            Descricao = "Sugador",
            Marca = "Brastemp",
            UnidadeMedida = "UN",
            QuantidadeEstoque = 2,
            ValorUnitario = 10,
        };

        Item laminaBisturi = new Item
        {
            IdFornecedor = 1,
            Descricao = "Lâmina de bisturi",
            Marca = "Brastemp",
            UnidadeMedida = "UN",
            QuantidadeEstoque = 5,
            ValorUnitario = 7.50,
        };

        [Fact]
        public void TestAdd()
        {
            //Arrange
            var repository = new ItemRepository(OdontoCloudTestUtil.GetDbContextInMemory());

            //Act
            var itemResult = repository.Save(sugador);

            //Assert
            Assert.True(itemResult.Id == 1);
        }

        [Fact]
        public void TestUpdate()
        {
            //Arrange
            var repository = new ItemRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            
            //Act
            var id = repository.Save(sugador).Id;
            Item itemFindById = repository.FindById(id);
            itemFindById.Descricao = "Kit Sugador";
            repository.Update(itemFindById);

            //Assert
            Assert.True(repository.FindById(id).Descricao == "Kit Sugador");
        }

        [Fact]
        public void TestDeleteById()
        {
            //Arrange
            var repository = new ItemRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            
            //Act
            repository.Save(sugador);
            var id = repository.Save(laminaBisturi).Id;
            repository.DeleteById(id);
            var count = repository.Count();

            //Assert
            Assert.True(count == 1);
        }

        [Fact]
        public void TestCount()
        {
            //Arrange
            var repository = new ItemRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            
            //Act
            repository.Save(sugador);
            repository.Save(laminaBisturi);
            var count = repository.Count();

            //Assert
            Assert.True(count == 2);
        }

        [Fact]
        public void TestFindAll()
        {
            //Arrange
            var repository = new ItemRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            
            //Act
            repository.Save(sugador);
            repository.Save(laminaBisturi);
            List<Item> itemList = repository.FindAll();

            //Assert
            Assert.True(itemList.Count == 2);
        }

        [Fact]
        public void TestFindById()
        {
            //Arrange
            var repository = new ItemRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            
            //Act
            var id = repository.Save(sugador).Id;
            Item itemFindById = repository.FindById(id);

            //Assert
            Assert.True(itemFindById.Descricao == "Sugador");
        }
    }
}