public class Venda
{
    public int Id { get; set; }
    public Vendedor Vendedor { get; set; }
    public int List<Item> Itens { get; set; }    
    public DateTime DataVenda { get; set; }
}