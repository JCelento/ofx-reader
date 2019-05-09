using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OFXReader.Models.File
{
    [XmlRoot(ElementName = "OFX")]
    public class OFXFileObject
    {
        [XmlElement(ElementName = "SIGNONMSGSRSV1")]
        public LogonDataRoot SIGNONMSGSRSV1 { get; set; }

        [XmlElement(ElementName = "BANKMSGSRSV1")]
        public AccountBankInfoRoot BANKMSGSRSV1 { get; set; }
    }

}
