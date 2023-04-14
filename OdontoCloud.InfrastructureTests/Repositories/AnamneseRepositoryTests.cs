using Microsoft.EntityFrameworkCore;
using OdontoCloud.Domain.Entities;
using OdontoCloud.Infrastructure.Context;
using OdontoCloud.InfrastructureTests.Utilitaries;
using Xunit;

namespace OdontoCloud.Infrastructure.Repositories.Tests
{
    public class AnamneseRepositoryTests
    {
        [Fact]
        public void AddTest()
        {
            //Arrange
            var repository = new AnamneseRepository(OdontoCloudUtil.GetDbContextInMemory());
            Anamnese anamnese = new Anamnese(null, 1, false, "Descriçao", false, false, false, false, false, false, false, false, false, "Descrição", false, "Descrição", false, false, false, false, "Descrição", false, false);

            //Act
            var anamneseResult = repository.Add(anamnese);

            //Assert
            Assert.True(anamneseResult.Id == 1);
        }

        
        [Fact]
        public void deleteByIdTest()
        {
        }

        [Fact]
        public void findAllTest()
        {
            
        }

        [Fact]
        public void findByIdTest()
        {
           
        }
    }
}