using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;//headless запуск хрома в скрытом режиме

namespace ParserExcel2
{
    class ExcelCostom
    {
        public Excel.Application Costom() 
        {
            Excel.Application ex = new Excel.Application();
            ex.Workbooks.Add();
            ex.Cells[1, 1] = "Наименование";
            ex.Cells[2, 1] = "ИНН";
            ex.Cells[3, 1] = "Руководитель";
            ex.Cells[4, 1] = "Адрес";
            ex.Cells[5, 1] = "Основной вид деятельности";
            ex.Cells[6, 1] = "Действующая организация";
            ex.Cells[7, 1] = "телефон";
            ex.Cells[8, 1] = "телефон";
            ex.Cells[9, 1] = "телефон";
            ex.Cells[10, 1] = "телефон";
            ex.Cells[11, 1] = "email";
            return ex;
        }     
    }
}
