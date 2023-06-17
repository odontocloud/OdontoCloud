using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdontoCloud.Infrastructure.Profiles;
using System.Net;
using Assert = Xunit.Assert;
using OdontoCloud.Domain.Entities;
using OdontoCloud.Infrastructure.DTOs.Cliente;
using OdontoCloud.Controllers;
using OdontoCloud.InfrastructureTests.Utilitaries;
using Microsoft.AspNetCore.JsonPatch;

namespace OdontoCloud.InfrastructureTests.Controller
{
    [TestClass]
    public class ClienteControllerTests
    {
        Cliente clientePaulinPinho = new Cliente
        {
            CPF = "12345678910",
            RG = "12354646",
            Nome = "Paulin Pinho",
            DataNascimento = new DateTime(1995, 07, 08),
            EstadoCivil = EstadoCivilEnum.Solteiro.ToString(),
            Profissao = "Engenheiro",
            TelCelular = "(18) 999996662",
            TelResidencial = "(18) 36225987",
            IndicadoPor = "Danilin",
            DNLE = "Não sei o que é"
        };

        Cliente clienteDanilin = new Cliente
        {
            CPF = "98765432110",
            RG = "87464842",
            Nome = "Danilin",
            DataNascimento = new DateTime(1992, 11, 18)
        };

        private static IMapper _mapper;

        public ClienteControllerTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new ClienteProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public void TestPostCliente()
        {
            //Arrange
            ClienteController clienteController = new ClienteController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            ClienteWriteDTO clienteWriteDTO = _mapper.Map<ClienteWriteDTO>(clientePaulinPinho);

            //Act
            var resultPostCliente = clienteController.PostCliente(clienteWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostCliente.StatusCode);

            //Act
            int IdCliente = 1;
            var resultGetClienteById = clienteController.GetClienteById(IdCliente) as OkObjectResult;
            ClienteReadDTO clienteReadDTO = resultGetClienteById.Value as ClienteReadDTO;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultGetClienteById.StatusCode);
            Assert.Equal(1, clienteReadDTO.Id);
            Assert.Equal("12345678910", clienteReadDTO.CPF);
            Assert.Equal("12354646", clienteReadDTO.RG);
            Assert.Equal("Paulin Pinho", clienteReadDTO.Nome);
            Assert.Equal(new DateTime(1995, 07, 08), clienteReadDTO.DataNascimento);
            Assert.Equal("Solteiro", clienteReadDTO.EstadoCivil);
            Assert.Equal("Engenheiro", clienteReadDTO.Profissao);
            Assert.Equal("(18) 999996662", clienteReadDTO.TelCelular);
            Assert.Equal("(18) 36225987", clienteReadDTO.TelResidencial);
            Assert.Equal("Danilin", clienteReadDTO.IndicadoPor);
            Assert.Equal("Não sei o que é", clienteReadDTO.DNLE);
        }

        [Fact]
        public void TestGetClientes()
        {
            //Arrange
            ClienteController clienteController = new ClienteController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            ClienteWriteDTO clienteWriteDTO1 = _mapper.Map<ClienteWriteDTO>(clientePaulinPinho);
            ClienteWriteDTO clienteWriteDTO2 = _mapper.Map<ClienteWriteDTO>(clienteDanilin);

            //Act
            var resultPostCliente1 = clienteController.PostCliente(clienteWriteDTO1) as CreatedAtActionResult;
            var resultPostCliente2 = clienteController.PostCliente(clienteWriteDTO2) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostCliente1.StatusCode);
            Assert.Equal((int)HttpStatusCode.Created, resultPostCliente2.StatusCode);

            //Act
            IEnumerable<ClienteReadDTO> clienteReadDTO = clienteController.GetClientes();

