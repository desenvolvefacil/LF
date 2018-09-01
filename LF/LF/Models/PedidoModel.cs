using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace LF.Models
{
    [JsonObject]
    public class PedidoModel
    {
        public PedidoModel()
        {
            this.Items = new List<ItemPedidoModel>();
            this.Id = 0;
        }


        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "idCliente")]
        public int IdCliente { get; set; }

        [JsonProperty(PropertyName = "items")]
        public List<ItemPedidoModel> Items { get; set; }

        [JsonProperty(PropertyName = "numeroMesa")]
        public int NumeroMesa { get; set; }

        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }

        [JsonProperty(PropertyName = "valorTotal")]
        public float ValorTotal { get; set; }

        [JsonProperty(PropertyName = "data")]
        public String Data { get; set; }

        [JsonProperty(PropertyName = "hora")]
        public string Hora { get; set; }


        [JsonIgnore]
        public float ValorTotalPedido
        {
            get
            {
                this.ValorTotal = 0;

                foreach (ItemPedidoModel item in Items)
                {
                    ValorTotal += item.ValorTotal;
                }

                return this.ValorTotal;
            }
        }


        [JsonIgnore]
        public string NomeStatus
        {
            get
            {
                switch (this.Status.ToString())
                {
                    case "1":
                        {
                            return "Pago";
                        }
                    default:
                        {
                            return "Pendente";
                        }
                }
            }
        }


        public void AddProduto(ProdutoModel p)
        {
            //verifica se jรก existe o produto
            int index = -1;
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Produto.Id == p.Id)
                {
                    index = i;
                    break;
                }
            }

            if (index < 0)
            {
                ItemPedidoModel it = new ItemPedidoModel(p);

                this.Items.Add(it);

                //this.ordenaItens();
            }
            else
            {
                this.Items[index].Qtd++;
            }
        }

        public void RemProduto(ItemPedidoModel it)
        {
            int index = Items.IndexOf(it);

            this.Items.RemoveAt(index);

            //this.ordenaItens();
        }

        public void AddQtd(ItemPedidoModel it)
        {
            int index = Items.IndexOf(it);

            this.Items[index].AddQtd();
        }


        public void RemQtd(ItemPedidoModel it)
        {
            //let index = this._itens.findIndex(o=>o.produto.id==IdProduto);
            int index = Items.IndexOf(it);

            //caso o produto seja zerado, remove do pedido
            if (this.Items[index].Qtd - 1 <= 0)
            {
                this.Items.RemoveAt(index);
            }
            else
            {
                this.Items[index].RemQtd();
            }
        }

        
    }
}