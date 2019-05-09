using System.Xml.Serialization;

namespace OFXReader.Models.File
{

    [XmlRoot(ElementName = "SIGNONMSGSRSV1")]
    public class LogonDataRoot
    {
        [XmlElement(ElementName = "SONRS")]
        public LogonData SONRS { get; set; }
    }

}
