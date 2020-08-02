using System;

namespace deltest
{
    class Program
    {
       
        static void Main(string[] args)
        {
          
            
                string text = Console.ReadLine();
                Context context = new Context(new Nested2());
                context.ConcretMetod(text);
                                       
        }           
    }
}
