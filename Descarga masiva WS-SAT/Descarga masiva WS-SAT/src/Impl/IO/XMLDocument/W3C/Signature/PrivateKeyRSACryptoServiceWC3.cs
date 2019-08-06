using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
 

namespace WSDescargaMasivaSAT.Impl.IO.XMLDocument.W3C.Signature
{
    public class PrivateKeyRSACryptoServiceWC3
    {
        /// <summary>
        /// 
        /// </summary>
        private X509Certificate2 _certificado;

        /// <summary>
        /// 
        /// </summary>
        private RSACryptoServiceProvider _privateKey;


        public PrivateKeyRSACryptoServiceWC3(X509Certificate2 certificado)
        {
            _certificado = certificado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public void extraerPrivateKeyRSACryptoServiceProvider()
        {

            _privateKey = _certificado.PrivateKey as RSACryptoServiceProvider;

            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public RSACryptoServiceProvider getPrivateKey()
        {
            return _privateKey;
        }
    }
}
