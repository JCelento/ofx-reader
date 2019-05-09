using System.Xml.Serialization;

namespace OFXReader.Models.File
{
    [XmlRoot(ElementName = "BANKACCTFROM")]
    public class AccountData
    {
        [XmlElement(ElementName = "BANKID")]
        public string BANKID { get; set; }

        [XmlElement(ElementName = "ACCTID")]
        public string ACCTID { get; set; }

        [XmlElement(ElementName = "ACCTTYPE")]
        public string ACCTTYPE { get; set; }
    }
}