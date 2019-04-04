using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace WSSATMasiva
{
    public class SecurityToken
    {
        private X509Certificate2 _X509Certificate2;

        public SecurityToken(X509Certificate2 X509Certificate2)
        {
            _X509Certificate2 = X509Certificate2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string convertDataToBase64()
        {
           
            string Data = Convert.ToBase64String(_X509Certificate2.GetRawCertData());

           //RSA example  = _X509Certificate2.GetRSAPrivateKey();
            return Data;

        }

        internal string getSecurityTokenToBase64()
        {
            return convertDataToBase64();
        }
    }
}
