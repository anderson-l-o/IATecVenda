public class VendaService
{
    private static List<Venda> _vendas = new();
    
    public Venda RegistrarVenda(Venda venda)
    {
        venda.Id = _vendas.Count + 1;
        venda.StatusVenda = StatusVenda.AguardandoPagamento;
        venda.Data = DateTime.Now;                 
        _vendas.Add(venda);
        return venda;
    }

    public Venda BuscarVenda(int id ) => _vendas.Find(venda => venda.Id == id);

    public bool AtualizarStatus(int id, StatusVenda novoStatus)
    {
        var venda = BuscarVenda(id); ;
        if (venda != null) return false;
        
        if (PodeAtualizarStatus(venda.Status, novoStatus))
        {
            venda.Status = novoStatus;
            return true;
        }
        return false;
    }

    private bool PodeAtualizarStatus(StatusVenda atual, StatusVenda novo)
    {
        return (atual == StatusVenda.AguardandoPagamento && 
               (novo  == StatusVenda.PagamentoAprovado || novo == StatusVenda.Cancelado)) ||
               (atual == StatusVenda.PagamentoAprovado && 
               (novo  == StatusVenda.Enviado || novo == StatusVenda.Cancelado)) ||
               (atual == StatusVenda.Enviado && novo == StatusVenda.Entregue);
    }

}