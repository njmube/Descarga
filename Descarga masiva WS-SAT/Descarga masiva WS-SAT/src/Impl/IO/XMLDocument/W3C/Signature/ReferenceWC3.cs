
using System.Security.Cryptography.Xml;


namespace WSDescargaMasivaSAT.Impl.IO.XMLDocument.W3C.Signature
{
    public class ReferenceWC3
    {
        /// <summary>
        /// 
        /// </summary>
        private Reference _referente;

        /// <summary>
        /// 
        /// </summary>
        private string _Uri;

        /// <summary>
        /// 
        /// </summary>
        private string _DigestMethod;

        public ReferenceWC3(string Uri, string digestMethod)
        {
            _Uri = Uri;
            _DigestMethod = digestMethod;

            _referente = new Reference();
        }

        /// <summary>
        /// 
        /// </summary>
        public void addUri()
        {
            _referente.Uri = _Uri;
        }

        /// <summary>
        /// 
        /// </summary>
        public void addDigestMethod()
        {
            _referente.DigestMethod = _DigestMethod;
        }


        /// <summary>
        /// 
        /// </summary>
        public void addTransform()
        {
            _referente.AddTransform(new XmlDsigExcC14NTransform());
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Reference getRefence()
        {
            return _referente;
        }


    }
}
