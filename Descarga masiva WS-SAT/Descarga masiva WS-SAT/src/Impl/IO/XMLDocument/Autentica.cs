using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using System.Xml;

namespace WSDescargaMasivaSAT.Impl.http.clienteSoap.IO
{
    public class Autentica
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static  XmlElement xmlBodyAutentica(XmlDocument doc)
        {
            XmlElement autenticaXml = doc.CreateElement("Autentica");
            autenticaXml.SetAttribute("xmlns", "http://DescargaMasivaTerceros.gob.mx");
            return autenticaXml;
        }
    }
}
