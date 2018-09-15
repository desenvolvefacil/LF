using LF.Utils;
using System;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace LF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            GC.Collect();

            //deixa a barra de menu na parte debaixo no android
            //da pani nos icones
            //On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            ProdutosPage lanches = new ProdutosPage() { Title = "", Icon = "lanches.png", IdCategoria = Util.CAT_LANCHES_ID };
            ProdutosPage bebidas = new ProdutosPage() { Title = "", Icon = "bebidas.png", IdCategoria = Util.CAT_BEBIDAS_ID };
            ProdutosPage combos = new ProdutosPage() { Title = "", Icon = "combos.png", IdCategoria = Util.CAT_COMBOS_ID };
            MeusPedidosPage pedidos = new MeusPedidosPage() { Title = "", Icon = "pedidos.png" };
            CarrinhoPage carrinho = new CarrinhoPage() { Title = "", Icon = "carrinho.png" };



            //Seta o Titulo para windows, já que o UWP não carrega os Icones
            lanches.On<Xamarin.Forms.PlatformConfiguration.Windows>().Element.Title = "Lanches";
            bebidas.On<Xamarin.Forms.PlatformConfiguration.Windows>().Element.Title = "Bebidas";
            combos.On<Xamarin.Forms.PlatformConfiguration.Windows>().Element.Title = "Combos";
            pedidos.On<Xamarin.Forms.PlatformConfiguration.Windows>().Element.Title = "Meus Pedidos";
            carrinho.On<Xamarin.Forms.PlatformConfiguration.Windows>().Element.Title = "Carrinhos";


            Children.Add(lanches);
            Children.Add(bebidas);
            Children.Add(combos);
            Children.Add(pedidos);
            Children.Add(carrinho);


            if (Util.UsuarioLogado != null)
            {
                CurrentPage = Children[3];
            }

        }
    }
}