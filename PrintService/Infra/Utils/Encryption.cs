using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PrintService.Infra.Utils
{
    public static class Encryption
    {
        private static readonly string Key = "n3J9rT!xZ@q7Y$eP*1cL^vFm#oG8HkWb";
        private static readonly string IV = "XyZ#7vL@wP0q9cTb";

        public static string Encrypt(this string plainText)
        {
            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = Encoding.UTF8.GetBytes(IV);

            using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
            using var sw = new StreamWriter(cs);
            sw.Write(plainText);

            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Decrypt(this string encryptedText)
        {
            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = Encoding.UTF8.GetBytes(IV);

            using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream(Convert.FromBase64String(encryptedText));
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }
    }

}