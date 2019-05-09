using System.Xml.Serialization;

namespace OFXReader.Models.File
{
    [XmlRoot(ElementName = "STATUS")]
    public class Status
    {
        [XmlElement(ElementName = "CODE")]
        public string CODE { get; set; }

        [XmlElement(ElementName = "SEVERITY")]
        public string SEVERITY { get; set; }
    }
}