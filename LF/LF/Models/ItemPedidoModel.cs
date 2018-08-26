using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace LF.Models
{
    [Serializable]
    public class ItemPedidoModel
    {
        [XmlElement(ElementName = "qtd")]
        public int Qtd { get; set; }

        [XmlElement(ElementName = "produto")]
        public ProdutoModel Produto;

        public ItemPedidoModel(ProdutoModel p)
        {
            if (p != null)
            {
                this.Produto = p;
                this.Qtd = 1;
            }
        }


        public float ValorTotal
        {
            get
            {
                return this.Qtd * this.Produto.Valor;
            }
        }

        public string NomeProduto
        {
            get
            {
                return Produto.Nome;
            }
        }

        public ImageSource FotoProduto
        {
            get
            {
                return Produto.FotoProduto;
            }
        }

        public float ValorProduto
        {
            get
            {
                return Produto.Valor;
            }
        }
    }
}