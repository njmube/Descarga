using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace Descarga_masiva_WS_SAT.src.Impl.Http.lSoap
{
    public class UserAgent
    {
        private HttpWebResponse httpWebResponse;
        private StreamReader streamReader;
        private String mediaType;
        private string _action = "";
        private XmlDocument soapEnvelopeXml;



        public UserAgent()
        {

            httpWebResponse = null;
            streamReader = null;
        }

        /// <summary>
        /// Realiza una petición a un servidor web.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Response open(Request request)
        {
            HttpWebRequest httpWebRequest = null;

            if (request.getMethod().ToString() == Request.HttpMethod.POST.ToString())
            {
                httpWebRequest = WebRequest(request);

                soapEnvelopeXml = request.getXMlDocument();

                string xml = soapEnvelopeXml.OuterXml;
                using (Stream stream = httpWebRequest.GetRequestStream())
                {
                    using (StreamWriter stmw = new StreamWriter(stream))
                    {
                        stmw.Write(xml);
                    }
                }


                httpWebResponse = default(HttpWebResponse);


            }
            RawResponse rawResponse = openRaw(httpWebRequest);
            return new Response(rawResponse.getXML(), rawResponse.getContenido(), rawResponse.getCode());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private RawResponse openRaw(HttpWebRequest request)
        {
            RawResponse rawResponse = null;
            try
            {

                try
                {
                    httpWebResponse = (HttpWebResponse)request.GetResponse();


                }
                catch (WebException ex)
                {
                    httpWebResponse = (HttpWebResponse)ex.Response;

                }

                int code = (int)httpWebResponse.StatusCode;
                String mensajeCode = httpWebResponse.StatusCode.ToString();

                streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8);

                String responseFromServer = streamReader.ReadToEnd();

                rawResponse = new RawResponse(mensajeCode, code, responseFromServer);


            }
            catch (IOException e)
            {

                throw new Exception(e.Message);
            }

            finally
            {
                httpWebResponse.Close();
            }
            return rawResponse;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="URL"></param>
        /// <param name="SOAPAction"></param>
        /// <param name="maxTimeMilliseconds"></param>
        /// <returns></returns>
        private static HttpWebRequest WebRequest(Request request)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(request.getURI().AbsoluteUri.ToString());
            httpWebRequest.Timeout = request.MaxTimeMilliseconds;
            httpWebRequest.Method = request.getMethod().ToString();
            httpWebRequest.ContentType = "text/xml; charset=utf-8";
            httpWebRequest.Headers.Add("SOAPAction: " + request.SoapActionPath);


            if (request.getWSSAT() == Request.WS_SAT.SOLICITUD)
            {

                httpWebRequestHeadersWRAPaccess_token(httpWebRequest, request.Token);
            }


            if (request.getWSSAT() == Request.WS_SAT.DESCARGA)
            {
                httpWebRequestHeadersWRAPaccess_token(httpWebRequest, request.Token);
                httpWebRequest.Accept = "Accept-Encoding: gzip, deflate";
            }

            return httpWebRequest;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpWebReques"></param>
        /// <param name="token"></param>
        private static void httpWebRequestHeadersWRAPaccess_token(HttpWebRequest httpWebReques, string token)
        {
            httpWebReques.Headers["Authorization"] = "WRAP access_token=\"" + HttpUtility.UrlDecode(token) + "\"";
        }


        /// <summary>
        /// Realiza las operaciones necesarias para liberar los recursos utilizados.
        /// </summary>
        public void close()
        {
            try
            {
                httpWebResponse.Close();
            }
            catch (IOException e)
            {

                throw new IOException(e.Message); ;
            }


        }

    }
}
