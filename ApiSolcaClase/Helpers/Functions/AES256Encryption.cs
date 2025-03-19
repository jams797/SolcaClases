using System.Security.Cryptography;
using System.Text;

namespace ApiSolcaClase.Helpers.Functions
{
    public class AES256Encryption
    {
        // Encriptar el texto usando AES-256
        public static string? Encrypt(string plainText, string key, string iv)
        {
            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Encoding.UTF8.GetBytes(key); // La clave debe ser de 256 bits (32 bytes)
                    aesAlg.IV = Encoding.UTF8.GetBytes(iv);   // El IV debe ser de 128 bits (16 bytes)

                    using (ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                            {
                                using (StreamWriter sw = new StreamWriter(cs))
                                {
                                    sw.Write(plainText);
                                }
                            }
                            return Convert.ToBase64String(ms.ToArray());
                        }
                    }
                }
            } catch (Exception ex)
            {
                return null;
            }
        }

        // Desencriptar el texto cifrado usando AES-256
        public static string? Decrypt(string cipherText, string key, string iv)
        {
            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Encoding.UTF8.GetBytes(key); // La clave debe ser de 256 bits (32 bytes)
                    aesAlg.IV = Encoding.UTF8.GetBytes(iv);   // El IV debe ser de 128 bits (16 bytes)

                    using (ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
                    {
                        using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText)))
                        {
                            using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                            {
                                using (StreamReader sr = new StreamReader(cs))
                                {
                                    return sr.ReadToEnd();
                                }
                            }
                        }
                    }
                }
            } catch (Exception ex)
            {
                return null;
            }
        }
    }
}
