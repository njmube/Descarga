using Descarga_masiva_WS_SAT.src;
using Descarga_masiva_WS_SAT.src.Impl.Meta;
using System;

using System.Xml;
using WSDescargaMasivaSAT.Impl.IO.XMLDocument;


namespace WSDescargaMasivaSAT.Impl.http.clienteSoap.IO.XMLDocument.Descarga
{
    public class DescargaSerializador : ISerializador<DescargaMeta>
    {

        private XmlDocument _soapEnvelopeDocument;

        public DescargaMeta Deserializador(string XML)
        {
            _soapEnvelopeDocument = new XmlDocument();
            _soapEnvelopeDocument.LoadXml(XML);

            XmlNode resultadoXML = _soapEnvelopeDocument.GetElementsByTagName("h:respuesta")[0];

            string paquete = _soapEnvelopeDocument.GetElementsByTagName("Paquete")[0].InnerXml;
            string codigoEstatus = resultadoXML.Attributes["CodEstatus"].Value;
            string mensaje = resultadoXML.Attributes["Mensaje"].Value;
            TipoEstatus tipoCodigoEstatus = TipoEstatus.parseCodigoEstatus(codigoEstatus);

           



            DescargaMeta descargaMeta = new DescargaMeta();
            descargaMeta.idPaquete = paquete;
            descargaMeta.CodigoEstatus = tipoCodigoEstatus;
            descargaMeta.Mensaje = mensaje;


            return descargaMeta;

        }

        public XmlDocument Serializador(Parametros parametro)
        {
            _soapEnvelopeDocument = new XmlDocument();


            XmlElement envelopeXML = serializarDeveloper(_soapEnvelopeDocument);

          

            XmlElement bodyXML = serializarBody(_soapEnvelopeDocument);
            envelopeXML.AppendChild(bodyXML);

            XmlElement peticionDescargaTerceroXMl = serializarPeticionDescargaMasivaTercerosEntrada(_soapEnvelopeDocument);
            bodyXML.AppendChild(peticionDescargaTerceroXMl);


            XmlElement peticionDescargaXML = serializadorPeticionDescarga(_soapEnvelopeDocument, parametro);
            var importNode = peticionDescargaTerceroXMl.AppendChild(peticionDescargaXML);

            _soapEnvelopeDocument.AppendChild(envelopeXML);

            var importeNode23 = new XmlDocument();
            importeNode23.LoadXml(peticionDescargaTerceroXMl.OuterXml);


            XmlElement signature2 = siganatureXML(importeNode23, parametro);


            var importNode2 = _soapEnvelopeDocument.ImportNode(signature2, true);
            importNode.AppendChild(importNode2);



            return _soapEnvelopeDocument;

        }

        private XmlElement serializarDeveloper(XmlDocument doc)
        {

            Envelope envelopeXML = new Envelope();
            XmlElement envelope = envelopeXML.XmlEnvelopeElement(_soapEnvelopeDocument);
            envelopeXML.XMlAttributeListXMLN_SU(envelope);
            envelopeXML.XMlAttributeListXMLNS_DES(envelope);
            envelopeXML.XMlAttributeListXMLNS_XS(envelope);


            return envelope;
        }


        private XmlElement serializarBody(XmlDocument doc)
        {
            Body bodyXML = new Body();


            XmlElement body = bodyXML.XmlBodyXMlElement(_soapEnvelopeDocument);
            bodyXML.XMlAttributeListXSI(body);
            bodyXML.XMlAttributeListXSD(body);


            return body;
        }


        private XmlElement serializarPeticionDescargaMasivaTercerosEntrada(XmlDocument doc)
        {
            PeticionDescargaMasivaTercerosEntradaXML peticionDescargaMasivaTercerosEntradaXML = new PeticionDescargaMasivaTercerosEntradaXML();

            XmlElement peticionDescargaMasivaTercero = peticionDescargaMasivaTercerosEntradaXML.XmlElement(doc);

            return peticionDescargaMasivaTercero;
        }

        private XmlElement serializadorPeticionDescarga(XmlDocument doc, Parametros parametro)
        {
            PeticionDescargaXML PeticionDescargaXML = new PeticionDescargaXML();

            XmlElement peticion = PeticionDescargaXML.XmlElement(doc);

            PeticionDescargaXML.XMlAttributeIdPaquete(peticion, parametro.IDPaquete);
            PeticionDescargaXML.XMlAttributeRfcSolicitante(peticion, parametro.RFCSolicitane.getValor());
        

            return peticion;
        }


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
          // KeyInfoX509Data keyInfoData = new KeyInfoX509Data(parametro.certificado.getX509Certificate2());


            X509CertificateXML X509Certificate = new X509CertificateXML();
            XmlElement X509CertificateXML = X509Certificate.XmlElement(xmlDocumentSignature);


           // KeyInfoX509Data keyInfoData2 = new KeyInfoX509Data(parametro.certificado.getX509Certificate2());


           

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

    }
}
