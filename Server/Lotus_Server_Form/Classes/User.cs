using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace Whispery.Data
{
    internal class UserControl
    {
        private string filePath = "users.txt";
        public string loginControl(string userName, string password) // 1 = onay, 0 = ret, 2 = sen kimsin gardaş
        {
            string[] userData = File.ReadAllLines(filePath);
            if (userData.Contains(userName))
            {
                int index = Array.IndexOf(userData, userName);
                if (password == userData[index + 1])
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return "2";
            }
        }
        public string registerControl(string userName, string password, string confirmPassword, string email) // 0 = kullanıcı zaten kayıtlı, 1 = email zaten var, 2 = kayıt yapıldı
        {
            string[] userData = File.ReadAllLines(filePath);
            if (userData.Contains(userName))
            {
                return "0";
            }
            else if (userData.Contains(email))
            {
                return "1";
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine(userName);
                    sw.WriteLine(password);
                    sw.WriteLine(email);
                }
                return "2";
            }

        }
    }
}