            //Assert
            Assert.Equal(2, clienteReadDTO.Count());
        }

        [Fact]
        public void TestPutCliente()
        {
            //Arrange
            ClienteController clienteController = new ClienteController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            ClienteWriteDTO clienteWriteDTO = _mapper.Map<ClienteWriteDTO>(clientePaulinPinho);

            //Act
            var resultPostCliente = clienteController.PostCliente(clienteWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostCliente.StatusCode);

            //Act
            int IdCliente = 1;
            var resultGetClienteById = clienteController.GetClienteById(IdCliente) as OkObjectResult;
            ClienteReadDTO clienteReadDTO = resultGetClienteById.Value as ClienteReadDTO;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultGetClienteById.StatusCode);
            Assert.Equal(1, clienteReadDTO.Id);
            Assert.Equal("12345678910", clienteReadDTO.CPF);
            Assert.Equal("12354646", clienteReadDTO.RG);
            Assert.Equal("Paulin Pinho", clienteReadDTO.Nome);
            Assert.Equal(new DateTime(1995, 07, 08), clienteReadDTO.DataNascimento);
            Assert.Equal("Solteiro", clienteReadDTO.EstadoCivil);
            Assert.Equal("Engenheiro", clienteReadDTO.Profissao);
            Assert.Equal("(18) 999996662", clienteReadDTO.TelCelular);
            Assert.Equal("(18) 36225987", clienteReadDTO.TelResidencial);
            Assert.Equal("Danilin", clienteReadDTO.IndicadoPor);
            Assert.Equal("Não sei o que é", clienteReadDTO.DNLE);

            //Act
            clienteReadDTO.EstadoCivil = "Casado";
            clienteReadDTO.IndicadoPor = "Eduardo";
            clienteReadDTO.Profissao = "Engenheiro Civil";

            var resultPutCliente = clienteController.PutCliente(IdCliente, clienteWriteDTO) as NoContentResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, resultPutCliente.StatusCode);
            Assert.Equal("Casado", clienteReadDTO.EstadoCivil);
            Assert.Equal("Engenheiro Civil", clienteReadDTO.Profissao);
            Assert.Equal("Eduardo", clienteReadDTO.IndicadoPor);
        }

        [Fact]
        public void TestPatchCliente()
        {
            //Arrange
            ClienteController clienteController = new ClienteController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            ClienteWriteDTO clienteWriteDTO = _mapper.Map<ClienteWriteDTO>(clientePaulinPinho);

            //Act
            var resultPostCliente = clienteController.PostCliente(clienteWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostCliente.StatusCode);

            //Act
            int IdCliente = 1;
            var resultGetClienteById = clienteController.GetClienteById(IdCliente) as OkObjectResult;
            ClienteReadDTO clienteReadDTO = resultGetClienteById.Value as ClienteReadDTO;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultGetClienteById.StatusCode);
            Assert.Equal(1, clienteReadDTO.Id);
            Assert.Equal("12345678910", clienteReadDTO.CPF);
            Assert.Equal("12354646", clienteReadDTO.RG);
            Assert.Equal("Paulin Pinho", clienteReadDTO.Nome);
            Assert.Equal(new DateTime(1995, 07, 08), clienteReadDTO.DataNascimento);
            Assert.Equal("Solteiro", clienteReadDTO.EstadoCivil);
            Assert.Equal("Engenheiro", clienteReadDTO.Profissao);
            Assert.Equal("(18) 999996662", clienteReadDTO.TelCelular);
            Assert.Equal("(18) 36225987", clienteReadDTO.TelResidencial);
            Assert.Equal("Danilin", clienteReadDTO.IndicadoPor);
            Assert.Equal("Não sei o que é", clienteReadDTO.DNLE);

            //Act
            var jasonCliente = new JsonPatchDocument<ClienteWriteDTO>();

            jasonCliente.Replace<string>(x => x.Nome, "Edu");
            
            var resultPutCliente = clienteController.PatchCliente(IdCliente, jasonCliente) as NoContentResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, resultPutCliente.StatusCode);
            Assert.Equal("Viuvo", clienteReadDTO.EstadoCivil);
        }

        [Fact]
        public void TestDeleteCliente()
        {
            //Arrange
            ClienteController clienteController = new ClienteController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            ClienteWriteDTO clienteWriteDTO = _mapper.Map<ClienteWriteDTO>(clientePaulinPinho);

            //Act
            var resultPostCliente = clienteController.PostCliente(clienteWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostCliente.StatusCode);

            //Act
            int IdCliente = 1;
            IEnumerable<ClienteReadDTO> clienteReadDTO = clienteController.GetClientes();

            //Assert
            Assert.Equal(1, clienteReadDTO.Count());

            //Act
            var resultDeleteCliente = clienteController.DeleteCliente(IdCliente) as NoContentResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, resultDeleteCliente.StatusCode);

            //Act
            clienteReadDTO = clienteController.GetClientes();

            //Assert
            Assert.Equal(0, clienteReadDTO.Count());
        }
    }
}