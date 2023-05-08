using OdontoCloud.Domain.Entities;
using OdontoCloud.InfrastructureTests.Utilitaries;
using Xunit;

namespace OdontoCloud.Infrastructure.Repositories.Tests
{
    public class FornecedorRepositoryTests
    {
        [Fact]
        public void TestAdd()
        {
            //Arrange
            var repository = new FornecedorRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            Fornecedor Fornecedor = new Fornecedor();

            //Act
            var FornecedorResult = repository.Save(Fornecedor);

            //Assert
            Assert.True(FornecedorResult.Id == 1);
        }

        [Fact]
        public void TestUpdate()
        {
            //Arrange
            var repository = new FornecedorRepository(OdontoCloudTestUtil.GetDbContextInMemory());

            //Act
            var id = repository.Save(new Fornecedor() { NomeFantasia = "Duhzao Lobão" }).Id;
            Fornecedor Fornecedor = repository.FindById(id);
            Fornecedor.NomeFantasia = "Alterei o nome fantasia";
            repository.Update(Fornecedor);

            //Assert
            Assert.True(repository.FindById(id).NomeFantasia == "Alterei o nome fantasia");
        }

        [Fact]
        public void TestDeleteById()
        {
            //Arrange
            var repository = new FornecedorRepository(OdontoCloudTestUtil.GetDbContextInMemory());

            //Act
            repository.Save(new Fornecedor());
            var id = repository.Save(new Fornecedor()).Id;
            repository.DeleteById(id);
            var count = repository.Count();

            //Assert
            Assert.True(count == 1);
        }

        [Fact]
        public void TestCount()
        {
            //Arrange
            var repository = new FornecedorRepository(OdontoCloudTestUtil.GetDbContextInMemory());

            //Act
            repository.Save(new Fornecedor());
            repository.Save(new Fornecedor());
            var count = repository.Count();

            //Assert
            Assert.True(count == 2);
        }

        [Fact]
        public void TestFindAll()
        {
            //Arrange
            var repository = new FornecedorRepository(OdontoCloudTestUtil.GetDbContextInMemory());

            //Act
            repository.Save(new Fornecedor());
            repository.Save(new Fornecedor());
            repository.Save(new Fornecedor());
            List<Fornecedor> FornecedorList = repository.FindAll();

            //Assert
            Assert.True(FornecedorList.Count == 3);
        }

        [Fact]
        public void TestFindById()
        {
            //Arrange
            var repository = new FornecedorRepository(OdontoCloudTestUtil.GetDbContextInMemory());

            //Act
            var id = repository.Save(new Fornecedor() { NomeFantasia = "Nome" }).Id;
            Fornecedor FornecedorFindById = repository.FindById(id);

            //Assert
            Assert.True(FornecedorFindById.NomeFantasia == "Nome");
        }
    }
}