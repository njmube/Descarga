using System.Xml;

using System.Security.Cryptography.Xml;
using System.Security.Cryptography;

using System;


namespace WSDescargaMasivaSAT.Impl.http.clienteSoap.IO
{
    public class SignatureWC3
    {
       


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //private static KeyInfo addKeyInfo(XmlDocument doc, parametro.UUIDiRamdon)
        //{
        //    XmlElement securityTokenRef = SecurityTokenReference.xmlKeyInfoSecurityTokenReference(doc, parametro);
        //    var keyInfo = new KeyInfo();
        //    KeyInfoX509Data keyInfoData = new KeyInfoX509Data(parametro.certificado.getX509Certificate2());


        //   //*var keyInfoData = new KeyInfoNode(securityTokenRef);
        //    keyInfo.AddClause(keyInfoData);

        //    return keyInfo;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //private static  Reference addRefence()
        //{
        //    var reference = new Reference
        //    {
        //        Uri = $"#_0",
        //        DigestMethod = "http://www.w3.org/2000/09/xmldsig#sha1"
        //    };

        //    reference.AddTransform(new XmlDsigExcC14NTransform());

        //    return reference;

        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="parametro"></param>
        ///// <returns></returns>
        //private static RSACryptoServiceProvider extraerPrivateKeyRSACryptoServiceProvider(Parametros parametro)
        //{

        //    var privateKey = parametro.certificado.getX509Certificate2().PrivateKey as RSACryptoServiceProvider;

        //    return privateKey;
        //}


    }
}
