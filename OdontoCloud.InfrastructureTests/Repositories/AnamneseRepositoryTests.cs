using OdontoCloud.Domain.Entities;
using OdontoCloud.InfrastructureTests.Utilitaries;
using Xunit;

namespace OdontoCloud.Infrastructure.Repositories.Tests
{
    public class AnamneseRepositoryTests
    {
        [Fact]
        public void TestAdd()
        {
            //Arrange
            var repository = new AnamneseRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            Anamnese anamnese = new Anamnese(1, false, "Descriçao", false, false, false, false, false, false, false, false, false, "Descrição", false, "Descrição", false, false, false, false, "Descrição", false, false);

            //Act
            var anamneseResult = repository.Save(anamnese);

            //Assert
            Assert.True(anamneseResult.Id == 1);
        }

        [Fact]
        public void TestUpdate()
        {
            //Arrange
            var repository = new AnamneseRepository(OdontoCloudTestUtil.GetDbContextInMemory());

            //Act
            var id = repository.Save(new Anamnese() { DescricaoAlergia = "Alergia do lobão" }).Id;
            Anamnese anamnese = repository.FindById(id);
            anamnese.DescricaoAlergia = "Alterei a descrição";
            repository.Update(anamnese);

            //Assert
            Assert.True(repository.FindById(id).DescricaoAlergia == "Alterei a descrição");
        }

        [Fact]
        public void TestDeleteById()
        {
            //Arrange
            var repository = new AnamneseRepository(OdontoCloudTestUtil.GetDbContextInMemory());

            //Act
            repository.Save(new Anamnese());
            var id = repository.Save(new Anamnese()).Id;
            repository.DeleteById(id);
            var count = repository.Count();

            //Assert
            Assert.True(count == 1);
        }

        [Fact]
        public void TestCount()
        {
            //Arrange
            var repository = new AnamneseRepository(OdontoCloudTestUtil.GetDbContextInMemory());

            //Act
            repository.Save(new Anamnese());
            repository.Save(new Anamnese());
            var count = repository.Count();

            //Assert
            Assert.True(count == 2);
        }

        [Fact]
        public void TestFindAll()
        {
            //Arrange
            var repository = new AnamneseRepository(OdontoCloudTestUtil.GetDbContextInMemory());

            //Act
            repository.Save(new Anamnese());
            repository.Save(new Anamnese());
            repository.Save(new Anamnese());
            List<Anamnese> anamneseList = repository.FindAll();

            //Assert
            Assert.True(anamneseList.Count == 3);
        }

        [Fact]
        public void TestFindById()
        {
            //Arrange
            var repository = new AnamneseRepository(OdontoCloudTestUtil.GetDbContextInMemory());

            //Act
            var id = repository.Save(new Anamnese() { DescricaoAlergia = "Alergia do lobão" }).Id;
            Anamnese anamnese = repository.FindById(id);

            //Assert
            Assert.True(anamnese.DescricaoAlergia == "Alergia do lobão");
        }
    }
}