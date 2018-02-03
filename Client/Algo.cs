
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Client
{
    class Algo
    {
        private static string desKey = "32ADFE82";

        public static string DESEncrypt(string plaintext)
        {
            byte[] data = Encoding.UTF8.GetBytes(plaintext);
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(desKey);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(desKey);
            ICryptoTransform desencrypt = DES.CreateEncryptor();
            byte[] result = desencrypt.TransformFinalBlock(data, 0, data.Length);
            return BitConverter.ToString(result);
        }

        public static string DESDecrypt(string ciphertext)
        {
            string[] sInput = ciphertext.Split("-".ToCharArray());
            byte[] data = new byte[sInput.Length];
            for (int i = 0; i < sInput.Length; i++)
            {
                data[i] = byte.Parse(sInput[i], NumberStyles.HexNumber);
            }
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(desKey);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(desKey);
            ICryptoTransform desencrypt = DES.CreateDecryptor();
            byte[] result = desencrypt.TransformFinalBlock(data, 0, data.Length);
            return Encoding.UTF8.GetString(result);
        }
    }
}
