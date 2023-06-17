using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdontoCloud.Infrastructure.Profiles;
using System.Net;
using Assert = Xunit.Assert;
using OdontoCloud.Domain.Entities;
using OdontoCloud.Controllers;
using OdontoCloud.InfrastructureTests.Utilitaries;
using Microsoft.AspNetCore.JsonPatch;
using OdontoCloud.Infrastructure.DTOs.Endereco;

namespace OdontoCloud.InfrastructureTests.Controller
{
    [TestClass]
    public class EnderecoControllerTests
    {
        Endereco enderecoRuaDoFico = new Endereco
        {
            IdCliente = 1,
            DescricaoEndereco = "Rua do Fico",
            Numero = "1345",
            Bairro = "Ipanema",
            Cidade = "Araçatuba",
            UF = "SP",
            Pais = "Brasil",
            Cep = "16052312",
            Tipo = TipoEndereco.Residencial.ToString(),
            Complemento = "Perto do Rondon"
        };

        Endereco enderecoAvenidaPrestesMaia = new Endereco
        {
            IdCliente = 2,
            DescricaoEndereco = "Avenida Prestes Maia",
            Numero = "623",
            Bairro = "Dona Amália",
            Cidade = "Araçatuba",
            UF = "SP",
            Pais = "Brasil",
            Cep = "16052412",
            Tipo = TipoEndereco.Comercial.ToString()
        };

        private static IMapper _mapper;

        public EnderecoControllerTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new EnderecoProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public void TestPostEndereco()
        {
            //Arrange
            EnderecoController EnderecoController = new EnderecoController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            EnderecoWriteDTO enderecoWriteDTO = _mapper.Map<EnderecoWriteDTO>(enderecoRuaDoFico);

            //Act
            var resultPostEndereco = EnderecoController.PostEndereco(enderecoWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostEndereco.StatusCode);

            //Act
            int IdEndereco = 1;
            var resultGetEnderecoById = EnderecoController.GetEnderecoById(IdEndereco) as OkObjectResult;
            EnderecoReadDTO enderecoReadDTO = resultGetEnderecoById.Value as EnderecoReadDTO;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultGetEnderecoById.StatusCode);
            Assert.Equal(1, enderecoReadDTO.Id);
            Assert.Equal(1, enderecoReadDTO.IdCliente);
            Assert.Equal("Rua do Fico", enderecoReadDTO.DescricaoEndereco);
            Assert.Equal("1345", enderecoReadDTO.Numero);
            Assert.Equal("Ipanema", enderecoReadDTO.Bairro);
            Assert.Equal("Araçatuba", enderecoReadDTO.Cidade);
            Assert.Equal("SP", enderecoReadDTO.UF);
            Assert.Equal("Brasil", enderecoReadDTO.Pais);
            Assert.Equal("16052312", enderecoReadDTO.Cep);
            Assert.Equal("Residencial", enderecoReadDTO.Tipo);
            Assert.Equal("Perto do Rondon", enderecoReadDTO.Complemento);
        }

        [Fact]
        public void TestGetEnderecos()
        {
            //Arrange
            EnderecoController EnderecoController = new EnderecoController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            EnderecoWriteDTO enderecoWriteDTO1 = _mapper.Map<EnderecoWriteDTO>(enderecoRuaDoFico);
            EnderecoWriteDTO enderecoWriteDTO2 = _mapper.Map<EnderecoWriteDTO>(enderecoAvenidaPrestesMaia);

            //Act
            var resultPostEndereco1 = EnderecoController.PostEndereco(enderecoWriteDTO1) as CreatedAtActionResult;
            var resultPostEndereco2 = EnderecoController.PostEndereco(enderecoWriteDTO2) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostEndereco1.StatusCode);
            Assert.Equal((int)HttpStatusCode.Created, resultPostEndereco2.StatusCode);

            //Act
            IEnumerable<EnderecoReadDTO> enderecoReadDTO = EnderecoController.GetEnderecos();

