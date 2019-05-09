using System.Xml.Serialization;

namespace OFXReader.Models.File
{
    [XmlRoot(ElementName = "BANKMSGSRSV1")]
    public class AccountBankInfoRoot
    {
        [XmlElement(ElementName = "STMTTRNRS")]
        public AccountRequestInfoRoot STMTTRNRS { get; set; }
    }
}
