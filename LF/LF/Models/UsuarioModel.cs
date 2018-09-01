using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LF.Models
{
    [Serializable]
    [JsonObject]
    public class UsuarioModel
    {
        [JsonProperty(PropertyName = "id")]
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "nome")]
        [JsonProperty(PropertyName = "nome")]
        public string Nome { get; set; }

        [XmlElement(ElementName = "email")]
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [XmlElement(ElementName = "senha")]
        [JsonProperty(PropertyName = "senha")]
        public string Senha { get; set; }
    }
}
