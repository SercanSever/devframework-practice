using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttıngConcerns.Logging.Log4Net
{
    [Serializable]
    public class SerializableLogEvent
    {
        LoggingEvent _logginEvent;
        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _logginEvent = loggingEvent;
        }

        public string UserName => _logginEvent.UserName;
        public object MessageObject => _logginEvent.MessageObject;
    }
}
