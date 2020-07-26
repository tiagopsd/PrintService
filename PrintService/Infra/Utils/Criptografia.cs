﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PrintService.Infra.Utils
{
    public static class Criptografia
    {
        public static string Critografar(string text)
        {
            string cryptoKey = "T67In3A2z/GOHhFJG1u73Q==";

            byte[] bIV = { 0x50, 0x08, 0xF1, 0xDD, 0xDE, 0x3C, 0xF2, 0x18, 0x44, 0x74, 0x19, 0x2C, 0x53, 0x49, 0xAB, 0xBC };
            try
            {
                //Se a string não está vazia, executa a criptografia      
                if (!string.IsNullOrEmpty(text))
                {
                    //Cria instancias de vetores de bytes com as chaves                         
                    byte[] bKey = Convert.FromBase64String(cryptoKey);
                    byte[] bText = new UTF8Encoding().GetBytes(text);

                    //Instancia a classe de criptografia Rijndael 
                    Rijndael rijndael = new RijndaelManaged();

                    //Define o tamanho da chave
                    //Chaves possíves:  128 (16 caracteres), 192 (24 caracteres) e 256 (32 caracteres)
                    rijndael.KeySize = 256;

                    //Cria o espaço de memória para guardar o valor criptografado: 
                    MemoryStream mStream = new MemoryStream();

                    //Instancia o encriptador    
                    CryptoStream encryptor = new CryptoStream(mStream, rijndael.CreateEncryptor(bKey, bIV), CryptoStreamMode.Write);

                    // Faz a escrita dos dados criptografados no espaço de memória  
                    encryptor.Write(bText, 0, bText.Length);

                    // Despeja toda a memória.                                 
                    encryptor.FlushFinalBlock();

                    // Pega o vetor de bytes da memória e gera a string criptografada  
                    return Convert.ToBase64String(mStream.ToArray());
                }
                else
                {
                    // Se a string for vazia retorna nulo  
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Se algum erro ocorrer, dispara a exceção  
                throw new ApplicationException("Erro ao criptografar", ex);
            }
        }

        public static string Descritografar(string text)
        {
            string cryptoKey = "T67In3A2z/GOHhFJG1u73Q==";

            byte[] bIV = { 0x50, 0x08, 0xF1, 0xDD, 0xDE, 0x3C, 0xF2, 0x18, 0x44, 0x74, 0x19, 0x2C, 0x53, 0x49, 0xAB, 0xBC };
            try
            {
                if (!string.IsNullOrEmpty(text))
                {
                    //Cria instancias de vetores de bytes com as chaves
                    byte[] bKey = Convert.FromBase64String(cryptoKey);
                    byte[] bText = Convert.FromBase64String(text);

                    //Instancia a classe de criptografia Rijndael 
                    Rijndael rijndael = new RijndaelManaged();

                    //Define o tamanho da chave "256 = 8 * 32"  
                    //Chaves possíves: 128 (16 caracteres), 192 (24 caracteres) e 256 (32 caracteres)  
                    rijndael.KeySize = 256;

                    //Cria o espaço de memória para guardar o valor DEScriptografado:
                    MemoryStream mStream = new MemoryStream();

                    //Instancia o Decriptador  
                    CryptoStream decryptor = new CryptoStream(mStream, rijndael.CreateDecryptor(bKey, bIV), CryptoStreamMode.Write);

                    //Faz a escrita dos dados criptografados no espaço de memória   
                    decryptor.Write(bText, 0, bText.Length);

                    //Despeja toda a memória. 
                    decryptor.FlushFinalBlock();

                    //Instancia a classe de codificação para que a string venha de forma correta 
                    UTF8Encoding utf8 = new UTF8Encoding();

                    //Com o vetor de bytes da memória, gera a string descritografada em UTF8  
                    return utf8.GetString(mStream.ToArray());
                }
                else
                {
                    // Se a string for vazia retorna nulo     
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Se algum erro ocorrer, dispara a exceção    
                throw new ApplicationException("Erro ao descriptografar", ex);
            }
        }
    }
}