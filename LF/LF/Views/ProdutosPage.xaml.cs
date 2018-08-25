using LF.Models;
using LF.Utils;
using LF.WS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LF.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProdutosPage : ContentPage
	{
        public int IdCategoria { get; set; }

        public ProdutosPage ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            List<ProdutoModel> Items = await new ProdutoWS().GetProdutosAsync(IdCategoria);

            ProdutosListView.ItemsSource = Items;
        }

        private  void Add_Carrinho_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ProdutoModel produto =(ProdutoModel)button.CommandParameter;

            //DisplayAlert("Titulo",produto.Valor.ToString(),"Cancelar");

            if (Util.PedidoAtual == null)
            {
                Util.PedidoAtual = new PedidoModel();
            }

            Util.PedidoAtual.AddProduto(produto);


            //navega até a aba Carrinho
            var parentPage = this.Parent as TabbedPage;
            parentPage.CurrentPage = parentPage.Children[4];
        }
    }
}