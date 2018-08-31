using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace LF.Models
{
    [Serializable]
    public class ItemPedidoModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs((propertyName)));
        }


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

        [XmlIgnore]
        public float ValorTotal
        {
            get
            {
                return this.Qtd * this.Produto.Valor;
            }
        }

        [XmlIgnore]
        public string NomeProduto
        {
            get
            {
                return Produto.Nome;
            }
        }

        [XmlIgnore]
        public ImageSource FotoProduto
        {
            get
            {
                return Produto.FotoProduto;
            }
        }

        [XmlIgnore]
        public float ValorProduto
        {
            get
            {
                return Produto.Valor;
            }
        }

        public void AddQtd()
        {
            this.Qtd++;

            OnPropertyChanged("Qtd");
            OnPropertyChanged("ValorTotal");
        }

        public void RemQtd()
        {
            this.Qtd--;

            OnPropertyChanged("Qtd");
            OnPropertyChanged("ValorTotal");
        }
    }
}