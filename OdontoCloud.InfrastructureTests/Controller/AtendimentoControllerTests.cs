using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdontoCloud.Infrastructure.Profiles;
using System.Net;
using Assert = Xunit.Assert;
using OdontoCloud.Domain.Entities;
using OdontoCloud.Infrastructure.DTOs.Atendimento;
using OdontoCloud.Controllers;
using OdontoCloud.InfrastructureTests.Utilitaries;
using Microsoft.AspNetCore.JsonPatch;

namespace OdontoCloud.InfrastructureTests.Controller
{
    [TestClass]
    public class AtendimentoControllerTests
    {
        Atendimento primeiroAtendimento = new Atendimento
        {
            Descricao = "Limpeza",
            Data = new DateTime(2023, 04, 28),
            IdCliente = 1,
            IdFuncionario = 1,
            Situacao = "Finalizado",
            TempoDuracao = 60,
            Valor = 100
        };

        Atendimento segundoAtendimento = new Atendimento
        {
            Descricao = "Obturação",
            Data = new DateTime(2023, 04, 28),
            IdCliente = 1,
            IdFuncionario = 1,
            Situacao = "Finalizado",
            TempoDuracao = 90,
            Valor = 150
        };

        private static IMapper _mapper;

        public AtendimentoControllerTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AtendimentoProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public void TestPostAtendimento()
        {
            //Arrange
            AtendimentoController atendimentoController = new AtendimentoController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            AtendimentoWriteDTO atendimentoWriteDTO = _mapper.Map<AtendimentoWriteDTO>(primeiroAtendimento);

            //Act
            var resultPostAtendimento = atendimentoController.PostAtendimento(atendimentoWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostAtendimento.StatusCode);

            //Act
            int IdAtendimento = 1;
            var resultGetAtendimentoById = atendimentoController.GetAtendimentoById(IdAtendimento) as OkObjectResult;
            AtendimentoReadDTO atendimentoReadDTO = resultGetAtendimentoById.Value as AtendimentoReadDTO;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultGetAtendimentoById.StatusCode);
            Assert.Equal(1, atendimentoReadDTO.Id);
            Assert.Equal("Limpeza", atendimentoReadDTO.Descricao);
            Assert.Equal(new DateTime(2023, 04, 28), atendimentoReadDTO.Data);
            Assert.Equal(1, atendimentoReadDTO.IdCliente);
            Assert.Equal(1, atendimentoReadDTO.IdFuncionario);
            Assert.Equal(60, atendimentoReadDTO.TempoDuracao);
            Assert.Equal(100, atendimentoReadDTO.Valor);
            Assert.Equal("Finalizado", atendimentoReadDTO.Situacao);
        }

        [Fact]
        public void TestGetAtendimentos()
        {
            //Arrange
            AtendimentoController atendimentoController = new AtendimentoController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            AtendimentoWriteDTO atendimentoWriteDTO1 = _mapper.Map<AtendimentoWriteDTO>(primeiroAtendimento);
            AtendimentoWriteDTO atendimentoWriteDTO2 = _mapper.Map<AtendimentoWriteDTO>(segundoAtendimento);

            //Act
            var resultPostAtendimento1 = atendimentoController.PostAtendimento(atendimentoWriteDTO1) as CreatedAtActionResult;
            var resultPostAtendimento2 = atendimentoController.PostAtendimento(atendimentoWriteDTO2) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostAtendimento1.StatusCode);
            Assert.Equal((int)HttpStatusCode.Created, resultPostAtendimento2.StatusCode);

            //Act
            IEnumerable<AtendimentoReadDTO> atendimentoReadDTO = atendimentoController.GetAtendimentos();

