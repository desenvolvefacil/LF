using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LF.Models
{
    [Serializable]
    public class PedidoModel
    {
        public PedidoModel()
        {
            this.Items = new List<ItemPedidoModel>();
            this.Id = 0;
        }

        [XmlElement(ElementName = "id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "idCliente")]
        public int IdCliente { get; set; }

        [XmlElement(ElementName = "items")]
        public List<ItemPedidoModel> Items { get; set; }

        [XmlElement(ElementName = "numeroMesa")]
        public int NumeroMesa { get; set; }

        [XmlElement(ElementName = "status")]
        public int Status { get; set; }

        [XmlElement(ElementName = "valorTotal")]
        public float ValorTotal { get; set; }

        [XmlElement(ElementName = "data")]
        public String Data { get; set; }

        [XmlElement(ElementName = "hora")]
        public string Hora { get; set; }

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


        public void AddProduto(ProdutoModel p) {
            //verifica se jรก existe o produto
            int index = Items.FindIndex(o => o.Produto.Id == p.Id);

            if (index < 0) {
                ItemPedidoModel it = new ItemPedidoModel(p);

                this.Items.Add(it);

                //this.ordenaItens();
            } else {
                this.Items[index].Qtd++;
            }
        }

        public void RemProduto(ProdutoModel p)
        {
            int index = Items.FindIndex(o => o.Produto.Id == p.Id);

            this.Items.RemoveAt(index);

            //this.ordenaItens();
        }

        public void AddQtd(ProdutoModel p)
        {
            int index = this.Items.FindIndex(o=>o.Produto.Id==p.Id);

            this.Items[index].AddQtd();
        }

        public void RemQtd(ProdutoModel p)
        {
            //let index = this._itens.findIndex(o=>o.produto.id==IdProduto);
            int index = this.Items.FindIndex(o => o.Produto.Id == p.Id);

            //caso o produto seja zerado, remove do pedido
            if (this.Items[index].Qtd - 1 <= 0)
            {
                this.Items.RemoveAt(index);

                //this.ordenaItens();
            }
            else
            {
                this.Items[index].RemQtd();
            }
        }

        public float ValorTotalPedido{
            get{
                this.ValorTotal = 0;

                this.Items.ForEach(element => {
                    this.ValorTotal += element.ValorTotal;
                });

                return this.ValorTotal;
            }
    }
}
}
