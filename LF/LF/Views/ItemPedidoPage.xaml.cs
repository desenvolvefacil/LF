using LF.Models;
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
    public partial class ItemPedidoPage : ContentPage
    {
        public int IdPedido { get; set; }

        public ItemPedidoPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            List<ItemPedidoListaModel> listaPedidos = await new ItemPedidoWS().GetItemsAsync(IdPedido);

            ItemsListView.ItemsSource = listaPedidos;
        }
    }

    
}