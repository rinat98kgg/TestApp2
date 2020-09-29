using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace TestApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string resultText = "", text = "abc";
            Console.WriteLine("Исходный текст: " + text);

            Encoder encoder = new Encoder(); //Создаем экземпляр класса Encoder

            resultText =  encoder.EncodeString(text, false); //Кодируем текст обычной кодировкой
            Console.WriteLine("Обычная кодировка: " + resultText);
            
            resultText = encoder.EncodeString(text, true); //Кодируем текст через SHA1
            Console.WriteLine("Кодировка через SHA1: " + resultText);
            
            Console.ReadLine();
        }
    }

    public class Encoder
    {
        public string EncodeString(string str, bool isHash) //Добавил аргумент в фунцию которая будет задавать, кодировать через SHA1 или просто обычным
        {
            string res = "";
            if (!isHash) //Проверка значения аргумента
            {
                //Этот блок выполняется если кодировка не через SHA1
                foreach (char ch in str)
                {
                    char s = ch;
                    s++;
                    res += s;
                }
            }
            else
            {
                //Этот блок выполняется если кодировка через SHA1
                using (SHA1 sha1Hash = SHA1.Create())
                {
                    byte[] sourceBytes = Encoding.UTF8.GetBytes(str);
                    byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
                    res = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                }
            }
            return res;
        }
    }
}
