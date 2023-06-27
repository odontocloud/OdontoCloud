using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdontoCloud.Infrastructure.Profiles;
using System.Net;
using Assert = Xunit.Assert;
using OdontoCloud.Domain.Entities;
using OdontoCloud.Infrastructure.DTOs.DetalheAtendimento;
using OdontoCloud.Controllers;
using OdontoCloud.InfrastructureTests.Utilitaries;
using Microsoft.AspNetCore.JsonPatch;

namespace OdontoCloud.InfrastructureTests.Controller
{
    [TestClass]
    public class DetalheAtendimentoControllerTests
    {
        DetalheAtendimento primeiroDetalheAtendimento = new DetalheAtendimento
        {
            IdAtendimento = 1,
            IdItem = 1,
            QuantidadeItem = 10
        };

        DetalheAtendimento segundoDetalheAtendimento = new DetalheAtendimento
        {
            IdAtendimento = 2,
            IdItem = 2,
            QuantidadeItem = 6
        };

        private static IMapper _mapper;

        public DetalheAtendimentoControllerTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new DetalheAtendimentoProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public void TestPostDetalheAtendimento()
        {
            //Arrange
            DetalheAtendimentoController detalheAtendimentoController = new DetalheAtendimentoController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            DetalheAtendimentoWriteDTO detalheAtendimentoWriteDTO = _mapper.Map<DetalheAtendimentoWriteDTO>(primeiroDetalheAtendimento);

            //Act
            var resultPostDetalheAtendimento = detalheAtendimentoController.PostDetalheAtendimento(detalheAtendimentoWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostDetalheAtendimento.StatusCode);

            //Act
            int IdDetalheAtendimento = 1;
            var resultGetDetalheAtendimentoById = detalheAtendimentoController.GetDetalheAtendimentoById(IdDetalheAtendimento) as OkObjectResult;
            DetalheAtendimentoReadDTO detalheAtendimentoReadDTO = resultGetDetalheAtendimentoById.Value as DetalheAtendimentoReadDTO;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultGetDetalheAtendimentoById.StatusCode);
            Assert.Equal(1, detalheAtendimentoReadDTO.Id);
            Assert.Equal(1, detalheAtendimentoReadDTO.IdAtendimento);
            Assert.Equal(1, detalheAtendimentoReadDTO.IdItem);
            Assert.Equal(10, detalheAtendimentoReadDTO.QuantidadeItem);
        }

        [Fact]
        public void TestGetDetalhesAtendimento()
        {
            //Arrange
            DetalheAtendimentoController detalheAtendimentoController = new DetalheAtendimentoController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            DetalheAtendimentoWriteDTO detalheAtendimentoWriteDTO1 = _mapper.Map<DetalheAtendimentoWriteDTO>(primeiroDetalheAtendimento);
            DetalheAtendimentoWriteDTO detalheAtendimentoWriteDTO2 = _mapper.Map<DetalheAtendimentoWriteDTO>(segundoDetalheAtendimento);

            //Act
            var resultPostDetalheAtendimento1 = detalheAtendimentoController.PostDetalheAtendimento(detalheAtendimentoWriteDTO1) as CreatedAtActionResult;
            var resultPostDetalheAtendimento2 = detalheAtendimentoController.PostDetalheAtendimento(detalheAtendimentoWriteDTO2) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostDetalheAtendimento1.StatusCode);
            Assert.Equal((int)HttpStatusCode.Created, resultPostDetalheAtendimento2.StatusCode);

            //Act
            IEnumerable<DetalheAtendimentoReadDTO> detalheAtendimentoReadDTO = detalheAtendimentoController.GetDetalhesAtendimento();

