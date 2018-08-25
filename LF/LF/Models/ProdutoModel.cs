using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace LF.Models
{
    [Serializable]
    public class ProdutoModel
    {
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }

        [XmlElement(ElementName = "nome")]
        public string Nome { get; set; }

        [XmlElement(ElementName = "descricao")]
        public string Descricao { get; set; }

        [XmlElement(ElementName = "valor")]
        public float Valor { get; set; }

        [XmlElement(ElementName = "Categoria")]
        public int Categoria { get; set; }

        [XmlElement(ElementName = "foto")]
        public string Foto { get; set; }



        //converte a foto 64b para ImageSourve
        public ImageSource FotoProduto
        {
            get
            {
                string file = Foto.Replace("data:image/png;base64,", "");

                var byteArray = Convert.FromBase64String(file);

                Stream stream = new MemoryStream(byteArray);
                var imageSource = ImageSource.FromStream(() => stream);
                return imageSource;
            }
        }
    }
}
