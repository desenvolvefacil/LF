using LF.Models;
using LF.Utils;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LF.WS
{
    public interface IProdutoApi
    {
        [Get("/produtos/{IdCategoria}")]
        Task<List<ProdutoModel>> GetProdutosAsync(int IdCategoria);

        [Post("/usuario/")]
        Task<UsuarioModel> AddCliente([Body]UsuarioModel usu);
    }


    public class ProdutoWS : IProdutoApi
    {
        public async Task<UsuarioModel> AddCliente(UsuarioModel usu)
        {
            var response = RestService.For<IProdutoApi>(Util.URL_API);

            return await response.AddCliente(usu);
        }

        public async Task<List<ProdutoModel>> GetProdutosAsync(int IdCategoria)
        {
            var response = RestService.For<IProdutoApi>(Util.URL_API);

            return await response.GetProdutosAsync(IdCategoria);
        }
    }


}
