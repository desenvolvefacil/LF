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
                Navigation.PushModalAsync(new LoginPage());
                //Navigation.PushAsync(new LoginPage());
            }
        }

    }
}