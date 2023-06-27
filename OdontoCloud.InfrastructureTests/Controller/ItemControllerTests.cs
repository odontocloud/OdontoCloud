using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdontoCloud.Infrastructure.Profiles;
using System.Net;
using Assert = Xunit.Assert;
using OdontoCloud.Domain.Entities;
using OdontoCloud.Infrastructure.DTOs.Item;
using OdontoCloud.Controllers;
using OdontoCloud.InfrastructureTests.Utilitaries;
using Microsoft.AspNetCore.JsonPatch;

namespace OdontoCloud.InfrastructureTests.Controller
{
    [TestClass]
    public class ItemControllerTests
    {
        Item sugador = new Item
        {
            IdFornecedor = 1,
            Descricao = "Sugador",
            Marca = "Brastemp",
            UnidadeMedida = "UN",
            QuantidadeEstoque = 2,
            ValorUnitario = 10,
        };

        Item laminaBisturi = new Item
        {
            IdFornecedor = 1,
            Descricao = "Lâmina de bisturi",
            Marca = "Brastemp",
            UnidadeMedida = "UN",
            QuantidadeEstoque = 5,
            ValorUnitario = 7.50,
        };

        private static IMapper _mapper;

        public ItemControllerTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new ItemProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public void TestPostItem()
        {
            //Arrange
            ItemController itemController = new ItemController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            ItemWriteDTO itemWriteDTO = _mapper.Map<ItemWriteDTO>(sugador);

            //Act
            var resultPostItem = itemController.PostItem(itemWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostItem.StatusCode);

            //Act
            int IdItem = 1;
            var resultGetItemById = itemController.GetItemById(IdItem) as OkObjectResult;
            ItemReadDTO itemReadDTO = resultGetItemById.Value as ItemReadDTO;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultGetItemById.StatusCode);
            Assert.Equal(1, itemReadDTO.Id);
            Assert.Equal(1, itemReadDTO.IdFornecedor);
            Assert.Equal("Sugador", itemReadDTO.Descricao);
            Assert.Equal("Brastemp", itemReadDTO.Marca);
            Assert.Equal("UN", itemReadDTO.UnidadeMedida);
            Assert.Equal(2, itemReadDTO.QuantidadeEstoque);
            Assert.Equal(10, itemReadDTO.ValorUnitario);
        }

        [Fact]
        public void TestGetItens()
        {
            //Arrange
            ItemController itemController = new ItemController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            ItemWriteDTO itemWriteDTO1 = _mapper.Map<ItemWriteDTO>(sugador);
            ItemWriteDTO itemWriteDTO2 = _mapper.Map<ItemWriteDTO>(laminaBisturi);

            //Act
            var resultPostItem1 = itemController.PostItem(itemWriteDTO1) as CreatedAtActionResult;
            var resultPostItem2 = itemController.PostItem(itemWriteDTO2) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostItem1.StatusCode);
            Assert.Equal((int)HttpStatusCode.Created, resultPostItem2.StatusCode);

            //Act
            IEnumerable<ItemReadDTO> itemReadDTO = itemController.GetItens();

            //Assert
            Assert.Equal(2, itemReadDTO.Count());
        }

        [Fact]
        public void TestPutItem()
        {
            //Arrange
            ItemController itemController = new ItemController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            ItemWriteDTO itemWriteDTO = _mapper.Map<ItemWriteDTO>(sugador);

            //Act
            var resultPostItem = itemController.PostItem(itemWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostItem.StatusCode);

            //Act
            int IdItem = 1;
            var resultGetItemById = itemController.GetItemById(IdItem) as OkObjectResult;
            ItemReadDTO itemReadDTO = resultGetItemById.Value as ItemReadDTO;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultGetItemById.StatusCode);
            Assert.Equal(1, itemReadDTO.Id);
            Assert.Equal(1, itemReadDTO.IdFornecedor);
            Assert.Equal("Sugador", itemReadDTO.Descricao);
            Assert.Equal("Brastemp", itemReadDTO.Marca);
            Assert.Equal("UN", itemReadDTO.UnidadeMedida);
            Assert.Equal(2, itemReadDTO.QuantidadeEstoque);
            Assert.Equal(10, itemReadDTO.ValorUnitario);

            //Act
            itemReadDTO.Marca = "Eletrolux";

            var resultPutItem = itemController.PutItem(IdItem, itemWriteDTO) as NoContentResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, resultPutItem.StatusCode);
            Assert.Equal("Eletrolux", itemReadDTO.Marca);
        }

        [Fact]
        public void TestPatchItem()
        {
            //Arrange
            ItemController itemController = new ItemController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            ItemWriteDTO itemWriteDTO = _mapper.Map<ItemWriteDTO>(sugador);

            //Act
            var resultPostItem = itemController.PostItem(itemWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostItem.StatusCode);

            //Act
            int IdItem = 1;
            var resultGetItemById = itemController.GetItemById(IdItem) as OkObjectResult;
            ItemReadDTO itemReadDTO = resultGetItemById.Value as ItemReadDTO;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultGetItemById.StatusCode);
            Assert.Equal(1, itemReadDTO.Id);
            Assert.Equal(1, itemReadDTO.IdFornecedor);
            Assert.Equal("Sugador", itemReadDTO.Descricao);
            Assert.Equal("Brastemp", itemReadDTO.Marca);
            Assert.Equal("UN", itemReadDTO.UnidadeMedida);
            Assert.Equal(2, itemReadDTO.QuantidadeEstoque);
            Assert.Equal(10, itemReadDTO.ValorUnitario);

            //Act
            var jasonDetalheAtendimento = new JsonPatchDocument<ItemWriteDTO>();

            jasonDetalheAtendimento.Replace(x => x.Marca, "Eletrolux");
            
            var resultPutItem = itemController.PatchItem(IdItem, jasonDetalheAtendimento) as NoContentResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, resultPutItem.StatusCode);
            Assert.Equal("Eletrolux", itemReadDTO.Marca);
        }

        [Fact]
        public void TestDeleteDetalheAtendimento()
        {
            //Arrange
            ItemController itemController = new ItemController(OdontoCloudTestUtil.GetDbContextInMemory(), _mapper);
            ItemWriteDTO itemWriteDTO = _mapper.Map<ItemWriteDTO>(sugador);

            //Act
            var resultPostItem = itemController.PostItem(itemWriteDTO) as CreatedAtActionResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.Created, resultPostItem.StatusCode);

            //Act
            int IdItem = 1;
            IEnumerable<ItemReadDTO> itemReadDTO = itemController.GetItens();

            //Assert
            Assert.Equal(1, itemReadDTO.Count());

            //Act
            var resultDeleteItem = itemController.DeleteItem(IdItem) as NoContentResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, resultDeleteItem.StatusCode);

            //Act
            itemReadDTO = itemController.GetItens();

            //Assert
            Assert.Equal(0, itemReadDTO.Count());
        }
    }
}