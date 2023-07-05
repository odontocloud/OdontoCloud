using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdontoCloud.Infrastructure.Profiles;
using System.Net;
using Assert = Xunit.Assert;
using OdontoCloud.Domain.Entities;
using OdontoCloud.Infrastructure.DTOs.Anamnese;
using OdontoCloud.Controllers;
using OdontoCloud.InfrastructureTests.Utilitaries;
using Microsoft.AspNetCore.JsonPatch;

namespace OdontoCloud.InfrastructureTests.Controller
{
    [TestClass]
    public class AnamneseControllerTests
    {
        Anamnese anamnese1 = new Anamnese
        {
            IdCliente = 1,
            DoencaCardiovascular = false,
            DescricaoDoencaCardiovascular = "N/A",
            Hipertencao = false,
            Diabetes = false,
            DoencaRespiratoria = false,
            DoencaHepatica = false,
            Osteoporose = false,
            CoagulacaoSangramento = false,
            ProblemaGastrico = false,
            Hepatite = false,
            TratamentoMedico = false,
            DescricaoTratamentoMedico = "N/A",
            Alergia = false,
            DescricaoAlergia = "N/A",
            Fumante = false,
            Gravida = false,
            GravidaAmamentando = false,
            RestricaoMedicamento = false,
            DescricaoRestricaoMedicamento = "N/A",
            MedicamentoUso = false,
            ProblemaAnestesia = false
        };

        Anamnese anamnese2 = new Anamnese
        {
            IdCliente = 2,
            DoencaCardiovascular = false,
            DescricaoDoencaCardiovascular = "N/A",
            Hipertencao = false,
            Diabetes = true,
            DoencaRespiratoria = false,
            DoencaHepatica = false,
            Osteoporose = false,
            CoagulacaoSangramento = false,
            ProblemaGastrico = false,
            Hepatite = true,
            TratamentoMedico = true,
            DescricaoTratamentoMedico = "N/A",
            Alergia = false,
            DescricaoAlergia = "N/A",
            Fumante = true,
            Gravida = false,
            GravidaAmamentando = false,
            RestricaoMedicamento = true,
            DescricaoRestricaoMedicamento = "N/A",
            MedicamentoUso = false,
            ProblemaAnestesia = false
        };

        private static IMapper _mapper;

        public AnamneseControllerTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AnamneseProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public void TestPostAnamnese()
        {
            //Arrange
            AnamneseController anamneseController = new(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            AnamneseWriteDTO anamneseWriteDTO = _mapper.Map<AnamneseWriteDTO>(anamnese1);

            //Act
            var resultPostAnamnese = anamneseController.PostAnamnese(anamneseWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostAnamnese.StatusCode);

            //Act
            int IdAnamnese = 1;
            var resultGetAnamneseById = anamneseController.GetAnamneseById(IdAnamnese) as OkObjectResult;
            AnamneseReadDTO anamneseReadDTO = resultGetAnamneseById.Value as AnamneseReadDTO;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultGetAnamneseById.StatusCode);
            Assert.Equal(1, anamneseReadDTO.Id);
            Assert.False(anamneseReadDTO.DoencaCardiovascular);
            Assert.Equal("N/A", anamneseReadDTO.DescricaoDoencaCardiovascular);
            Assert.False(anamneseReadDTO.Hipertencao);
            Assert.False(anamneseReadDTO.Diabetes);
            Assert.False(anamneseReadDTO.DoencaRespiratoria);
            Assert.False(anamneseReadDTO.DoencaHepatica);
            Assert.False(anamneseReadDTO.Osteoporose);
            Assert.False(anamneseReadDTO.CoagulacaoSangramento);
            Assert.False(anamneseReadDTO.ProblemaGastrico);
            Assert.False(anamneseReadDTO.Hepatite);
            Assert.False(anamneseReadDTO.TratamentoMedico);
            Assert.Equal("N/A", anamneseReadDTO.DescricaoTratamentoMedico);
            Assert.False(anamneseReadDTO.Alergia);
            Assert.Equal("N/A", anamneseReadDTO.DescricaoAlergia);
            Assert.False(anamneseReadDTO.Fumante);
            Assert.False(anamneseReadDTO.Gravida);
            Assert.False(anamneseReadDTO.GravidaAmamentando);
            Assert.False(anamneseReadDTO.RestricaoMedicamento);
            Assert.Equal("N/A", anamneseReadDTO.DescricaoRestricaoMedicamento);
            Assert.False(anamneseReadDTO.MedicamentoUso);
            Assert.False(anamneseReadDTO.ProblemaAnestesia);
        }

