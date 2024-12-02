using System;
using IATecVenda.Enums;
using IATecVenda.Models;
using IATecVenda.Services;  
using Microsoft.AspNetCore.Mvc;
using VendasAPI.Services;

namespace IATecVenda.Controllers;
[ApiController]
[Route("api/iatecvenda")]
public class VendaController : ControllerBase
{

   // private static VendaService _service = new();

    private readonly IVendaService _vendaService;

    public VendaController(IVendaService vendaService)
    {
        _vendaService = vendaService;
    }

    [HttpPost]  
    public IActionResult RegistrarVenda([FromBody] Venda venda) 
    {
        if (venda.Itens == null || !venda.Itens.Any()) 
            return BadRequest("Uma venda deve conter pelo menos um item.");
        
        var vendaRegistrada = _vendaService.RegistrarVenda(venda);
        return CreatedAtAction(nameof(BuscarVenda), new { id = vendaRegistrada.Id }, vendaRegistrada);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarVenda(int id) 
    {
        var venda = _vendaService.BuscarVenda(id);
        if (venda == null) return NotFound();
        return Ok(venda);
    }

    [HttpPatch("{id}/status/")]
    public IActionResult AtualizarStatus(int id, [FromBody] StatusVenda novoStatus)
    {
        var atualizado = _vendaService.AtualizarStatus(id, novoStatus);
        if(!atualizado) return BadRequest("Transicão de status inválida ou venda não encontrada.");
        return NoContent();
    }
}