using LF.Models;
using LF.Utils;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LF.WS
{
    public interface ItemPedidoApi
    {
        [Get("/items/{IdPedido}")]
        Task<List<ItemPedidoListaModel>> GetItemsAsync(int IdPedido);

    }

    public class ItemPedidoWS : ItemPedidoApi
    {
        public async Task<List<ItemPedidoListaModel>> GetItemsAsync(int IdPedido)
        {
            var response = RestService.For<ItemPedidoApi>(Util.URL_API);

            return await response.GetItemsAsync(IdPedido);
        }
    }
}
