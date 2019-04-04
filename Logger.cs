using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace WSSATMasiva
{
    public class Logger
    {
        private Action<string, object> OnError { get; }

        private Action<string, object> OnInfo { get; }

        private Action<string, object> OnDebug { get; }


        public Logger(Action<string, object> onError, Action<string, object> onInfo = null, Action<string, object> onDebug = null)
        {
            OnError = onError;
            OnInfo = onInfo;
            OnDebug = onDebug;
        }

        public Logger(Action<string, object> eagerLogger)
        {
            OnError = eagerLogger;
            OnInfo = eagerLogger;
            OnDebug = eagerLogger;
        }


        public void Error(string message, object details = null)
        {
            Log(OnError, message, details);
        }

        public void Info(string message, object details = null)
        {
            Log(OnInfo, message, details);
        }

        public void Debug(string message, object details = null)
        {
            Log(OnDebug, message, details);
        }

        protected void Log(Action<string, object> loggerAction, string message, object details)
        {
            loggerAction?.Invoke(message, details);
        }
    }
}
