using Descarga_masiva_WS_SAT.src;
using Descarga_masiva_WS_SAT.src.Impl.Meta;
using Descarga_masiva_WS_SAT.src.Impl.Utils;
using System;
using System.Collections.Generic;

using System.Xml;
using WSDescargaMasivaSAT.Impl.IO.XMLDocument;


namespace WSDescargaMasivaSAT.Impl.http.clienteSoap.IO.XMLDocument.Verificacion
{
    /// <summary>
    /// TODO: Quitar los try y catch cuando lanza una exepción, ya que esto alentaría 
    /// el proceso de consulta, checar código en CSReporter.
    /// </summary>
    class VerificadorSerializador : ISerializador<VerificadorMeta>
    {

        private XmlDocument _soapEnvelopeDocument;


        public VerificadorMeta Deserializador(string XML)
        {

            List<String> listaUUID = new List<string>();

             _soapEnvelopeDocument = new XmlDocument();
            _soapEnvelopeDocument.LoadXml(XML);

            XmlNode SolicitaDescargaResult = _soapEnvelopeDocument.GetElementsByTagName("VerificaSolicitudDescargaResult")[0];

            XmlNodeList SolicitaDescargaIdPaquetes = _soapEnvelopeDocument.GetElementsByTagName("IdsPaquetes");


            string estadoSolicitud = SolicitaDescargaResult.Attributes["EstadoSolicitud"].Value;
            string codigoEstatus = SolicitaDescargaResult.Attributes["CodEstatus"].Value;

            TipoEstatus tipoCodigoEstatus =  TipoEstatus.parseCodigoEstatus(codigoEstatus);


            string codigoEstadoSolicitud = "";

            try
            {
                codigoEstadoSolicitud = SolicitaDescargaResult.Attributes["CodigoEstadoSolicitud"].Value;
            }
            catch (Exception)
            {

               
            }

            
            string numeroCFDIs = SolicitaDescargaResult.Attributes["NumeroCFDIs"].Value;
            string mensaje = SolicitaDescargaResult.Attributes["Mensaje"].Value;



            foreach(XmlNode attribute in SolicitaDescargaIdPaquetes)
            {

                string uuid = attribute.InnerText;

                listaUUID.Add(uuid);
            }




            VerificadorMeta verificadorMeta = new VerificadorMeta();
            verificadorMeta.EstadoSolicitud = estadoSolicitud;
            verificadorMeta.CodigoEstatus = tipoCodigoEstatus;
            verificadorMeta.CodigoEstadoSolicitud = codigoEstadoSolicitud;
            verificadorMeta.NumeroCFDIs = numeroCFDIs;
            verificadorMeta.Mensaje = mensaje;
            verificadorMeta.ListaIdPaquestes = listaUUID;

            return verificadorMeta;

        }


        public XmlDocument Serializador(Parametros parametro)
        {
            _soapEnvelopeDocument = new XmlDocument();

            XmlElement envelopeXML = serializarDeveloper(_soapEnvelopeDocument);


            XmlElement header = Header.XmlHeader(_soapEnvelopeDocument);
            envelopeXML.AppendChild(header);


            XmlElement bodyXML = serializarBody(_soapEnvelopeDocument);
            envelopeXML.AppendChild(bodyXML);


            XmlElement verificarSolicitud = serializarVerificaSolicitudDescarga(_soapEnvelopeDocument);
            bodyXML.AppendChild(verificarSolicitud);



            XmlElement solicitudXMl = serializarSolicitud(_soapEnvelopeDocument, parametro.IDSolicitud, parametro.RFCSolicitane.getValor());
            var importNode = verificarSolicitud.AppendChild(solicitudXMl);


            _soapEnvelopeDocument.AppendChild(envelopeXML);



            var importeNode23 = new XmlDocument();
            importeNode23.LoadXml(verificarSolicitud.OuterXml);


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

            return body;
        }


        private XmlElement serializarVerificaSolicitudDescarga(XmlDocument doc)
        {
            VerificaSolicitudDescargaXML verificaSolicitudDescargaXML = new VerificaSolicitudDescargaXML();

            XmlElement verificarSolicitud = verificaSolicitudDescargaXML.XmlXMlElement(doc);

            return verificarSolicitud;

        }


        private XmlElement serializarSolicitud(XmlDocument doc, string idSolicitud, string rfcSolicitante)
        {
            WSDescargaMasivaSAT.Impl.IO.XMLDocument.Solicitud solicituds = new WSDescargaMasivaSAT.Impl.IO.XMLDocument.Solicitud();
            XmlElement solicitudXML = solicituds.XmlBodyXMlElement(doc);
            solicituds.XMlAttributeIdSolicitud(solicitudXML, idSolicitud);
            solicituds.XMlAttributeRfcSolicitante(solicitudXML,rfcSolicitante);

            return solicitudXML;
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
    }
}
