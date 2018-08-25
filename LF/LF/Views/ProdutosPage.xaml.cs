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
    }
}