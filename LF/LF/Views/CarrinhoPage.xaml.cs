using LF.Models;
using LF.Utils;
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
	public partial class CarrinhoPage : ContentPage
	{
        public CarrinhoPage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            CarrinhoListView.ItemsSource = Util.PedidoAtual.Items;
        }

        private void Rem_Carrinho_Clicked(object sender, EventArgs e)
        {

        }

        private async void Add_Carrinho_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ItemPedidoModel it = (ItemPedidoModel)button.CommandParameter;

            CarrinhoListView.BeginRefresh();

            //CarrinhoListView.ItemsSource = null;

            Util.PedidoAtual.AddQtd(it.Produto);

            //CarrinhoListView.ItemsSource = Util.PedidoAtual.Items;

            await Task.Run(() =>
            {
                Util.PedidoAtual.AddQtd(it.Produto);
            });

            CarrinhoListView.EndRefresh();


        }

    }
}