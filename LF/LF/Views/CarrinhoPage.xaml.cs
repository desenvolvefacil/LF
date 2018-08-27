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

            CarrinhoListView.ItemsSource = null;

            CarrinhoListView.ItemsSource = Util.PedidoAtual.Items;

        }

        private void Rem_Carrinho_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ItemPedidoModel it = (ItemPedidoModel)button.CommandParameter;

            CarrinhoListView.BeginRefresh();

            /*await Task.Run(() =>
            {
                Util.PedidoAtual.AddQtd(it.Produto);
            });*/

            Util.PedidoAtual.RemQtd(it);

            CarrinhoListView.EndRefresh();
        }

        private void Add_Carrinho_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ItemPedidoModel it = (ItemPedidoModel)button.CommandParameter;

            CarrinhoListView.BeginRefresh();

            /*await Task.Run(() =>
            {
                Util.PedidoAtual.AddQtd(it.Produto);
            });*/

            Util.PedidoAtual.AddQtd(it);

            CarrinhoListView.EndRefresh();


        }

    }
}