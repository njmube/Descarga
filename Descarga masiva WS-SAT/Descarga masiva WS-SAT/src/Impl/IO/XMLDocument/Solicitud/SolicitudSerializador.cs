using Descarga_masiva_WS_SAT.src;
using Descarga_masiva_WS_SAT.src.Impl.Meta;
using Descarga_masiva_WS_SAT.src.Impl.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
 
using System.Xml;
using WSDescargaMasivaSAT.Impl.IO;
using WSDescargaMasivaSAT.Impl.IO.XMLDocument;


namespace WSDescargaMasivaSAT.Impl.http.clienteSoap.IO.XMLDocument.Solicitud
{
    public class SolicitudDeserializador : ISerializador<SolicitudDescargaMeta>
    {

        private XmlDocument _soapEnvelopeDocument;

        public SolicitudDescargaMeta Deserializador(string XML)
        {
            _soapEnvelopeDocument = new XmlDocument();
            _soapEnvelopeDocument.LoadXml(XML);

            XmlNode SolicitaDescargaResult = _soapEnvelopeDocument.GetElementsByTagName("SolicitaDescargaResult")[0];


            SolicitudDescargaMeta solicitud = new SolicitudDescargaMeta();
            string idSolicitud = "";
            string codigoEstatus = "";


            try
            {
                idSolicitud = SolicitaDescargaResult.Attributes["IdSolicitud"].Value;
            }
            catch (Exception)
            {

           
            }

            try
            {
                codigoEstatus = SolicitaDescargaResult.Attributes["CodEstatus"].Value;
            }
            catch (Exception)
            {

                codigoEstatus = "404";
            }

            TipoEstatus tipoCodigoEstatus = TipoEstatus.parseCodigoEstatus(codigoEstatus);

         string mensaje = SolicitaDescargaResult.Attributes["Mensaje"].Value;



            solicitud.IdSolicitud = idSolicitud;
            solicitud.CodigoEstatus = tipoCodigoEstatus;
            solicitud.Mensaje = mensaje;



            return solicitud;
        }