            //Assert
            Assert.Equal(2, enderecoReadDTO.Count());
        }

        [Fact]
        public void TestPutCliente()
        {
            //Arrange
            EnderecoController EnderecoController = new EnderecoController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            EnderecoWriteDTO enderecoWriteDTO = _mapper.Map<EnderecoWriteDTO>(enderecoRuaDoFico);

            //Act
            var resultPostEndereco = EnderecoController.PostEndereco(enderecoWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostEndereco.StatusCode);

            //Act
            int IdEndereco = 1;
            var resultGetClienteById = EnderecoController.GetEnderecoById(IdEndereco) as OkObjectResult;
            EnderecoReadDTO enderecoReadDTO = resultGetClienteById.Value as EnderecoReadDTO;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultGetClienteById.StatusCode);
            Assert.Equal(1, enderecoReadDTO.Id);
            Assert.Equal(1, enderecoReadDTO.IdCliente);
            Assert.Equal("Rua do Fico", enderecoReadDTO.DescricaoEndereco);
            Assert.Equal("1345", enderecoReadDTO.Numero);
            Assert.Equal("Ipanema", enderecoReadDTO.Bairro);
            Assert.Equal("Araçatuba", enderecoReadDTO.Cidade);
            Assert.Equal("SP", enderecoReadDTO.UF);
            Assert.Equal("Brasil", enderecoReadDTO.Pais);
            Assert.Equal("16052312", enderecoReadDTO.Cep);
            Assert.Equal("Residencial", enderecoReadDTO.Tipo);
            Assert.Equal("Perto do Rondon", enderecoReadDTO.Complemento);

            //Act
            enderecoReadDTO.Tipo = "Comercial";
            enderecoReadDTO.Complemento = "Perto do Rondon do Ipanema";

            var resultPutEndereco = EnderecoController.PutEndereco(IdEndereco, enderecoWriteDTO) as NoContentResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, resultPutEndereco.StatusCode);
            Assert.Equal("Comercial", enderecoReadDTO.Tipo);
            Assert.Equal("Perto do Rondon do Ipanema", enderecoReadDTO.Complemento);
        }

        [Fact]
        public void TestPatchEndereco()
        {
            //Arrange
            EnderecoController EnderecoController = new EnderecoController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            EnderecoWriteDTO enderecoWriteDTO = _mapper.Map<EnderecoWriteDTO>(enderecoRuaDoFico);

            //Act
            var resultPostEndereco = EnderecoController.PostEndereco(enderecoWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostEndereco.StatusCode);

            //Act
            int IdEndereco = 1;
            var resultGetEnderecoById = EnderecoController.GetEnderecoById(IdEndereco) as OkObjectResult;
            EnderecoReadDTO enderecoReadDTO = resultGetEnderecoById.Value as EnderecoReadDTO;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultGetEnderecoById.StatusCode);
            Assert.Equal(1, enderecoReadDTO.Id);
            Assert.Equal(1, enderecoReadDTO.IdCliente);
            Assert.Equal("Rua do Fico", enderecoReadDTO.DescricaoEndereco);
            Assert.Equal("1345", enderecoReadDTO.Numero);
            Assert.Equal("Ipanema", enderecoReadDTO.Bairro);
            Assert.Equal("Araçatuba", enderecoReadDTO.Cidade);
            Assert.Equal("SP", enderecoReadDTO.UF);
            Assert.Equal("Brasil", enderecoReadDTO.Pais);
            Assert.Equal("16052312", enderecoReadDTO.Cep);
            Assert.Equal("Residencial", enderecoReadDTO.Tipo);
            Assert.Equal("Perto do Rondon", enderecoReadDTO.Complemento);

            //Act
            var jasonEndereco = new JsonPatchDocument<EnderecoWriteDTO>();

            jasonEndereco.Replace<string>(x => x.Numero, "1234");
            
            var resultPutEndereco = EnderecoController.PatchEndereco(IdEndereco, jasonEndereco) as NoContentResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, resultPutEndereco.StatusCode);
            Assert.Equal("1234", enderecoReadDTO.Numero);
        }

        [Fact]
        public void TestDeleteEndereco()
        {
            //Arrange
            EnderecoController EnderecoController = new EnderecoController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            EnderecoWriteDTO enderecoWriteDTO = _mapper.Map<EnderecoWriteDTO>(enderecoRuaDoFico);

            //Act
            var resultPostEndereco = EnderecoController.PostEndereco(enderecoWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostEndereco.StatusCode);

            //Act
            int IdEndereco = 1;
            IEnumerable<EnderecoReadDTO> enderecoReadDTO = EnderecoController.GetEnderecos();

            //Assert
            Assert.Equal(1, enderecoReadDTO.Count());

            //Act
            var resultDeleteEndereco = EnderecoController.DeleteEndereco(IdEndereco) as NoContentResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, resultDeleteEndereco.StatusCode);

            //Act
            enderecoReadDTO = EnderecoController.GetEnderecos();

            //Assert
            Assert.Equal(0, enderecoReadDTO.Count());
        }
    }
}