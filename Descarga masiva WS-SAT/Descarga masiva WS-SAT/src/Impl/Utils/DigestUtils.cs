using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Descarga_masiva_WS_SAT.src.Impl.Utils
{
    public class DigestUtils
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceData"></param>
        /// <returns></returns>
        public static string CreateDigest(string sourceData)
        {
            byte[] data = GetBytes(sourceData);
            return System.Convert.ToBase64String(HashAlgorithm.Create("SHA1").ComputeHash(data));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceData"></param>
        /// <returns></returns>
        public static byte[] GetBytes(string sourceData)
        {
            return Encoding.Default.GetBytes(sourceData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceData"></param>
        /// <param name="certificate"></param>
        /// <returns></returns>
        public static string Sign(string sourceData, X509Certificate2 certificate)
        {
            byte[] data = GetBytes(sourceData);
            byte[] signature = null;


            SHA1 sha1 = new SHA1CryptoServiceProvider();


            //CryptoConfig.MapNameToOID("SHA256")
            using (RSACryptoServiceProvider rsaCryptoServiceProvider = (RSACryptoServiceProvider)certificate.PrivateKey)
            {
                signature = rsaCryptoServiceProvider.SignData(data, sha1);
            }


            return System.Convert.ToBase64String(signature);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="certificate"></param>
        /// <returns></returns>
        public static string convertToBase64X509Certificate(X509Certificate2 certificate)
        {
            return Convert.ToBase64String(certificate.RawData); ;
        }
    }
}
}