            //Assert
            Assert.Equal(2, detalheAtendimentoReadDTO.Count());
        }

        [Fact]
        public void TestPutDetalheAtendimento()
        {
            //Arrange
            DetalheAtendimentoController detalheAtendimentoController = new DetalheAtendimentoController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            DetalheAtendimentoWriteDTO detalheAtendimentoWriteDTO = _mapper.Map<DetalheAtendimentoWriteDTO>(primeiroDetalheAtendimento);

            //Act
            var resultPostDetalheAtendimento = detalheAtendimentoController.PostDetalheAtendimento(detalheAtendimentoWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostDetalheAtendimento.StatusCode);

            //Act
            int IdDetalheAtendimento = 1;
            var resultGetDetalheAtendimentoById = detalheAtendimentoController.GetDetalheAtendimentoById(IdDetalheAtendimento) as OkObjectResult;
            DetalheAtendimentoReadDTO detalheAtendimentoReadDTO = resultGetDetalheAtendimentoById.Value as DetalheAtendimentoReadDTO;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultGetDetalheAtendimentoById.StatusCode);
            Assert.Equal(1, detalheAtendimentoReadDTO.Id);
            Assert.Equal(1, detalheAtendimentoReadDTO.IdAtendimento);
            Assert.Equal(1, detalheAtendimentoReadDTO.IdItem);
            Assert.Equal(10, detalheAtendimentoReadDTO.QuantidadeItem);

            //Act
            detalheAtendimentoReadDTO.QuantidadeItem = 15;

            var resultPutDetalheAtendimento = detalheAtendimentoController.PutDetalheAtendimento(IdDetalheAtendimento, detalheAtendimentoWriteDTO) as NoContentResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, resultPutDetalheAtendimento.StatusCode);
            Assert.Equal(15, detalheAtendimentoReadDTO.QuantidadeItem);
        }

        [Fact]
        public void TestPatchDetalheAtendimento()
        {
            //Arrange
            DetalheAtendimentoController detalheAtendimentoController = new DetalheAtendimentoController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            DetalheAtendimentoWriteDTO detalheAtendimentoWriteDTO = _mapper.Map<DetalheAtendimentoWriteDTO>(primeiroDetalheAtendimento);

            //Act
            var resultPostDetalheAtendimento = detalheAtendimentoController.PostDetalheAtendimento(detalheAtendimentoWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostDetalheAtendimento.StatusCode);

            //Act
            int IdDetalheAtendimento = 1;
            var resultGetDetalheAtendimentoById = detalheAtendimentoController.GetDetalheAtendimentoById(IdDetalheAtendimento) as OkObjectResult;
            DetalheAtendimentoReadDTO detalheAtendimentoReadDTO = resultGetDetalheAtendimentoById.Value as DetalheAtendimentoReadDTO;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultGetDetalheAtendimentoById.StatusCode);
            Assert.Equal(1, detalheAtendimentoReadDTO.Id);
            Assert.Equal(1, detalheAtendimentoReadDTO.IdAtendimento);
            Assert.Equal(1, detalheAtendimentoReadDTO.IdItem);
            Assert.Equal(10, detalheAtendimentoReadDTO.QuantidadeItem);

            //Act
            var jasonDetalheAtendimento = new JsonPatchDocument<DetalheAtendimentoWriteDTO>();

            jasonDetalheAtendimento.Replace(x => x.QuantidadeItem, 15);
            
            var resultPutDetalheAtendimento = detalheAtendimentoController.PatchDetalheAtendimento(IdDetalheAtendimento, jasonDetalheAtendimento) as NoContentResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, resultPutDetalheAtendimento.StatusCode);
            Assert.Equal(15, detalheAtendimentoReadDTO.QuantidadeItem);
        }

        [Fact]
        public void TestDeleteDetalheAtendimento()
        {
            //Arrange
            DetalheAtendimentoController detalheAtendimentoController = new DetalheAtendimentoController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            DetalheAtendimentoWriteDTO detalheAtendimentoWriteDTO = _mapper.Map<DetalheAtendimentoWriteDTO>(primeiroDetalheAtendimento);

            //Act
            var resultPostDetalheAtendimento = detalheAtendimentoController.PostDetalheAtendimento(detalheAtendimentoWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostDetalheAtendimento.StatusCode);

            //Act
            int IdDetalheAtendimento = 1;
            IEnumerable<DetalheAtendimentoReadDTO> detalheAtendimentoReadDTO = detalheAtendimentoController.GetDetalhesAtendimento();

            //Assert
            Assert.Equal(1, detalheAtendimentoReadDTO.Count());

            //Act
            var resultDeleteDetalheAtendimento = detalheAtendimentoController.DeleteDetalheAtendimento(IdDetalheAtendimento) as NoContentResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, resultDeleteDetalheAtendimento.StatusCode);

            //Act
            detalheAtendimentoReadDTO = detalheAtendimentoController.GetDetalhesAtendimento();

            //Assert
            Assert.Equal(0, detalheAtendimentoReadDTO.Count());
        }
    }
}