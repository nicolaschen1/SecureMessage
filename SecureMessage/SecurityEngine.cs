/*
SecureMessage
VERSION: 1.0

Inputs: Message to encrypt.

Outputs: Encrypted message.

Description: This software tool allows to encrypt and decrypt a message.

Developer: Nicolas CHEN
*/

using System;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;

namespace SecureMessage
{
    public class SecurityEngine
    {
        // Method to encrypt the initial message
        public static string EncryptMessage(string messageToEncrypt, bool isHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(messageToEncrypt);

            AppSettingsReader settingsReader = new AppSettingsReader();
            
            // Get the key from configuration file
            string key = (string)settingsReader.GetValue("CryptoKey", typeof(String));
            
            if (isHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        

        // Method to decrypt the cipher message
        public static string DecryptMessage(string cipherMessage, bool isHashing)
        {               
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherMessage);

            AppSettingsReader settingsReader = new AppSettingsReader();
            //Get your key from config file to open the lock!
            string key = (string)settingsReader.GetValue("CryptoKey", typeof(String));

            if (isHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);   
        }
    }
}