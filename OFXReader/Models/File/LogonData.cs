using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace OFXReader.Models.File
{
    [XmlRoot(ElementName = "SONRS")]
    public class LogonData
    {
        [XmlElement(ElementName = "STATUS")]
        public Status STATUS { get; set; }

        [XmlElement(ElementName = "DTSERVER")]
        public string DTSERVER { get; set; }

        [XmlElement(ElementName = "LANGUAGE")]
        public string LANGUAGE { get; set; }

        [XmlElement(ElementName = "DTCLIENT")]
        public string DTCLIENT { get; set; }

        [XmlElement(ElementName = "USERID")]
        public string USERID { get; set; }

        [XmlElement(ElementName = "USERPASS")]
        public string USERPASS { get; set; }

        [XmlElement(ElementName = "FI")]
        public InstitutionData FI { get; set; }

        [XmlElement(ElementName = "APPID")]
        public string APPID { get; set; }

        [XmlElement(ElementName = "APPVER")]
        public string APPVER { get; set; }
    }
}