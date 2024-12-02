using System.Data.Common;
using IATecVenda.Controllers;
using IATecVenda.Models;
using IATecVenda.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace IATecVendaTest.Tests;

 public class VendasControllerTests
    {
        private static Mock<VendaService> _mockService;
        private static VendaController _controller;

        public VendasControllerTests()
        {
            _mockService = new Mock<VendaService>();
            _controller = new VendaController(_mockService.Object);
        }

        [Fact]
        public void RegistrarVenda_DeveRetornarCreatedQuandoVendaForValida()
        {
            var venda = new Venda
            {
                Id = 1,
                Status = 0,
                Vendedor = new Vendedor { Id = 1, Nome = "Carlos", cpf = "12345678910" },
                DataVenda = DateTime.Now,
                Itens = new List<Item>
                {
                    new Item {Id = 1, Descricao = "Produto 1", Quantidade = 1, Preco = 100.0M }
                }
            };
            _mockService.Setup(s => s.RegistrarVenda(venda)).Returns(venda);

            var result = _controller.RegistrarVenda(venda) as CreatedAtActionResult;

            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
            Assert.Equal(venda, result.Value);
        }

        [Fact]
        public void BuscarVenda_DeveRetornarOkQuandoVendaExistir()
        {
            var vendaId = 1;
            var venda = new Venda { Id = vendaId, Status = 0 };
            _mockService.Setup(s => s.BuscarVenda(vendaId)).Returns(venda);

            var result = _controller.BuscarVenda(vendaId) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(venda, result.Value);
        }

        [Fact]
        public void AtualizarVenda_DeveRetornarBadRequestSeStatusInvalido()
        {
            var vendaId = 1;             
            var novoStatus = 2;

            var result = _controller.AtualizarStatus(vendaId, (IATecVenda.Enums.StatusVenda)novoStatus) as BadRequestObjectResult;

            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Transicão de status inválida ou venda não encontrada.", result.Value);
        }
    }

