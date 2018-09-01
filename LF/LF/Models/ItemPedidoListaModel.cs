using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace LF.Models
{
    [JsonObject]
    public class ItemPedidoListaModel
    {
        [JsonProperty("qtd")]
        public int Qtd { get; set; }

        [JsonProperty("valor")]
        public float Valor { get; set; }

        [JsonProperty("nome")]
        public String NomeProduto { get; set; }

        [JsonProperty("foto")]
        public String Foto { get; set; }

        [JsonIgnore]
        public float ValorTotal { get { return Qtd * Valor; } }

        [JsonIgnore]
        public ImageSource FotoProduto
        {
            get
            {
                String file = Foto.Replace("data:image/png;base64,", "");

                var byteArray = Convert.FromBase64String(file);

                Stream stream = new MemoryStream(byteArray);
                var imageSource = ImageSource.FromStream(() => stream);
                return imageSource;
            }
        }
    }
}
