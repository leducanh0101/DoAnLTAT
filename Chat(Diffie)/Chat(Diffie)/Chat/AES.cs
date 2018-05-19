using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace A
{
    class AES
    {
       

        public string Encrypt(string key, string rawData, string dateTime)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("key", "Key must not be empty");
           byte[][] keys = GetHashKeys(key, dateTime);//mảng chứa mảng [key][time]
            string encData = EncryptStringToBytes_Aes(rawData, keys[0], keys[1]);
            return encData;
        }

        

        public string Decrypt(string key, string encryptedData, string dateTime)
        {
            string decData = null;
            byte[][] keys = GetHashKeys(key, dateTime);

            try
            {
                decData = DecryptStringFromBytes_Aes(encryptedData, keys[0], keys[1]);
            }
            catch (CryptographicException) { }
            catch (ArgumentNullException) { }

            return decData;
        }
        //=============================================================================

        
        private byte[][] GetHashKeys(string key, string dateTime)//băm key và iv ra
        {
            byte[][] result = new byte[2][];
            Encoding enc = Encoding.UTF8;

            SHA256 sha2 = new SHA256CryptoServiceProvider();

            byte[] rawKey = enc.GetBytes(key);
            byte[] rawIV = enc.GetBytes(dateTime);
            

            byte[] hashKey = sha2.ComputeHash(rawKey);//32 bytes

            byte[] hashIV = sha2.ComputeHash(rawIV);//32 bytes

            Array.Resize(ref hashIV, 16);//resize thành 16 bytes

            result[0] = hashKey;
            result[1] = hashIV;

            return result;
        }
        private static string EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV) //chuyen doi string to byte
        {
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length < 16)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length < 16)
                throw new ArgumentNullException("IV");

            byte[] encrypted;

            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt =
                            new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(encrypted);
            //return Encoding.ASCII.GetString(encrypted);
        }

        //============================================================================

        private static string DecryptStringFromBytes_Aes(string cipherTextString, byte[] Key, byte[] IV) // tu byte ve string
        {
            byte[] cipherText = Convert.FromBase64String(cipherTextString);
            ;
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            string plaintext = null;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt =
                            new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }
    }
}
