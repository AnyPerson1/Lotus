using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.StaticVariables;

namespace Server.Logger
{
    public class Logger
    {
        public enum LogLayer
        {
            Layer1,
            Layer2,
            Layer3
        }
        public static void Log(string message, LogLayer layer)
        {
            switch (layer)
            {
                case LogLayer.Layer1:
                    StaticVariables.StaticVariables.Log1.Items.Add(message);
                    break;
                case LogLayer.Layer2:
                    StaticVariables.StaticVariables.Log2.Items.Add(message);
                    break;
                case LogLayer.Layer3:
                    StaticVariables.StaticVariables.Log3.Items.Add(message);
                    break;
                default:
                    break;
            }
        }
    }
}
