using LF.Models;
using LF.Utils;
using LF.WS;
using System;
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

        private async void Fechar_Pedido_Clicked(object sender, EventArgs e)
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

                    if (Util.UsuarioLogado == null)
                    {
                       await Navigation.PushModalAsync(new LoginPage());
                    }
                    else
                    {
                        Util.PedidoAtual.IdCliente = Util.UsuarioLogado.Id;

                        Util.PedidoAtual.Data = DateTime.Now.ToShortDateString();
                        Util.PedidoAtual.Hora = DateTime.Now.ToShortTimeString();

                        foreach (ItemPedidoModel it in Util.PedidoAtual.Items)
                        {
                            it.Produto.Foto = null;
                        }


                        //string aaa = Newtonsoft.Json.JsonConvert.SerializeObject(Util.PedidoAtual);

                        //finaliza o pedido no ws
                        PedidoModel ped = await new PedidoWS().AddPedidoAsyc(Util.PedidoAtual);
                        
                        if(ped!=null && ped.Id > 0)
                        {
                            //await DisplayAlert("Ped Nº "+ ped.Id.ToString(), "Pedido Realizado com Sucesso", "Fechar");

                            //zera o pedido atual
                            Util.PedidoAtual.Items.Clear();

                            /**
                             * 
                             * 
                             * 
                             * Deveria funcionar assim
                             * 
                             * */
                            //redireciona pra tela de pedidos
                            /*var parentPage = this.Parent as TabbedPage;
                            parentPage.CurrentPage = parentPage.Children[3];*/



                            /*
                             * Gambiarra pra fazer funcionar
                             * */
                            Application.Current.MainPage = new MainPage();

                        }

                    }
                }
            }
            else
            {
                DisplayAlert("Pedido sem items", "Você esta tentando fechar um pedido sem items", "Cancelar");
            }
        }
    }
}