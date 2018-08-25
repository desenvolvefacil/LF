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

            //deixa a barra de menu na parte debaixo no android
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            Children.Add(new ProdutosPage() { Title = "", Icon = "lanches.png", IdCategoria= Util.CAT_LANCHES_ID});
            Children.Add(new ProdutosPage() { Title = "", Icon = "bebidas.png", IdCategoria = Util.CAT_BEBIDAS_ID });
            Children.Add(new ProdutosPage() { Title = "", Icon = "combos.png", IdCategoria = Util.CAT_COMBOS_ID });
            Children.Add(new MeusPedidosPage() { Title = "", Icon = "pedidos.png" });
            Children.Add(new CarrinhoPage() { Title = "", Icon = "carrinho.png" });

        }
    }
}