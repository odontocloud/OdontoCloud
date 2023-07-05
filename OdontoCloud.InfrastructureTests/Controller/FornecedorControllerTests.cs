using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdontoCloud.Infrastructure.Profiles;
using System.Net;
using Assert = Xunit.Assert;
using OdontoCloud.Domain.Entities;
using OdontoCloud.Infrastructure.DTOs.Fornecedor;
using OdontoCloud.Controllers;
using OdontoCloud.InfrastructureTests.Utilitaries;
using Microsoft.AspNetCore.JsonPatch;

namespace OdontoCloud.InfrastructureTests.Controller
{
    [TestClass]
    public class FornecedorControllerTests
    {
        Fornecedor Dentinina = new Fornecedor
        {
            NomeFantasia = "Dentinina",
            RazaoSocial = "Dentinina LTDA",
            Cnpj = "1234567891000",
            Endereco = "Rua dos fundadores",
            Cep = 16059746,
            Pais = "Brasil",
            Cidade = "Birigui",
            Bairro = "Ipanema",
            Numero = 5452,
            Uf = "SP"
        };

        Fornecedor DentPlus = new Fornecedor
        {
            NomeFantasia = "DentPlus",
            RazaoSocial = "DentPlus LTDA",
            Cnpj = "1234567891000",
            Endereco = "Rua dos golpes",
            Cep = 16045782,
            Pais = "Brasil",
            Cidade = "Araçatuba",
            Bairro = "Concordia",
            Numero = 54,
            Uf = "SP"
        };

        private static IMapper _mapper;

        public FornecedorControllerTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new FornecedorProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public void TestPostFornecedor()
        {
            //Arrange
            FornecedorController fornecedorController = new(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            FornecedorWriteDTO fornecedorWriteDTO = _mapper.Map<FornecedorWriteDTO>(Dentinina);

            //Act
            var resultPostFornecedor = fornecedorController.PostFornecedor(fornecedorWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostFornecedor.StatusCode);

            //Act
            int IdFornecedor = 1;
            var resultGetFornecedorById = fornecedorController.GetFornecedorById(IdFornecedor) as OkObjectResult;
            FornecedorReadDTO fornecedorReadDTO = resultGetFornecedorById.Value as FornecedorReadDTO;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultGetFornecedorById.StatusCode);
            Assert.Equal(1, fornecedorReadDTO.Id);
            Assert.Equal("Dentinina", fornecedorReadDTO.NomeFantasia);
            Assert.Equal("Dentinina LTDA", fornecedorReadDTO.RazaoSocial);
            Assert.Equal("1234567891000", fornecedorReadDTO.Cnpj);
            Assert.Equal("Rua dos fundadores", fornecedorReadDTO.Endereco);
            Assert.Equal(16059746, fornecedorReadDTO.Cep);
            Assert.Equal("Brasil", fornecedorReadDTO.Pais);
            Assert.Equal("Birigui", fornecedorReadDTO.Cidade);
            Assert.Equal("Ipanema", fornecedorReadDTO.Bairro);
            Assert.Equal(5452, fornecedorReadDTO.Numero);
            Assert.Equal("SP", fornecedorReadDTO.Uf);
        }

        [Fact]
        public void TestGetFornecedores()
        {
            //Arrange
            FornecedorController fornecedorController = new(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            FornecedorWriteDTO fornecedorWriteDTO1 = _mapper.Map<FornecedorWriteDTO>(Dentinina);
            FornecedorWriteDTO fornecedorWriteDTO2 = _mapper.Map<FornecedorWriteDTO>(DentPlus);

            //Act
            var resultPostFornecedor1 = fornecedorController.PostFornecedor(fornecedorWriteDTO1) as CreatedAtActionResult;
            var resultPostFornecedor2 = fornecedorController.PostFornecedor(fornecedorWriteDTO2) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostFornecedor1.StatusCode);
            Assert.Equal((int)HttpStatusCode.Created, resultPostFornecedor2.StatusCode);

            //Act
            IEnumerable<FornecedorReadDTO> fornecedorReadDTO = fornecedorController.GetFornecedores();

            //Assert
            Assert.Equal(2, fornecedorReadDTO.Count());
        }

