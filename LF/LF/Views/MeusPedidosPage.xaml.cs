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
    public partial class MeusPedidosPage : ContentPage
    {
        public MeusPedidosPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            if (Util.UsuarioLogado == null)
            {
                AbreTelaLoginCadastro();
            }
            else
            {
                UsuarioLabel.Text = Util.UsuarioLogado.Nome;

                List<PedidoModel> listaPedidos = await new PedidoWS().GetPedidosAsync(Util.UsuarioLogado.Id);

                PedidosListView.ItemsSource = listaPedidos;


            }
        }

        private async void AbreTelaLoginCadastro()
        {
            await Navigation.PushModalAsync(new LoginPage());
            //Navigation.PushAsync(new LoginPage());

            //caso retorne sem usuario volta pra tela inicial
            /*
            if (Util.UsuarioLogado == null)
            {
                var parentPage = this.Parent as TabbedPage;
                parentPage.CurrentPage = parentPage.Children[0];
            }
            */
        }

        private void Sair_Clicked(object sender, EventArgs e)
        {
            Util.UsuarioLogado = null;

            //navega até a aba Carrinho
            var parentPage = this.Parent as TabbedPage;
            parentPage.CurrentPage = parentPage.Children[0];
        }

        private async Task PedidosListView_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as PedidoModel;
            if (item == null) {

            }
            else {

                await Navigation.PushModalAsync(new ItemPedidoPage() { IdPedido=item.Id});

                // Manually deselect item.
                PedidosListView.SelectedItem = null;
            }
        }
    }
}