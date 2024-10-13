using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotus_Server_Form
{
    internal class EventLogger
    {
        private Action<string> logAction;

        public EventLogger(Action<string> logAction)
        {
            this.logAction = logAction;
        }

        public void Log(string eventMessage)
        {
            logAction($"{eventMessage} / {DateTime.Now}");
        }
    }
}
