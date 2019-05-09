using System.Xml.Serialization;

namespace OFXReader.Models.File
{
    [XmlRoot(ElementName = "STMTRS")]
    public class AccountRequestInfo
    {
        [XmlElement(ElementName = "CURDEF")]
        public string CURDEF { get; set; }

        [XmlElement(ElementName = "BANKACCTFROM")]
        public AccountData BANKACCTFROM { get; set; }

        [XmlElement(ElementName = "BANKTRANLIST")]
        public BankTransaction BANKTRANLIST { get; set; }

        [XmlElement(ElementName = "LEDGERBAL")]
        public LedgerBalance LEDGERBAL { get; set; }

    }
}