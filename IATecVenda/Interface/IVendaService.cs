using System.Collections.Generic;
using IATecVenda.Enums;
using IATecVenda.Models;

namespace VendasAPI.Services
{
    public interface IVendaService
    {
        Venda BuscarVenda(int id);
        Venda RegistrarVenda(Venda venda);
        bool AtualizarStatus(int id, StatusVenda novoStatus);        
    }
}