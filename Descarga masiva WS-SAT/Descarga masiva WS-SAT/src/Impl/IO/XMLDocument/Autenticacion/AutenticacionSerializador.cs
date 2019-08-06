using Descarga_masiva_WS_SAT.src;
using Descarga_masiva_WS_SAT.src.Impl.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;

using System.Text;
 
using System.Xml;
using WSDescargaMasivaSAT.Impl.IO.XMLDocument;
using WSDescargaMasivaSAT.Impl.IO.XMLDocument.W3C.Signature;


namespace WSDescargaMasivaSAT.Impl.http.clienteSoap.IO.XMLDocument.Autenticacion
{
    public class AutenticacionSerializador : ISerializador<AutenticacionMeta>
    {

        private string randomId = $"uuid-{Guid.NewGuid()}-1"; 
        private XmlDocument _soapEnvelopeDocument;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="XML"></param>
        /// <returns></returns>
        public AutenticacionMeta Deserializador(string XML)
        {
            _soapEnvelopeDocument = new XmlDocument();
            _soapEnvelopeDocument.LoadXml(XML);

            string token = _soapEnvelopeDocument.GetElementsByTagName("AutenticaResult")[0].InnerXml;


            AutenticacionMeta autenticacion = new AutenticacionMeta();
            autenticacion.IdToken = token;


            return autenticacion;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_parametros"></param>
        /// <returns></returns>
        public XmlDocument Serializador(Parametros _parametros)
        {


            _soapEnvelopeDocument = new XmlDocument();

            _parametros.UUIDiRamdon = randomId;

            XmlElement envelope = serializarDeveloper(_soapEnvelopeDocument);
           


            XmlElement header = Header.XmlHeader(_soapEnvelopeDocument);
            envelope.AppendChild(header);


            XmlElement body = serializarBody(_soapEnvelopeDocument);
            envelope.AppendChild(body);

            XmlElement autentica = serializarAutentica(_soapEnvelopeDocument);
            body.AppendChild(autentica);


            XmlElement security = serializarSecurity(_soapEnvelopeDocument);
            header.AppendChild(security);


            XmlElement timestamp = serializarTimestamp(_soapEnvelopeDocument);
            security.AppendChild(timestamp);


            XmlElement binariySecurityToken =  serializarBinarySecurityToken(
                _soapEnvelopeDocument,
                _parametros.UUIDiRamdon,
                _parametros.certificado.getX509Certificate2());

            security.AppendChild(binariySecurityToken);


          
            _soapEnvelopeDocument.AppendChild(envelope);


            XmlElement signature = siganatureXML(_soapEnvelopeDocument, _parametros);


            security.AppendChild(signature);


            _soapEnvelopeDocument.ImportNode(security, true);



            return _soapEnvelopeDocument;
          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private XmlElement serializarDeveloper(XmlDocument doc)
        {
            
            

            Envelope envelopeXML = new Envelope();
            XmlElement envelope = envelopeXML.XmlEnvelopeElement(_soapEnvelopeDocument);
            envelopeXML.XMlAttributeListXMLN_SU(envelope);

            return  envelope;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private XmlElement serializarBody(XmlDocument doc)
        {
            Body bodyXML = new Body();
            XmlElement body = bodyXML.XmlBodyXMlElement(_soapEnvelopeDocument);

            return body;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private XmlElement serializarAutentica(XmlDocument doc)
        {
            XmlElement autentica =  Autentica.xmlBodyAutentica(_soapEnvelopeDocument);

            return autentica;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private XmlElement serializarSecurity(XmlDocument doc)
        {

            List<ParametroXmlElement> listaParametro = new List<ParametroXmlElement>();
            ParametroXmlElement parametro = new ParametroXmlElement();
            parametro.Prefix = "mustUnderstand";
            parametro.LocalName ="http://schemas.xmlsoap.org/soap/envelope/";
            parametro.NameSpaceURI = "1";
            listaParametro.Add(parametro);


            Security security = new Security();
            XmlElement securityXMl = security.XmlSecurity(_soapEnvelopeDocument);
            security.XMlAttributeList(securityXMl, listaParametro);
            return securityXMl;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="uuid"></param>
        /// <param name="certificado2"></param>
        /// <returns></returns>
        private XmlElement serializarBinarySecurityToken(XmlDocument doc, string uuid, X509Certificate2 certificado2)
        {
            BinarySecurityToken binary = new BinarySecurityToken();
            XmlElement binaryXML= binary.XmlSecurityBinarySecurityToken(doc);

            binary.addXMlAttributeId(binaryXML, uuid);
            binary.addXMlAttributeValueType(binaryXML);
            binary.addXMlAttributeEncodingTypee(binaryXML);
            binary.addXInnertTexteSecurity(binaryXML, certificado2);

            return binaryXML;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private XmlElement serializarTimestamp(XmlDocument doc)
        {

            Timestamp timestamp = new Timestamp();

            XmlElement timestampxml = timestamp.XmlSecurityTimeStap(doc);


            timestampxml.AppendChild(timestamp.XmlTimestampCreate(doc));
            timestampxml.AppendChild(timestamp.XmlTimestampExperired(doc));


            return timestampxml;
        }




        private XmlElement siganatureXML(XmlDocument doc, Parametros parametro)
        {
            if (doc == null)
                throw new ArgumentException("xmlDoc");


            PrivateKeyRSACryptoServiceWC3 privaKeryRSQ = new PrivateKeyRSACryptoServiceWC3(parametro.certificado.getX509Certificate2());
            privaKeryRSQ.extraerPrivateKeyRSACryptoServiceProvider();

   


            SignedInfoWC3 signeInfo = new SignedInfoWC3(doc, parametro.UUIDiRamdon);
            KeyInfoNode info = signeInfo.addSecurityTokenReference();
            KeyInfo keyInfo = new KeyInfo();
            keyInfo.AddClause(info);




            ReferenceWC3 referenceXML = new ReferenceWC3($"#_0",SignedXml.XmlDsigSHA1Url);
            referenceXML.addDigestMethod();
            referenceXML.addUri();
            referenceXML.addTransform();





            var signedXml = new SignedXmlWithId(doc);


            signedXml.SigningKey = parametro.certificado.getX509Certificate2().PrivateKey;


            signedXml.SignedInfo.SignatureMethod = SignedXml.XmlDsigRSASHA1Url;
            signedXml.SignedInfo.CanonicalizationMethod = SignedXml.XmlDsigExcC14NTransformUrl;
            signedXml.AddReference(referenceXML.getRefence());



            signedXml.KeyInfo = keyInfo;



            signedXml.ComputeSignature();
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            return xmlDigitalSignature;
        }
      
    }
}
