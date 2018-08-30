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

            TotalPedidoLabel.Text = String.Format("{0:C}", Util.PedidoAtual.ValorTotalPedido);
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

            TotalPedidoLabel.Text = String.Format("{0:C}", Util.PedidoAtual.ValorTotalPedido);
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

            TotalPedidoLabel.Text = String.Format("{0:C}", Util.PedidoAtual.ValorTotalPedido);
        }

        private void Fechar_Pedido_Clicked(object sender, EventArgs e)
        {
            //verifica se tem items no Pedido
            if (Util.PedidoAtual != null && Util.PedidoAtual.Items.Count > 0)
            {

                //verifica se o cliente selecionou a mesa
                int NumeroMesa = 0;
                int.TryParse(NumeroMesaEntry.Text, out NumeroMesa);

                if (NumeroMesa <= 0)
                {
                    DisplayAlert("Número da Mesa", "Digite o número de sua mesa", "Cancelar");
                    NumeroMesaEntry.Focus();
                }
                else
                {
                    Util.PedidoAtual.NumeroMesa = NumeroMesa;
                }
            }
            else
            {
                DisplayAlert("Pedido sem items", "Você esta tentando fechar um pedido sem items", "Cancelar");
            }
        }
    }
}