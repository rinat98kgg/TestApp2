using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string resultText = "";
            Encoder encoder = new Encoder();
            resultText =  encoder.EncodeString("abc");
            Console.WriteLine(resultText);
            Console.ReadLine();
        }
    }

    public class Encoder
    {
        public string EncodeString(string str)
        {
            string res = "";
            foreach (char ch in str)
            {
                char s = ch;
                s++;
                res += s;
            }
            return res;
        }
    }
}
