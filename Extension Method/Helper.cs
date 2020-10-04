using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Extension_Method
{
   public static class Helper
    {
        
        public static void ToCw(this MyClass myClass)
        {
            Console.WriteLine($"Имя {myClass.Name} позиция {myClass.Position}");
            
        }

    }
}
