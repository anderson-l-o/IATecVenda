
namespace IATecVenda.Controllers;
[ApiController]
[Route("api/iatecvenda")]
public class VendaController : ControllerBase
{

    private readonly VendaService _service = new();

    [HttpPost]  
    public IActionResult RegistrarVenda([FromBody] Venda venda) 
    {
        if (venda.Itens == null || venda.Itens.Any()) return BadRequest("Uma venda deve conter pelo menos um item.");
        
        var vendaRegistrada = _service.RegistrarVenda(venda);
        return CreatedAtAction(nameof(BuscarVenda), new { id = vendaRegistrada.Id }, vendaRegistrada);
    }

    [HttpGet]
    public IActionResult BuscarVenda(int id) 
    {
        var venda = _service.BuscarVenda(id);
        if (venda == null) return NotFound();
        return Ok(venda);
    }

    [httppath("{id}/status/")]
    public IActionResult AtualizarStatus(int id, [FromBody] StatusVenda novoStatus)
    {
        var atualizado = _service.AtualizarStatus(id, novoStatus);
        if(!atualizado) return BadRequest("Transicão de status inválida ou venda não encontrada.");
        return NoContent();
    }
    
}