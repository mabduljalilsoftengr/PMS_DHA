using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PeshawarDHASW.Data_Layer.clsUser
{
    public static class cls_dl_User
    {
        public static DataSet UserReader(SqlParameter[] prm)
        {
            DataSet ds = SQLHelper.ExecuteDataset(
                                                  clsMostUseVars.Connectionstring,
                                                  CommandType.StoredProcedure,
                                                  "App.USP_User_Security",
                                                  prm);
            return ds;
        }
        public static int User_NonQuery(SqlParameter[] prmtr)
        {
            int rslt = SQLHelper.ExecuteNonQuery(
                                                 clsMostUseVars.Connectionstring,
                                                 CommandType.StoredProcedure,
                                                 "App.USP_User_Security",
                                                 prmtr);
            return rslt;
        }
        public static string Encrypt(string input, string key)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string Decrypt(string input, string key)
        {
            if (string.IsNullOrEmpty(input))
                return null;
            byte[] inputArray = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }


        ////this is Password fields to avoid Base-64 Error
        //private static readonly string EncryptionKey = "sblw-3hn8-sqoy19"; // must be 16 chars = 128-bit key

        //public static string PasswordEncrypt(string plainText, string key = null)
        //{
        //    if (string.IsNullOrEmpty(plainText))
        //        return string.Empty;

        //    if (key == null)
        //        key = EncryptionKey;

        //    byte[] iv = new byte[16];
        //    byte[] array;

        //    using (Aes aes = Aes.Create())
        //    {
        //        aes.Key = Encoding.UTF8.GetBytes(key);
        //        aes.IV = iv;

        //        ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

        //        using (MemoryStream memoryStream = new MemoryStream())
        //        {
        //            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
        //            using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
        //            {
        //                streamWriter.Write(plainText);
        //            }

        //            array = memoryStream.ToArray();
        //        }
        //    }

        //    return Convert.ToBase64String(array);
        //}

        //public static string PasswordDecrypt(string cipherText, string key = null)
        //{
        //    if (string.IsNullOrEmpty(cipherText))
        //        return string.Empty;

        //    if (key == null)
        //        key = EncryptionKey;

        //    byte[] iv = new byte[16];
        //    byte[] buffer = Convert.FromBase64String(cipherText);

        //    using (Aes aes = Aes.Create())
        //    {
        //        aes.Key = Encoding.UTF8.GetBytes(key);
        //        aes.IV = iv;

        //        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        //        using (MemoryStream memoryStream = new MemoryStream(buffer))
        //        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
        //        using (StreamReader streamReader = new StreamReader(cryptoStream))
        //        {
        //            return streamReader.ReadToEnd();
        //        }
        //    }
        //}

        //public static string Pass_Decrypt(string input, string key)
        //{
        //    // 1. Trim whitespace from the input string
        //    if (string.IsNullOrEmpty(input))
        //        return null;

        //    // Use Trim() to remove any leading/trailing whitespace
        //    string base64String = input.Trim();

        //    // Check for null or empty string *after* trimming
        //    if (string.IsNullOrEmpty(base64String))
        //        return null;

        //    // 2. The rest of your existing logic
        //    byte[] inputArray = Convert.FromBase64String(base64String);
        //    TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
        //    tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
        //    tripleDES.Mode = CipherMode.ECB;
        //    tripleDES.Padding = PaddingMode.PKCS7;
        //    ICryptoTransform cTransform = tripleDES.CreateDecryptor();
        //    byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
        //    tripleDES.Clear();
        //    return UTF8Encoding.UTF8.GetString(resultArray);
        //}

        public static string Pass_Decrypt(string input, string key)
        {
            // 1. Trim whitespace from the input string
            if (string.IsNullOrEmpty(input))
                return input; // Return original input if null or empty

            // Use Trim() to remove any leading/trailing whitespace
            string processedInput = input.Trim();

            // Check for null or empty string *after* trimming
            if (string.IsNullOrEmpty(processedInput))
                return input;

            try
            {
                // 2. Try to detect if it's a Base64 encoded encrypted password
                if (IsBase64EncryptedString(processedInput))
                {
                    // 3. Attempt to decrypt as Base64 encrypted string
                    byte[] inputArray = Convert.FromBase64String(processedInput);
                    using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider())
                    {
                        tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
                        tripleDES.Mode = CipherMode.ECB;
                        tripleDES.Padding = PaddingMode.PKCS7;
                        using (ICryptoTransform cTransform = tripleDES.CreateDecryptor())
                        {
                            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                            return UTF8Encoding.UTF8.GetString(resultArray);
                        }
                    }
                }
                else
                {
                    // 4. Return as plain text if not Base64 encrypted
                    return processedInput;
                }
            }
            catch (FormatException)
            {
                // If Base64 conversion fails, return as plain text
                return processedInput;
            }
            catch (CryptographicException)
            {
                // If decryption fails (wrong key, etc.), return as plain text
                return processedInput;
            }
            catch (Exception)
            {
                // For any other exception, return as plain text
                return processedInput;
            }
        }

        // Helper method to detect if string is likely a Base64 encrypted string
        private static bool IsBase64EncryptedString(string input)
        {
            // Check if string has proper Base64 length (divisible by 4)
            if (input.Length % 4 != 0)
                return false;

            // Check if string contains only valid Base64 characters
            string base64Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
            foreach (char c in input)
            {
                if (!base64Chars.Contains(c))
                    return false;
            }

            // Additional check: try to decode and see if it produces reasonable byte array
            try
            {
                byte[] data = Convert.FromBase64String(input);
                // If decoding succeeds and produces reasonable data length, likely encrypted
                return data.Length > 0 && data.Length <= 256; // Adjust max length as needed
            }
            catch
            {
                return false;
            }
        }
    }
}
