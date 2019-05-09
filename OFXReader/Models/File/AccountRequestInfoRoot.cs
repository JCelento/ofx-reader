using System.Xml.Serialization;

namespace OFXReader.Models.File
{
    [XmlRoot(ElementName = "STMTTRNRS")]
    public class AccountRequestInfoRoot
    {
        [XmlElement(ElementName = "TRNUID")]
        public string TRNUID { get; set; }

        [XmlElement(ElementName = "STATUS")]
        public Status STATUS { get; set; }

        [XmlElement(ElementName = "STMTRS")]
        public AccountRequestInfo STMTRS { get; set; }
    }

}
