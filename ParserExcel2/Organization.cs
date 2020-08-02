using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserExcel2
{
    class Organization
    {
       public string Name { get; set; }
       public string Inn { get; set; }
       public string Supervisor { get; set; }
       public string Adress { get; set; }
       public string Activity { get; set; }
       public string State { get; set; }// действующая организация или нет
       public string Tel { get; set; }
       public string Email { get; set; }
       public string City  { get; set; }
    }
}
