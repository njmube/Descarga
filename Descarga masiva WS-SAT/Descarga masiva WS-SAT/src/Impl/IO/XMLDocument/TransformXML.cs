﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using System.Xml;

namespace WSDescargaMasivaSAT.Impl.IO.XMLDocument
{
    public class TransformXML
    {
        private string _prefix;
        private string _localName;
        private string _namesSpaceUri;

        public TransformXML(string prefix = null, string localName = null, string namesSpaceURI = null)
        {
            _prefix = String.IsNullOrEmpty(prefix) ? "o" : prefix;
            _localName = string.IsNullOrEmpty(localName) ? "Transform" : localName;
            _namesSpaceUri = String.IsNullOrEmpty(namesSpaceURI) ? "http://www.w3.org/2000/09/xmldsig#" : namesSpaceURI;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public XmlElement XmlElement(XmlDocument doc)
        {
            XmlElement xml = doc.CreateElement(_localName, _namesSpaceUri);
            return xml;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="securityElement"></param>
        /// <param name="listaParametrosXmlelement"></param>
        public void XMlAttributeAlgorithm(XmlElement securityElement, ParametroXmlElement parametroElement = null)
        {
            securityElement.SetAttribute("Algorithm", "http://www.w3.org/2001/10/xml-exc-c14n#");


        }

    }
}
