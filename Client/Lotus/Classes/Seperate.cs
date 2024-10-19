using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotus.Classes
{
    static class Seperate
    {
        public static string[] Data(string data)
        {
            string[] result = new string[2];
            result = data.Split(';');
            return result;
        }
    }
}