        [Fact]
        public void TestPutFornecedor()
        {
            //Arrange
            FornecedorController fornecedorController = new(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            FornecedorWriteDTO fornecedorWriteDTO = _mapper.Map<FornecedorWriteDTO>(Dentinina);

            //Act
            var resultPostFornecedor = fornecedorController.PostFornecedor(fornecedorWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostFornecedor.StatusCode);

            //Act
            int IdFornecedor = 1;
            var resultGetFornecedorById = fornecedorController.GetFornecedorById(IdFornecedor) as OkObjectResult;
            FornecedorReadDTO fornecedorReadDTO = resultGetFornecedorById.Value as FornecedorReadDTO;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultGetFornecedorById.StatusCode);
            Assert.Equal(1, fornecedorReadDTO.Id);
            Assert.Equal("Dentinina", fornecedorReadDTO.NomeFantasia);
            Assert.Equal("Dentinina LTDA", fornecedorReadDTO.RazaoSocial);
            Assert.Equal("1234567891000", fornecedorReadDTO.Cnpj);
            Assert.Equal("Rua dos fundadores", fornecedorReadDTO.Endereco);
            Assert.Equal(16059746, fornecedorReadDTO.Cep);
            Assert.Equal("Brasil", fornecedorReadDTO.Pais);
            Assert.Equal("Birigui", fornecedorReadDTO.Cidade);
            Assert.Equal("Ipanema", fornecedorReadDTO.Bairro);
            Assert.Equal(5452, fornecedorReadDTO.Numero);
            Assert.Equal("SP", fornecedorReadDTO.Uf);

            //Act
            fornecedorReadDTO.RazaoSocial = "Dentinina LTDA SA";

            var resultPutFornecedor = fornecedorController.PutFornecedor(IdFornecedor, fornecedorWriteDTO) as NoContentResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, resultPutFornecedor.StatusCode);
            Assert.Equal("Dentinina LTDA SA", fornecedorReadDTO.RazaoSocial);
        }

        [Fact]
        public void TestPatchFornecedor()
        {
            //Arrange
            FornecedorController fornecedorController = new(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            FornecedorWriteDTO fornecedorWriteDTO = _mapper.Map<FornecedorWriteDTO>(Dentinina);

            //Act
            var resultPostFornecedor = fornecedorController.PostFornecedor(fornecedorWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostFornecedor.StatusCode);

            //Act
            int IdFornecedor = 1;
            var resultGetFornecedorById = fornecedorController.GetFornecedorById(IdFornecedor) as OkObjectResult;
            FornecedorReadDTO fornecedorReadDTO = resultGetFornecedorById.Value as FornecedorReadDTO;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultGetFornecedorById.StatusCode);
            Assert.Equal(1, fornecedorReadDTO.Id);
            Assert.Equal("Dentinina", fornecedorReadDTO.NomeFantasia);
            Assert.Equal("Dentinina LTDA", fornecedorReadDTO.RazaoSocial);
            Assert.Equal("1234567891000", fornecedorReadDTO.Cnpj);
            Assert.Equal("Rua dos fundadores", fornecedorReadDTO.Endereco);
            Assert.Equal(16059746, fornecedorReadDTO.Cep);
            Assert.Equal("Brasil", fornecedorReadDTO.Pais);
            Assert.Equal("Birigui", fornecedorReadDTO.Cidade);
            Assert.Equal("Ipanema", fornecedorReadDTO.Bairro);
            Assert.Equal(5452, fornecedorReadDTO.Numero);
            Assert.Equal("SP", fornecedorReadDTO.Uf);

            //Act
            var jasonFornecedor = new JsonPatchDocument<FornecedorWriteDTO>();

            jasonFornecedor.Replace<string>(x => x.RazaoSocial, "Dentinina LTDA SA");
            
            var resultPutFornecedor = fornecedorController.PatchFornecedor(IdFornecedor, jasonFornecedor) as NoContentResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, resultPutFornecedor.StatusCode);
            Assert.Equal("Dentinina LTDA SA", fornecedorReadDTO.RazaoSocial);
        }

        [Fact]
        public void TestDeleteFornecedor()
        {
            //Arrange
            FornecedorController fornecedorController = new(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            FornecedorWriteDTO fornecedorWriteDTO = _mapper.Map<FornecedorWriteDTO>(Dentinina);

            //Act
            var resultPostFornecedor = fornecedorController.PostFornecedor(fornecedorWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostFornecedor.StatusCode);

            //Act
            int IdFornecedor = 1;
            IEnumerable<FornecedorReadDTO> fornecedorReadDTO = fornecedorController.GetFornecedores();

            //Assert
            Assert.Equal(1, fornecedorReadDTO.Count());

            //Act
            var resultDeleteFornecedor = fornecedorController.DeleteFornecedor(IdFornecedor) as NoContentResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, resultDeleteFornecedor.StatusCode);

            //Act
            fornecedorReadDTO = fornecedorController.GetFornecedores();

            //Assert
            Assert.Equal(0, fornecedorReadDTO.Count());
        }
    }
}