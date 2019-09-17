using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoClients.Api.Utils
{
    public static class Encripter
    {
        public static string Encrypt(string encryptString)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(encryptString);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        public static string Decrypt(string decryptString)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(decryptString);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
    }
}
