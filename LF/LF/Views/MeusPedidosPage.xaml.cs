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
    public partial class MeusPedidosPage : ContentPage
    {
        public MeusPedidosPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            if (Util.UsuarioLogado == null)
            {
                AbreTelaLoginCadastro();
            }
        }

        private async void AbreTelaLoginCadastro()
        {
            await Navigation.PushModalAsync(new LoginPage());
            //Navigation.PushAsync(new LoginPage());

            //caso retorne sem usuario volta pra tela inicial
            if (Util.UsuarioLogado == null)
            {
                var parentPage = this.Parent as TabbedPage;
                parentPage.CurrentPage = parentPage.Children[0];
            }
        }


    }
}