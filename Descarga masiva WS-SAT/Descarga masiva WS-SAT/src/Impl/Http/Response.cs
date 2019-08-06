using System;

namespace Descarga_masiva_WS_SAT.src.Impl.Http
{
    public class Response
    {
        private String rawResponse;
        private int code;
        private String xml;
        private XmlDocument soapEnvelopeXml;

        public Response(String xml, String rawResponse, int code)
        {
            this.xml = xml;
            this.rawResponse = rawResponse;
            this.code = code;
        }


        public string getXML()
        {
            return this.xml;
        }

        public String getRawResponse()
        {
            return this.rawResponse;
        }

        public int getCode()
        {
            return this.code;

        }
    }
}
