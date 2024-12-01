using IATecVenda.Enums;
    
namespace IATecVenda.Models;

public class Venda
{
    public int Id { get; set; }
    public Vendedor Vendedor { get; set; }
    public DateTime DataVenda { get; set; }
    public List<Item> Itens { get; set; }    
    
    public StatusVenda Status { get; set; }
}