        public XmlDocument Serializador(Parametros _parametros)
        {
            _soapEnvelopeDocument = new XmlDocument();

           

            XmlElement envelopeXML = serializarDeveloper(_soapEnvelopeDocument);

            XmlElement header = Header.XmlHeader(_soapEnvelopeDocument);
            envelopeXML.AppendChild(header);

            XmlElement bodyXML = serializarBody(_soapEnvelopeDocument);
            envelopeXML.AppendChild(bodyXML);



            XmlElement solicitudDescargaXML = serializarSolicitudDescarga(_soapEnvelopeDocument);
            bodyXML.AppendChild(solicitudDescargaXML);


            XmlElement solicitudXMl = serializarSolicitud(_soapEnvelopeDocument, _parametros);
            var importNode = solicitudDescargaXML.AppendChild(solicitudXMl);


            _soapEnvelopeDocument.AppendChild(envelopeXML);



            var importeNode23 = new XmlDocument();
            importeNode23.LoadXml(solicitudDescargaXML.OuterXml);


            XmlElement signature2 = siganatureXML(importeNode23, _parametros);


            var importNode2 = _soapEnvelopeDocument.ImportNode(signature2, true);
            importNode.AppendChild(importNode2);



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
            envelopeXML.XMlAttributeListXMLNS_DES(envelope);
            envelopeXML.XMlAttributeListXMLNS_XS(envelope);


            return envelope;
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
            //bodyXML.XMlAttributeListXSI(body);
            //bodyXML.XMlAttributeListXSD(body);


            return body;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private XmlElement serializarSolicitudDescarga(XmlDocument doc)
        {
            SolicitaDescarga solicitudDescarga = new SolicitaDescarga();

            XmlElement solicitudDescargaXMl =  solicitudDescarga.XmlBodyXMlElement(doc);
         
            return solicitudDescargaXMl;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private XmlElement serializarSolicitud(XmlDocument doc, Parametros parametro)
        {
            WSDescargaMasivaSAT.Impl.IO.XMLDocument.Solicitud solicituds = new WSDescargaMasivaSAT.Impl.IO.XMLDocument.Solicitud();
            XmlElement solicitudXML =  solicituds.XmlBodyXMlElement(doc);


            if (!(parametro.RFCEmisor == null))
            {
                solicituds.XMlAttributeRFCEmisor(solicitudXML, parametro.RFCEmisor.getValor());
            }

            if (!(parametro.RFCReceptor == null))
            {
                solicituds.XMlAttributeRFCREceptor(solicitudXML, parametro.RFCReceptor.getValor());
            }
               
            solicituds.XMlAttributeRFCSolicitando(solicitudXML, parametro.RFCSolicitane.getValor());
            solicituds.XMlAttributeFechaInicial(solicitudXML, parametro.FechaInicial);
            solicituds.XMlAttributeFechaFinal(solicitudXML, parametro.FechaFinal);
            solicituds.XMlAttributeTipoSolicitud(solicitudXML, parametro.TipoSolicitud);


            return solicitudXML;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="parametro"></param>
        /// <returns></returns>
        private XmlElement siganatureXML(XmlDocument doc, Parametros parametro)
        {
            if (doc == null)
                throw new ArgumentException("xmlDoc");

            var xmlDocumentSignature = new XmlDocument();


            SignatureXML signatureXML = new SignatureXML();

            XmlElement Signature = signatureXML.XmlElement(xmlDocumentSignature);



            //SignedInfo
            SignedInfoXMl SignedInfoXMl = new SignedInfoXMl();
            XmlElement SignedInfoxml = SignedInfoXMl.XmlElement(xmlDocumentSignature);


            CanonicalizationMethodXML CanonicalizationMethodXML = new CanonicalizationMethodXML();
            XmlElement CanonicalizationMethodxml = CanonicalizationMethodXML.XmlElement(xmlDocumentSignature);
            CanonicalizationMethodXML.XMlAttributeAlgorithm(CanonicalizationMethodxml);


            SignatureMethodXML SignatureMethodXML = new SignatureMethodXML();
            XmlElement SignatureMethodxml = SignatureMethodXML.XmlElement(xmlDocumentSignature);
            SignatureMethodXML.XMlAttributeAlgorithm(SignatureMethodxml);


            ReferenceXML ReferenceXML = new ReferenceXML();
            XmlElement Referencexml = ReferenceXML.XmlElement(xmlDocumentSignature);
            ReferenceXML.XMlAttributeURI(Referencexml);



            TransformsXML TransformsXML = new TransformsXML();
            XmlElement Transformsxml = TransformsXML.XmlElement(xmlDocumentSignature);

            TransformXML TransformXML = new TransformXML();
            XmlElement Transformxml = TransformXML.XmlElement(xmlDocumentSignature);
            TransformXML.XMlAttributeAlgorithm(Transformxml);


            Transformsxml.AppendChild(Transformxml);


            Referencexml.AppendChild(Transformsxml);


            string digest = DigestUtils.CreateDigest(doc.OuterXml);

            DigestMethodXML DigestMethodXML = new DigestMethodXML();
            XmlElement DigestMethodxml = DigestMethodXML.XmlElement(xmlDocumentSignature);
            DigestMethodXML.XMlAttributeAlgorithm(DigestMethodxml);
            Referencexml.AppendChild(DigestMethodxml);


            DigestValueXML DigestValueXML = new DigestValueXML();
            XmlElement DigestValuexml = DigestValueXML.XmlElement(xmlDocumentSignature); ;
            DigestValuexml.InnerText = digest;


            Referencexml.AppendChild(DigestValuexml);

            SignedInfoxml.AppendChild(CanonicalizationMethodxml);
            SignedInfoxml.AppendChild(SignatureMethodxml);
            SignedInfoxml.AppendChild(Referencexml);


            //SignedInfo

        


            string signature = DigestUtils.Sign(SignedInfoxml.OuterXml, parametro.certificado.getX509Certificate2());


            //SignatureValue
            SignatureValueXML SignatureValueXML = new SignatureValueXML();
            XmlElement SignatureValuexml = SignatureValueXML.XmlElement(xmlDocumentSignature);
            SignatureValuexml.InnerText = signature;
            //SignatureValue




            //KeyInfo
            KeyInfoXML KeyInfoXML = new KeyInfoXML();
            XmlElement KeyInfoXMl = KeyInfoXML.XmlElement(xmlDocumentSignature);

            X509DataXML X509Data = new X509DataXML();
            XmlElement X509DataXML = X509Data.XmlElement(xmlDocumentSignature);

            X509IssuerSerialXML X509IssuerSerialXML = new X509IssuerSerialXML();
            XmlElement x5019Issuer = X509IssuerSerialXML.XmlElement(xmlDocumentSignature);

            X509IssuerNameXML X509IssuerNameXML = new X509IssuerNameXML();
            XmlElement X509IssuerName = X509IssuerNameXML.XmlElement(xmlDocumentSignature);
            X509IssuerName.InnerText = parametro.certificado.getX509Certificate2().IssuerName.Name;
            x5019Issuer.AppendChild(X509IssuerName);

            X509SerialNumberXML X509SerialNumberXML = new X509SerialNumberXML();
            XmlElement X509SerialNumber = X509SerialNumberXML.XmlElement(xmlDocumentSignature);
            X509SerialNumber.InnerText = parametro.certificado.getX509Certificate2().GetSerialNumberString();
            x5019Issuer.AppendChild(X509SerialNumber);

            X509DataXML.AppendChild(x5019Issuer);
            KeyInfoX509Data keyInfoData = new KeyInfoX509Data(parametro.certificado.getX509Certificate2());


            X509CertificateXML X509Certificate = new X509CertificateXML();
            XmlElement X509CertificateXML = X509Certificate.XmlElement(xmlDocumentSignature);
            X509CertificateXML.InnerText = DigestUtils.convertToBase64X509Certificate(parametro.certificado.getX509Certificate2());
            X509DataXML.AppendChild(X509CertificateXML);

            KeyInfoXMl.AppendChild(X509DataXML);

            //KeyInfo




            Signature.AppendChild(SignedInfoxml);

            Signature.AppendChild(SignatureValuexml);

            Signature.AppendChild(KeyInfoXMl);



            xmlDocumentSignature.AppendChild(Signature);




            return Signature;
        }


        /*
        private void extraerInfoSignature2(XmlDocument doc, Parametros parametro)
        {
            if (doc == null)
                throw new ArgumentException("xmlDoc");




            PrivateKeyRSACryptoServiceWC3 privaKeryRSQ = new PrivateKeyRSACryptoServiceWC3(parametro.certificado.getX509Certificate2());
            privaKeryRSQ.extraerPrivateKeyRSACryptoServiceProvider();



            KeyInfo keyInfo = new KeyInfo();




            var xmlDocument2 = new XmlDocument();

            XmlElement autenticaXml = xmlDocument2.CreateElement("X509Data");



            XmlElement x5019Issuer = xmlDocument2.CreateElement("X509IssuerSerial");



            XmlElement X509IssuerName = xmlDocument2.CreateElement("X509IssuerName");
            X509IssuerName.InnerText = parametro.certificado.getX509Certificate2().IssuerName.Name;
            x5019Issuer.AppendChild(X509IssuerName);


            XmlElement X509SerialNumber = xmlDocument2.CreateElement("X509SerialNumber");
            X509SerialNumber.InnerText = parametro.certificado.getX509Certificate2().GetSerialNumberString();
            x5019Issuer.AppendChild(X509SerialNumber);



            autenticaXml.AppendChild(x5019Issuer);
            KeyInfoX509Data keyInfoData = new KeyInfoX509Data(parametro.certificado.getX509Certificate2());


            XmlElement X509CertificateXML = xmlDocument2.CreateElement("X509Certificate");
            X509CertificateXML.InnerText = "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";
            autenticaXml.AppendChild(X509CertificateXML);




            xmlDocument2.AppendChild(autenticaXml);

            KeyInfoNode node = new KeyInfoNode(xmlDocument2.DocumentElement);
            keyInfo.AddClause(node);


            /**

            KeyInfoX509Data kdata = new KeyInfoX509Data();


            X509IssuerSerial xserial= new X509IssuerSerial();
      
            string serialNumber = parametro.certificado.getX509Certificate2().GetSerialNumberString();

            xserial.IssuerName = parametro.certificado.getX509Certificate2().IssuerName.Name;
            xserial.SerialNumber = serialNumber;



            KeyInfoX509Data keyInfoData = new KeyInfoX509Data(parametro.certificado.getX509Certificate2());


            kdata.AddIssuerSerial(xserial.IssuerName, serialNumber);
            kdata.AddCertificate(parametro.certificado.getX509Certificate2());

   


            /// KeyInfoNode





            string xmlFormateado = "";
            xmlFormateado = doc.OuterXml;

            var referente = new Reference();
            referente.DigestValue = GetBytes(xmlFormateado);
            referente.DigestMethod = "http://www.w3.org/2000/09/xmldsig#sha1";
            referente.Uri = "";


            referente.AddTransform(new XmlDsigExcC14NTransform());


            var signedXml = new SignedXmlWithId(doc);


            signedXml.SigningKey = privaKeryRSQ.getPrivateKey();


            signedXml.SignedInfo.SignatureMethod = "http://www.w3.org/2000/09/xmldsig#rsa-sha1";
            signedXml.SignedInfo.CanonicalizationMethod = "http://www.w3.org/2001/10/xml-exc-c14n#";
            signedXml.AddReference(referente);
            //   signedXml.SignatureValue = parametro.certificado.getX509Certificate2().GetPublicKey


            signedXml.KeyInfo = keyInfo;



            signedXml.ComputeSignature();
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            return xmlDigitalSignature;
        } **/

        

  
  

   
    }
}
