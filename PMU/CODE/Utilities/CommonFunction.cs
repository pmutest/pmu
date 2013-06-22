//======================================================================================================
// Created By :  Nishant Kumar
// Description:  Contains static common method which will going to use throughout application
// For Instance: Input validation
// Created On:   6/14/2013
//======================================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Globalization;

namespace PMU.CODE.Utilities
{
    public sealed class CommonFunction
    {

        private static bool invalid = false;

        #region Private method, utilities, constructor

        // Since this class method provide only static method, so make the
        // constructor private for preventing instantiation
        private CommonFunction(){}

        #endregion

        #region User Define Method

        /// <summary>
        /// Check validation of data which contains searching string 
        /// return false if searching string contains in input param
        /// otherwise it will return true
        /// </summary>
        public static bool IsContains(string inputText, List<string> searchingStringList)
        {
            bool isContaining = false;

            foreach (var searchingVal in searchingStringList)
            {
                isContaining = inputText.Contains(searchingVal);
                if (isContaining)
                {
                    break;
                }
            }

            return isContaining;
        } 

        #endregion

        #region EncryptMessage

        public string EncryptForASP(string stringToEncrypt)
        {
            return Encrypt(stringToEncrypt);
        }

        public static string Encrypt(string stringToEncrypt)
        {
            MemoryStream ms = null;
            try
            {
                byte[] key = { };
                string sEncryptionKey = "!#$a54?3";
                byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
                key = Encoding.UTF8.GetBytes(sEncryptionKey);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                ms = null;
            }
        }
        #endregion

        #region DecryptMessage

        public string DecryptForASP(string stringToDecrypt)
        {
            return Decrypt(stringToDecrypt);
        }

        public static string Decrypt(string stringToDecrypt)
        {
            MemoryStream ms = null;
            byte[] inputByteArray = new byte[stringToDecrypt.Length + 1];
            try
            {
                byte[] key = { };
                string sEncryptionKey = "!#$a54?3";
                byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };

                key = Encoding.UTF8.GetBytes(sEncryptionKey);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(stringToDecrypt);
                ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                ms = null;
            }
        }

        #endregion

        #region QueryStringEncryption

        public static string Encryption(string inputText)
        {
            string ENCRYPTION_KEY = "key";
            byte[] SALT = Encoding.ASCII.GetBytes(ENCRYPTION_KEY.Length.ToString());

            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            byte[] plainText = Encoding.Unicode.GetBytes(inputText);
            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(ENCRYPTION_KEY, SALT);

            using (ICryptoTransform encryptor = rijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16)))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainText, 0, plainText.Length);
                        cryptoStream.FlushFinalBlock();
                        return Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
            }

        }

        public static string Decryption(string inputText)
        {
            inputText = inputText.Replace(" ", "+");
            string ENCRYPTION_KEY = "key";
            byte[] SALT = Encoding.ASCII.GetBytes(ENCRYPTION_KEY.Length.ToString());

            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            byte[] encryptedData = Convert.FromBase64String(inputText);
            PasswordDeriveBytes secretKey = new PasswordDeriveBytes(ENCRYPTION_KEY, SALT);

            using (ICryptoTransform decryptor = rijndaelCipher.CreateDecryptor(secretKey.GetBytes(32), secretKey.GetBytes(16)))
            {
                using (MemoryStream memoryStream = new MemoryStream(encryptedData))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        byte[] plainText = new byte[encryptedData.Length];
                        int decryptedCount = cryptoStream.Read(plainText, 0, plainText.Length);
                        return Encoding.Unicode.GetString(plainText, 0, decryptedCount);
                    }
                }
            }

        }

        #endregion QueryStringEncryption

        #region Validate Email Address

        /// <summary>
        /// Validate Email Address
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string email)
        {
            var regexString = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                              @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

            var r = new Regex(regexString);

            return !string.IsNullOrEmpty(email) && r.IsMatch(email);
        }

        #endregion
    }
}