            //Assert
            Assert.Equal(2, atendimentoReadDTO.Count());
        }

        [Fact]
        public void TestPutAtendimento()
        {
            //Arrange
            AtendimentoController atendimentoController = new AtendimentoController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            AtendimentoWriteDTO atendimentoWriteDTO = _mapper.Map<AtendimentoWriteDTO>(primeiroAtendimento);

            //Act
            var resultPostAtendimento = atendimentoController.PostAtendimento(atendimentoWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostAtendimento.StatusCode);

            //Act
            int IdAtendimento = 1;
            var resultGetAtendimentoById = atendimentoController.GetAtendimentoById(IdAtendimento) as OkObjectResult;
            AtendimentoReadDTO atendimentoReadDTO = resultGetAtendimentoById.Value as AtendimentoReadDTO;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultGetAtendimentoById.StatusCode);
            Assert.Equal(1, atendimentoReadDTO.Id);
            Assert.Equal("Limpeza", atendimentoReadDTO.Descricao);
            Assert.Equal(new DateTime(2023, 04, 28), atendimentoReadDTO.Data);
            Assert.Equal(1, atendimentoReadDTO.IdCliente);
            Assert.Equal(1, atendimentoReadDTO.IdFuncionario);
            Assert.Equal(60, atendimentoReadDTO.TempoDuracao);
            Assert.Equal(100, atendimentoReadDTO.Valor);
            Assert.Equal("Finalizado", atendimentoReadDTO.Situacao);

            //Act
            atendimentoReadDTO.Situacao = "Andamento";
            atendimentoReadDTO.Valor = 150;

            var resultPutAtendimento = atendimentoController.PutAtendimento(IdAtendimento, atendimentoWriteDTO) as NoContentResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, resultPutAtendimento.StatusCode);
            Assert.Equal("Andamento", atendimentoReadDTO.Situacao);
            Assert.Equal(150, atendimentoReadDTO.Valor);
        }

        [Fact]
        public void TestPatchAtendimento()
        {
            //Arrange
            AtendimentoController atendimentoController = new AtendimentoController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            AtendimentoWriteDTO atendimentoWriteDTO = _mapper.Map<AtendimentoWriteDTO>(primeiroAtendimento);

            //Act
            var resultPostAtendimento = atendimentoController.PostAtendimento(atendimentoWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostAtendimento.StatusCode);

            //Act
            int IdAtendimento = 1;
            var resultGetAtendimentoById = atendimentoController.GetAtendimentoById(IdAtendimento) as OkObjectResult;
            AtendimentoReadDTO atendimentoReadDTO = resultGetAtendimentoById.Value as AtendimentoReadDTO;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultGetAtendimentoById.StatusCode);
            Assert.Equal(1, atendimentoReadDTO.Id);
            Assert.Equal("Limpeza", atendimentoReadDTO.Descricao);
            Assert.Equal(new DateTime(1995, 04, 28), atendimentoReadDTO.Data);
            Assert.Equal(1, atendimentoReadDTO.IdCliente);
            Assert.Equal(1, atendimentoReadDTO.IdFuncionario);
            Assert.Equal(60, atendimentoReadDTO.TempoDuracao);
            Assert.Equal(100, atendimentoReadDTO.Valor);
            Assert.Equal("Finalizado", atendimentoReadDTO.Situacao);

            //Act
            var jasonAtendimento = new JsonPatchDocument<AtendimentoWriteDTO>();

            jasonAtendimento.Replace<string>(x => x.Situacao, "Andamento");
            
            var resultPutAtendimento = atendimentoController.PatchAtendimento(IdAtendimento, jasonAtendimento) as NoContentResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, resultPutAtendimento.StatusCode);
            Assert.Equal("Andamento", atendimentoReadDTO.Situacao);
        }

        [Fact]
        public void TestDeleteAtendimento()
        {
            //Arrange
            AtendimentoController atendimentoController = new AtendimentoController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            AtendimentoWriteDTO atendimentoWriteDTO = _mapper.Map<AtendimentoWriteDTO>(primeiroAtendimento);

            //Act
            var resultPostAtendimento = atendimentoController.PostAtendimento(atendimentoWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostAtendimento.StatusCode);

            //Act
            int IdAtendimento = 1;
            IEnumerable<AtendimentoReadDTO> atendimentoReadDTO = atendimentoController.GetAtendimentos();

            //Assert
            Assert.Equal(1, atendimentoReadDTO.Count());

            //Act
            var resultDeleteAtendimento = atendimentoController.DeleteAtendimento(IdAtendimento) as NoContentResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, resultDeleteAtendimento.StatusCode);

            //Act
            atendimentoReadDTO = atendimentoController.GetAtendimentos();

            //Assert
            Assert.Equal(0, atendimentoReadDTO.Count());
        }
    }
}