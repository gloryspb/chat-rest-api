using System;
using System.Security.Cryptography;

namespace UDPChat_server;

public class RSAKeyGenerator
{
    public static void GenerateKeys()
    {
        // Создание объекта класса RSA с заданной длиной ключа
        using (var rsa = RSA.Create(2048))
        {
            // Генерация пары ключей
            var publicKey = rsa.ExportRSAPublicKey();
            var privateKey = rsa.ExportRSAPrivateKey();

            // Сохранение ключей в файлы
            System.IO.File.WriteAllBytes("public_key.pem", publicKey);
            System.IO.File.WriteAllBytes("private_key.pem", privateKey);

            // Console.WriteLine("Ключи RSA сгенерированы и сохранены.");
        }
    }
}