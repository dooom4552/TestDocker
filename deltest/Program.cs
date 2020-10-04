using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace deltest
{
    class Program
    {
        static void Main(string[] args)
        {

            Thread thread = new Thread(new ThreadStart(MyMetod));
            thread.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i}MyMetod1");
                Thread.Sleep(50);
            }
            static void MyMetod()
            {
                for(int i =0; i<10; i++)
                {
                    Console.WriteLine($"{i}MyMetod2");
                    Thread.Sleep(50);
                }
                
            }

        }
    }
}