using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Descarga_masiva_WS_SAT.src.Impl.Utils
{
    public class DateUtility
    {
        public const string DateFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffZ";

        public static string DateForFile()
        {
            return DateTime.Now.ToString("yyyy'-'MM'-'dd HH'.'mm'.'ss");
        }
    }
}
