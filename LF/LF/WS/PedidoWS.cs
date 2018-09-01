using LF.Models;
using LF.Utils;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LF.WS
{
    public interface IPedidoApi
    {
        [Post("/pedido/")]
        Task<PedidoModel> AddPedidoAsyc([Body]PedidoModel ped);

        [Get("/pedidos/{IdUsuario}")]
        Task<List<PedidoModel>> GetPedidosAsync(int IdUsuario);
    }

    public class PedidoWS : IPedidoApi
    {
        public async Task<PedidoModel> AddPedidoAsyc([Body] PedidoModel ped)
        {
            var response = RestService.For<IPedidoApi>(Util.URL_API);

            return await response.AddPedidoAsyc(ped);
        }

        public async Task<List<PedidoModel>> GetPedidosAsync(int IdUsuario)
        {
            var response = RestService.For<IPedidoApi>(Util.URL_API);

            return await response.GetPedidosAsync(IdUsuario);
        }
    }
}
