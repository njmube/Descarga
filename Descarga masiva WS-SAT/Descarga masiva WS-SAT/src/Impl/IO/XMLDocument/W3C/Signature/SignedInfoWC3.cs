using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
 
using System.Xml;
using WSDescargaMasivaSAT.Impl.http.clienteSoap.IO;


namespace WSDescargaMasivaSAT.Impl.IO.XMLDocument.W3C.Signature
{
    public class SignedInfoWC3
    {

        /// <summary>
        /// 
        /// </summary>
        private XmlDocument _doc;

        /// <summary>
        /// 
        /// </summary>
        private string uuid;

    

        public SignedInfoWC3(XmlDocument doc, string uuidRamdon )
        {
            _doc = doc;
            uuid = uuidRamdon;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public  KeyInfoNode addSecurityTokenReference()
        {

            XmlElement securityTokenRef = SecurityTokenReference.xmlKeyInfoSecurityTokenReference(_doc, uuid);
            var keyInfoData = new KeyInfoNode(securityTokenRef);

            return keyInfoData;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="certificado"></param>
        /// <returns></returns>
        public static KeyInfoX509Data addIssuerName(X509Certificate2  certificado)
        {
            if (certificado == null)
            {
                throw new Exception("No se agregaron las claves");
            }


            var keyInfoData = new KeyInfoX509Data();
            keyInfoData.AddIssuerSerial(certificado.Issuer, certificado.GetSerialNumberString());

            return keyInfoData;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="certificado"></param>
        /// <returns></returns>
        public KeyInfoX509Data addX509Certificate(X509Certificate2 certificado)
        {
            if (certificado == null)
            {
                throw new Exception("No se agregaron las claves");
            }


            KeyInfoX509Data keyInfoData = new KeyInfoX509Data(certificado);

            return keyInfoData;
        }



    }
}
