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
using OdontoCloud.Infrastructure.DTOs.Funcionario;

namespace OdontoCloud.InfrastructureTests.Controller
{
    [TestClass]
    public class FuncionarioControllerTests
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

        private static IMapper _mapper;

        public FuncionarioControllerTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new FuncionarioProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public void TestPostFuncionario()
        {
            //Arrange
            FuncionarioController funcionarioController = new FuncionarioController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            FuncionarioWriteDTO funcionarioWriteDTO = _mapper.Map<FuncionarioWriteDTO>(funcionarioPaulinPinho);

            //Act
            var resultPostFuncionario = funcionarioController.PostFuncionario(funcionarioWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostFuncionario.StatusCode);

            //Act
            int IdFuncionario = 1;
            var resultGetFuncionarioById = funcionarioController.GetFuncionarioById(IdFuncionario) as OkObjectResult;
            FuncionarioReadDTO funcionarioReadDTO = resultGetFuncionarioById.Value as FuncionarioReadDTO;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultGetFuncionarioById.StatusCode);
            Assert.Equal(1, funcionarioReadDTO.Id);
            Assert.Equal("12345678910", funcionarioReadDTO.CPF);
            Assert.Equal("12354646", funcionarioReadDTO.RG);
            Assert.Equal("Paulin Pinho", funcionarioReadDTO.Nome);
            Assert.Equal(new DateTime(1995, 07, 08), funcionarioReadDTO.DataNascimento);
            Assert.Equal("Solteiro", funcionarioReadDTO.EstadoCivil);
            Assert.Equal("(18) 999996662", funcionarioReadDTO.TelCelular);
            Assert.Equal("(18) 36225987", funcionarioReadDTO.TelResidencial);
            Assert.Equal("Dentista", funcionarioReadDTO.Cargo);
            Assert.Equal(3000, funcionarioReadDTO.Salario);
        }

        [Fact]
        public void TestGetFuncionarios()
        {
            //Arrange
            FuncionarioController funcionarioController = new FuncionarioController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            FuncionarioWriteDTO funcionarioWriteDTO1 = _mapper.Map<FuncionarioWriteDTO>(funcionarioPaulinPinho);
            FuncionarioWriteDTO funcionarioWriteDTO2 = _mapper.Map<FuncionarioWriteDTO>(funcionarioDanilin);

            //Act
            var resultPostFuncionario1 = funcionarioController.PostFuncionario(funcionarioWriteDTO1) as CreatedAtActionResult;
            var resultPostFuncionario2 = funcionarioController.PostFuncionario(funcionarioWriteDTO2) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostFuncionario1.StatusCode);
            Assert.Equal((int)HttpStatusCode.Created, resultPostFuncionario2.StatusCode);

            //Act
            IEnumerable<FuncionarioReadDTO> funcionarioReadDTO = funcionarioController.GetFuncionarios();

            //Assert
            Assert.Equal(2, funcionarioReadDTO.Count());
        }

        [Fact]
        public void TestPutFuncionario()
        {
            //Arrange
            FuncionarioController funcionarioController = new FuncionarioController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            FuncionarioWriteDTO funcionarioWriteDTO = _mapper.Map<FuncionarioWriteDTO>(funcionarioPaulinPinho);

            //Act
            var resultPostFuncionario = funcionarioController.PostFuncionario(funcionarioWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostFuncionario.StatusCode);

            //Act
            int IdFuncionario = 1;
            var resultGetFuncionarioById = funcionarioController.GetFuncionarioById(IdFuncionario) as OkObjectResult;
            FuncionarioReadDTO funcionarioReadDTO = resultGetFuncionarioById.Value as FuncionarioReadDTO;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultGetFuncionarioById.StatusCode);
            Assert.Equal(1, funcionarioReadDTO.Id);
            Assert.Equal("12345678910", funcionarioReadDTO.CPF);
            Assert.Equal("12354646", funcionarioReadDTO.RG);
            Assert.Equal("Paulin Pinho", funcionarioReadDTO.Nome);
            Assert.Equal(new DateTime(1995, 07, 08), funcionarioReadDTO.DataNascimento);
            Assert.Equal("Solteiro", funcionarioReadDTO.EstadoCivil);
            Assert.Equal("(18) 999996662", funcionarioReadDTO.TelCelular);
            Assert.Equal("(18) 36225987", funcionarioReadDTO.TelResidencial);
            Assert.Equal("Dentista", funcionarioReadDTO.Cargo);
            Assert.Equal(3000, funcionarioReadDTO.Salario);

            //Act
            funcionarioReadDTO.EstadoCivil = "Casado";
            funcionarioReadDTO.Cargo = "Auxiliar";
            funcionarioReadDTO.Salario = 1500;

            var resultPutFuncionario = funcionarioController.PutFuncionario(IdFuncionario, funcionarioWriteDTO) as NoContentResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, resultPutFuncionario.StatusCode);
            Assert.Equal("Casado", funcionarioReadDTO.EstadoCivil);
            Assert.Equal("Auxiliar", funcionarioReadDTO.Cargo);
            Assert.Equal(1500, funcionarioReadDTO.Salario);
        }

        [Fact]
        public void TestPatchFuncionario()
        {
            //Arrange
            FuncionarioController funcionarioController = new FuncionarioController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            FuncionarioWriteDTO funcionarioWriteDTO = _mapper.Map<FuncionarioWriteDTO>(funcionarioPaulinPinho);

            //Act
            var resultPostFuncionario = funcionarioController.PostFuncionario(funcionarioWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostFuncionario.StatusCode);

            //Act
            int IdFuncionario = 1;
            var resultGetFuncionarioById = funcionarioController.GetFuncionarioById(IdFuncionario) as OkObjectResult;
            FuncionarioReadDTO funcionarioReadDTO = resultGetFuncionarioById.Value as FuncionarioReadDTO;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultGetFuncionarioById.StatusCode);
            Assert.Equal(1, funcionarioReadDTO.Id);
            Assert.Equal("12345678910", funcionarioReadDTO.CPF);
            Assert.Equal("12354646", funcionarioReadDTO.RG);
            Assert.Equal("Paulin Pinho", funcionarioReadDTO.Nome);
            Assert.Equal(new DateTime(1995, 07, 08), funcionarioReadDTO.DataNascimento);
            Assert.Equal("Solteiro", funcionarioReadDTO.EstadoCivil);
            Assert.Equal("(18) 999996662", funcionarioReadDTO.TelCelular);
            Assert.Equal("(18) 36225987", funcionarioReadDTO.TelResidencial);
            Assert.Equal("Dentista", funcionarioReadDTO.Cargo);
            Assert.Equal(3000, funcionarioReadDTO.Salario);

            //Act
            var jasonFuncionario = new JsonPatchDocument<FuncionarioWriteDTO>();

            jasonFuncionario.Replace<string>(x => x.EstadoCivil, "Viuvo");
            
            var resultPutFuncionario = funcionarioController.PatchFuncionario(IdFuncionario, jasonFuncionario) as NoContentResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, resultPutFuncionario.StatusCode);
            Assert.Equal("Viuvo", funcionarioReadDTO.EstadoCivil);
        }

        [Fact]
        public void TestDeleteFuncionario()
        {
            //Arrange
            FuncionarioController funcionarioController = new FuncionarioController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            FuncionarioWriteDTO funcionarioWriteDTO = _mapper.Map<FuncionarioWriteDTO>(funcionarioPaulinPinho);

            //Act
            var resultPostFuncionario = funcionarioController.PostFuncionario(funcionarioWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostFuncionario.StatusCode);

            //Act
            int IdFuncionario = 1;
            IEnumerable<FuncionarioReadDTO> funcionarioReadDTO = funcionarioController.GetFuncionarios();

            //Assert
            Assert.Equal(1, funcionarioReadDTO.Count());

            //Act
            var resultDeleteFuncionario = funcionarioController.DeleteFuncionario(IdFuncionario) as NoContentResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, resultDeleteFuncionario.StatusCode);

            //Act
            funcionarioReadDTO = funcionarioController.GetFuncionarios();

            //Assert
            Assert.Equal(0, funcionarioReadDTO.Count());
        }
    }
}