        [Fact]
        public void TestGetAnamnesees()
        {
            //Arrange
            AnamneseController anamneseController = new(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            AnamneseWriteDTO anamneseWriteDTO1 = _mapper.Map<AnamneseWriteDTO>(anamnese1);
            AnamneseWriteDTO anamneseWriteDTO2 = _mapper.Map<AnamneseWriteDTO>(anamnese2);

            //Act
            var resultPostAnamnese1 = anamneseController.PostAnamnese(anamneseWriteDTO1) as CreatedAtActionResult;
            var resultPostAnamnese2 = anamneseController.PostAnamnese(anamneseWriteDTO2) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostAnamnese1.StatusCode);
            Assert.Equal((int)HttpStatusCode.Created, resultPostAnamnese2.StatusCode);

            //Act
            IEnumerable<AnamneseReadDTO> anamneseReadDTO = anamneseController.GetAnamneses();

            //Assert
            Assert.Equal(2, anamneseReadDTO.Count());
        }

        [Fact]
        public void TestPutAnamnese()
        {
            //Arrange
            AnamneseController anamneseController = new(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            AnamneseWriteDTO anamneseWriteDTO = _mapper.Map<AnamneseWriteDTO>(anamnese1);

            //Act
            var resultPostAnamnese = anamneseController.PostAnamnese(anamneseWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostAnamnese.StatusCode);

            //Act
            int IdAnamnese = 1;
            var resultGetAnamneseById = anamneseController.GetAnamneseById(IdAnamnese) as OkObjectResult;
            AnamneseReadDTO anamneseReadDTO = resultGetAnamneseById.Value as AnamneseReadDTO;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultGetAnamneseById.StatusCode);
            Assert.Equal(1, anamneseReadDTO.Id);
            Assert.False(anamneseReadDTO.DoencaCardiovascular);
            Assert.Equal("N/A", anamneseReadDTO.DescricaoDoencaCardiovascular);
            Assert.False(anamneseReadDTO.Hipertencao);
            Assert.False(anamneseReadDTO.Diabetes);
            Assert.False(anamneseReadDTO.DoencaRespiratoria);
            Assert.False(anamneseReadDTO.DoencaHepatica);
            Assert.False(anamneseReadDTO.Osteoporose);
            Assert.False(anamneseReadDTO.CoagulacaoSangramento);
            Assert.False(anamneseReadDTO.ProblemaGastrico);
            Assert.False(anamneseReadDTO.Hepatite);
            Assert.False(anamneseReadDTO.TratamentoMedico);
            Assert.Equal("N/A", anamneseReadDTO.DescricaoTratamentoMedico);
            Assert.False(anamneseReadDTO.Alergia);
            Assert.Equal("N/A", anamneseReadDTO.DescricaoAlergia);
            Assert.False(anamneseReadDTO.Fumante);
            Assert.False(anamneseReadDTO.Gravida);
            Assert.False(anamneseReadDTO.GravidaAmamentando);
            Assert.False(anamneseReadDTO.RestricaoMedicamento);
            Assert.Equal("N/A", anamneseReadDTO.DescricaoRestricaoMedicamento);
            Assert.False(anamneseReadDTO.MedicamentoUso);
            Assert.False(anamneseReadDTO.ProblemaAnestesia);

            //Act
            anamneseReadDTO.MedicamentoUso = true;

            var resultPutAnamnese = anamneseController.PutAnamnese(IdAnamnese, anamneseWriteDTO) as NoContentResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, resultPutAnamnese.StatusCode);
            Assert.True(anamneseReadDTO.MedicamentoUso);
        }

