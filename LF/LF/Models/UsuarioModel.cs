using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LF.Models
{
    [Serializable]
    public class UsuarioModel
    {
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "nome")]
        public string Nome { get; set; }

        [XmlElement(ElementName = "email")]
        public string Email { get; set; }

        [XmlElement(ElementName = "senha")]
        public string Senha { get; set; }
    }
}
