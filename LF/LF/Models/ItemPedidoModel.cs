using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

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
    }
}