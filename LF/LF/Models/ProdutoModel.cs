using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace LF.Models
{
    [JsonObject]
    public class ProdutoModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "nome")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "descricao")]
        public string Descricao { get; set; }

        [JsonProperty(PropertyName = "valor")]
        public float Valor { get; set; }

        [JsonProperty(PropertyName = "categoria")]
        public int Categoria { get; set; }

        [JsonProperty(PropertyName = "foto")]
        public string Foto { get; set; }



        //converte a foto 64b para ImageSourve
        [JsonIgnore]
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
