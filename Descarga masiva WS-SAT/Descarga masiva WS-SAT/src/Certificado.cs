using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Descarga_masiva_WS_SAT.src
{
    public class Certificado
    {
        public enum SignAlgorithm
        {
            Sha1 = 0,
            Sha256 = 1
        }

        /// <summary>
        /// 
        /// </summary>
        private string _passsword;

        /// <summary>
        /// Cadena del archivo pfx convertido en binario, para que sea mas facil de digerir.
        /// </summary>
        private Byte[] _pfx;

        /// <summary>
        /// 
        /// </summary>
        private bool _useMachineKeyStore;

        public Certificado(byte[] pfx, string password, bool useMachineKeyStore = false)
        {
            _pfx = pfx;
            _passsword = password;
            _useMachineKeyStore = useMachineKeyStore;


        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public X509Certificate2 getX509Certificate2()
        {
            return extraerInformacionPFX();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private X509Certificate2 extraerInformacionPFX()
        {
            return new X509Certificate2(_pfx, _passsword, X509KeyStorageFlags.DefaultKeySet);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="useMachineKeyStore"></param>
        /// <returns></returns>
        private X509KeyStorageFlags GetKeyStorageFlags(bool useMachineKeyStore)
        {
            if (useMachineKeyStore)
            {
                return X509KeyStorageFlags.Exportable | X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet;
            }

            return X509KeyStorageFlags.Exportable;
        }
    }
}
