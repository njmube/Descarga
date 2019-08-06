using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using System.Xml;

namespace WSDescargaMasivaSAT.Impl.http.clienteSoap.IO
{
    public class Transforms
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static XmlElement xmlReferenceTransforms(XmlDocument doc)
        {
            XmlElement transformsXML = doc.CreateElement("Transforms");
            transformsXML.AppendChild(xmlTransformsTransform(doc));
            return transformsXML;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private static XmlElement xmlTransformsTransform(XmlDocument doc)
        {
            XmlElement transformXML = doc.CreateElement("Transform");
            transformXML.SetAttribute("Algorithm", "http://www.w3.org/2001/10/xml-exc-c14n#");

            return transformXML;
        }
    }
}
