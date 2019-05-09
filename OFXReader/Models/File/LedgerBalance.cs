using System.Xml.Serialization;

namespace OFXReader.Models.File
{
    [XmlRoot(ElementName = "LEDGERBAL")]
    public class LedgerBalance
    {
        [XmlElement(ElementName = "BALAMT")]
        public string BALAMT { get; set; }

        [XmlElement(ElementName = "DTASOF")]
        public string DTASOF { get; set; }
    }
}