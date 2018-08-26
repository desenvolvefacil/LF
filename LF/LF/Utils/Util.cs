using LF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LF.Utils
{
    public static class Util
    {
        public static String URL_API = "http://testefacil.tk/lanchefacil";

        public static int CAT_LANCHES_ID = 1;
        public static int CAT_BEBIDAS_ID = 2;
        public static int CAT_COMBOS_ID = 3;

        public static PedidoModel PedidoAtual= new PedidoModel();
        public static UsuarioModel UsuarioLogado=null;
    }
}