        [Fact]
        public void TestPatchAnamnese()
        {
            //Arrange
            AnamneseController anamneseController = new(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            AnamneseWriteDTO anamneseWriteDTO = _mapper.Map<AnamneseWriteDTO>(anamnese1);

            //Act
            var resultPostAnamnese = anamneseController.PostAnamnese(anamneseWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostAnamnese.StatusCode);

            //Act
            int IdAnamnese = 1;
            var resultGetAnamneseById = anamneseController.GetAnamneseById(IdAnamnese) as OkObjectResult;
            AnamneseReadDTO anamneseReadDTO = resultGetAnamneseById.Value as AnamneseReadDTO;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultGetAnamneseById.StatusCode);
            Assert.Equal(1, anamneseReadDTO.Id);
            Assert.False(anamneseReadDTO.DoencaCardiovascular);
            Assert.Equal("N/A", anamneseReadDTO.DescricaoDoencaCardiovascular);
            Assert.False(anamneseReadDTO.Hipertencao);
            Assert.False(anamneseReadDTO.Diabetes);
            Assert.False(anamneseReadDTO.DoencaRespiratoria);
            Assert.False(anamneseReadDTO.DoencaHepatica);
            Assert.False(anamneseReadDTO.Osteoporose);
            Assert.False(anamneseReadDTO.CoagulacaoSangramento);
            Assert.False(anamneseReadDTO.ProblemaGastrico);
            Assert.False(anamneseReadDTO.Hepatite);
            Assert.False(anamneseReadDTO.TratamentoMedico);
            Assert.Equal("N/A", anamneseReadDTO.DescricaoTratamentoMedico);
            Assert.False(anamneseReadDTO.Alergia);
            Assert.Equal("N/A", anamneseReadDTO.DescricaoAlergia);
            Assert.False(anamneseReadDTO.Fumante);
            Assert.False(anamneseReadDTO.Gravida);
            Assert.False(anamneseReadDTO.GravidaAmamentando);
            Assert.False(anamneseReadDTO.RestricaoMedicamento);
            Assert.Equal("N/A", anamneseReadDTO.DescricaoRestricaoMedicamento);
            Assert.False(anamneseReadDTO.MedicamentoUso);
            Assert.False(anamneseReadDTO.ProblemaAnestesia);

            //Act
            var jasonAnamnese = new JsonPatchDocument<AnamneseWriteDTO>();

            jasonAnamnese.Replace<bool>(x => x.Hepatite, true);
            
            var resultPutAnamnese = anamneseController.PatchAnamnese(IdAnamnese, jasonAnamnese) as NoContentResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, resultPutAnamnese.StatusCode);
            Assert.True(anamneseReadDTO.Hepatite);
        }

        [Fact]
        public void TestDeleteAnamnese()
        {
            //Arrange
            AnamneseController anamneseController = new(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            AnamneseWriteDTO anamneseWriteDTO = _mapper.Map<AnamneseWriteDTO>(anamnese1);

            //Act
            var resultPostAnamnese = anamneseController.PostAnamnese(anamneseWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostAnamnese.StatusCode);

            //Act
            int IdAnamnese = 1;
            IEnumerable<AnamneseReadDTO> anamneseReadDTO = anamneseController.GetAnamneses();

            //Assert
            Assert.Equal(1, anamneseReadDTO.Count());

            //Act
            var resultDeleteAnamnese = anamneseController.DeleteAnamnese(IdAnamnese) as NoContentResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, resultDeleteAnamnese.StatusCode);

            //Act
            anamneseReadDTO = anamneseController.GetAnamneses();

            //Assert
            Assert.Equal(0, anamneseReadDTO.Count());
        }
    }
}