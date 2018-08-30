using LF.Models;
using LF.Utils;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace LF.WS
{
    public interface IUsuarioApi
    {
        [Post("/usuario/")]
        Task<UsuarioModel> AddUsuario([Body]UsuarioModel usu);

        [Post("/login/")]
        Task<UsuarioModel> LoginUsuario([Body]UsuarioModel usu);
    }

    public class UsuarioWs: IUsuarioApi
    {
        public async Task<UsuarioModel> AddUsuario(UsuarioModel usu)
        {
            var response = RestService.For<IUsuarioApi>(Util.URL_API);

            return await response.AddUsuario(usu);
        }

        public async Task<UsuarioModel> LoginUsuario([Body] UsuarioModel usu)
        {
            var response = RestService.For<IUsuarioApi>(Util.URL_API);

            return await response.LoginUsuario(usu);
        }
    }
}
