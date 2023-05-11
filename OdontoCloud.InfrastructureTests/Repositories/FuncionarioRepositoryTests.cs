using OdontoCloud.Domain.Entities;
using OdontoCloud.InfrastructureTests.Utilitaries;
using Xunit;

namespace OdontoCloud.Infrastructure.Repositories.Tests
{
    public class FuncionarioRepositoryTests
    {
        Funcionario funcionarioPaulinPinho = new Funcionario
        {
            CPF = "12345678910",
            RG = "12354646",
            Nome = "Paulin Pinho",
            DataNascimento = new DateTime(1995, 07, 08),
            EstadoCivil = EstadoCivilEnum.Solteiro.ToString(),
            TelCelular = "(18) 999996662",
            TelResidencial = "(18) 36225987",
            Cargo = "Dentista",
            Salario = 3000
       };

        Funcionario funcionarioDanilin = new Funcionario
        {
            CPF = "10987654321",
            RG = "54587963",
            Nome = "Danilin",
            DataNascimento = new DateTime(1995, 05, 12),
            EstadoCivil = EstadoCivilEnum.Casado.ToString(),
            TelCelular = "(18) 998897662",
            TelResidencial = "(18) 36234736",
            Cargo = "Auxiliar",
            Salario = 1500
        };

        [Fact]
        public void TestAdd()
        {
            //Arrange
            var repository = new FuncionarioRepository(OdontoCloudTestUtil.GetDbContextInMemory());

            //Act
            var funcionarioResult = repository.Save(funcionarioPaulinPinho);

            //Assert
            Assert.True(funcionarioResult.Id == 1);
        }

        [Fact]
        public void TestUpdate()
        {
            //Arrange
            var repository = new FuncionarioRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            
            //Act
            var id = repository.Save(funcionarioPaulinPinho).Id;
            Funcionario funcionarioFindById = repository.FindById(id);
            funcionarioFindById.Nome = "Paulin Pinho Júnior";
            repository.Update(funcionarioFindById);

            //Assert
            Assert.True(repository.FindById(id).Nome == "Paulin Pinho Júnior");
        }

        [Fact]
        public void TestDeleteById()
        {
            //Arrange
            var repository = new FuncionarioRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            
            //Act
            repository.Save(funcionarioPaulinPinho);
            var id = repository.Save(funcionarioDanilin).Id;
            repository.DeleteById(id);
            var count = repository.Count();

            //Assert
            Assert.True(count == 1);
        }

        [Fact]
        public void TestCount()
        {
            //Arrange
            var repository = new FuncionarioRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            
            //Act
            repository.Save(funcionarioPaulinPinho);
            repository.Save(funcionarioDanilin);
            var count = repository.Count();

            //Assert
            Assert.True(count == 2);
        }

        [Fact]
        public void TestFindAll()
        {
            //Arrange
            var repository = new FuncionarioRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            
            //Act
            repository.Save(funcionarioPaulinPinho);
            repository.Save(funcionarioDanilin);
            List<Funcionario> funcionarioList = repository.FindAll();

            //Assert
            Assert.True(funcionarioList.Count == 2);
        }

        [Fact]
        public void TestFindById()
        {
            //Arrange
            var repository = new FuncionarioRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            
            //Act
            var id = repository.Save(funcionarioPaulinPinho).Id;
            Funcionario funcionarioFindById = repository.FindById(id);

            //Assert
            Assert.True(funcionarioFindById.Nome == "Paulin Pinho");
        }

        [Fact]
        public void TestNullableFields()
        {
            //Arrange
            var repository = new FuncionarioRepository(OdontoCloudTestUtil.GetDbContextInMemory());

            //Act
            var id = repository.Save(funcionarioPaulinPinho).Id;

            //Assert
            Assert.True(repository.FindById(id).EstadoCivil == "Solteiro");
            Assert.True(repository.FindById(id).TelCelular == "(18) 999996662");
            Assert.True(repository.FindById(id).TelResidencial == "(18) 36225987");
        }
    }
}