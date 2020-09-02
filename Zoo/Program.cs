using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Какой то текст");
            string pass = "123456";
            List<char> passChar = new List<char>();
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                    break;
                else
                {
                    Console.Write("*");
                    passChar.Add(cki.KeyChar);
                }
            }
            Console.WriteLine();
            string passStr = null;
            foreach (char c in passChar)
                passStr += c;
            if (pass == passStr) Console.WriteLine("Пароль правильный");
            else Console.WriteLine("Пароль не правильный");

            //for (; ; )
            //{
            //    List<Animal> animals = new List<Animal>();
            //    new Zoo(animals);
            //    new Menu(animals);
            //}
            
            
        }
    }
}
