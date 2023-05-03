using OdontoCloud.Domain.Entities;
using OdontoCloud.InfrastructureTests.Utilitaries;
using Xunit;

namespace OdontoCloud.Infrastructure.Repositories.Tests
{
    public class EnderecoRepositoryTests
    {
        Endereco enderecoRuaDoFico = new Endereco
        {
            DescricaoEndereco = "Rua do Fico",
            Numero = "1345",
            Bairo = "Ipanema",
            Cidade = "Araçatuba",
            UF = "SP",
            Pais = "Brasil",
            Cep = "16052312",
            Tipo = TipoEndereco.Residencial.ToString(),
            Complemento = "Perto do Rondon"
        };

        Endereco enderecoAvenidaPrestesMaia = new Endereco
        {
            DescricaoEndereco = "Avenida Prestes Maia",
            Numero = "623",
            Bairo = "Dona Amália",
            Cidade = "Araçatuba",
            UF = "SP",
            Pais = "Brasil",
            Cep = "16052412",
            Tipo = TipoEndereco.Comercial.ToString()
        };

        [Fact]
        public void TestAdd()
        {
            //Arrange
            var repository = new EnderecoRepository(OdontoCloudTestUtil.GetDbContextInMemory());

            //Act
            var enderecoResult = repository.Save(enderecoRuaDoFico);

            //Assert
            Assert.True(enderecoResult.Id == 1);
        }

        [Fact]
        public void TestUpdate()
        {
            //Arrange
            var repository = new EnderecoRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            
            //Act
            var id = repository.Save(enderecoRuaDoFico).Id;
            Endereco enderecoFindById = repository.FindById(id);
            enderecoFindById.DescricaoEndereco = "Avenida Waldemar Alves";
            repository.Update(enderecoFindById);

            //Assert
            Assert.True(repository.FindById(id).DescricaoEndereco == "Avenida Waldemar Alves");
        }

        [Fact]
        public void TestDeleteById()
        {
            //Arrange
            var repository = new EnderecoRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            
            //Act
            repository.Save(enderecoRuaDoFico);
            var id = repository.Save(enderecoAvenidaPrestesMaia).Id;
            repository.DeleteById(id);
            var count = repository.Count();

            //Assert
            Assert.True(count == 1);
        }

        [Fact]
        public void TestCount()
        {
            //Arrange
            var repository = new EnderecoRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            
            //Act
            repository.Save(enderecoRuaDoFico);
            repository.Save(enderecoAvenidaPrestesMaia);
            var count = repository.Count();

            //Assert
            Assert.True(count == 2);
        }

        [Fact]
        public void TestFindAll()
        {
            //Arrange
            var repository = new EnderecoRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            
            //Act
            repository.Save(enderecoRuaDoFico);
            repository.Save(enderecoAvenidaPrestesMaia);
            List<Endereco> enderecoList = repository.FindAll();

            //Assert
            Assert.True(enderecoList.Count == 2);
        }

        [Fact]
        public void TestFindById()
        {
            //Arrange
            var repository = new EnderecoRepository(OdontoCloudTestUtil.GetDbContextInMemory());
            
            //Act
            var id = repository.Save(enderecoRuaDoFico).Id;
            Endereco enderecoFindById = repository.FindById(id);

            //Assert
            Assert.True(enderecoFindById.DescricaoEndereco == "Rua do Fico");
        }

        [Fact]
        public void TestNullableFields()
        {
            //Arrange
            var repository = new EnderecoRepository(OdontoCloudTestUtil.GetDbContextInMemory());

            //Act
            var id = repository.Save(enderecoRuaDoFico).Id;

            //Assert
            Assert.True(repository.FindById(id).Complemento == "Perto do Rondon");
        }
    }
}