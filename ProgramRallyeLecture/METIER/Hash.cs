using System;
using System.Text;
using System.Security.Cryptography;

namespace Metier
{
    public class Hash
    {
        private string Sha264(string passWord)
        {
            var message = Encoding.ASCII.GetBytes(passWord);
            SHA256Managed hashString = new SHA256Managed();
            string hex = "";
            // rajouter l'id. 
            var hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }

        private string Salt(string passWord, int size)
        {
            var random = new RNGCryptoServiceProvider();
            // Maximum length of salt
            int max_length = 32;
            // Empty salt array
            byte[] salt = new byte[max_length];
            // Build the random bytes
            random.GetNonZeroBytes(salt);
            // Return the string encoded salt
            return Convert.ToBase64String(salt);
        }

        public string GetHashPassword(string passWord)
        {
            return Sha264(passWord);
        }
    }
}
