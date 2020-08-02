using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;

namespace PoliNomMathWPFNet
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Test_Click(object sender, RoutedEventArgs e)
        {
            int p = 11;
            int widthMyArray = 30;// ко-во столбцов
            int heightMyArray = 60;// ко-во  строк
            int[,] MyArray = new int[widthMyArray, heightMyArray];

            //               24 23 22 21 20 19 18 17 16 15 14 13 12 11 10  9  8  7  6  5  4  3  2  1  0  степени
            int[] divider = { 1, 1, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };//делитель
            int[] dividend = { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 10, 1, 9, 1, 7, 9, 6, 2, 0, 10, 6, 6 };// делимое
                                                                                                             //                0  1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24             
            ///int result = MyMath.OSTAT((dividend[0] * divider[0]), p);
            for (int x = 0; x <= widthMyArray - 6; x++)
            {
                MyArray[4, x + 2] = divider[x];
                MyArray[6, x + 2] = dividend[x];
            }

            for (int y = 0; y <= heightMyArray - 40; y++)
            {
                for (int x = 0; x <= widthMyArray - 5; x++)
                {

                    MyArray[y+7, x+1] = MyMath.OSTAT(MyArray[y+6, 2] * MyArray[4, x + 3], p);
                    MyArray[y+8, x+1] = MyMath.OSTAT(MyArray[y+6, x + 2] - MyArray[y+7, x + 2], p);
                }              
            }

            #region
            //int result = MyMath.OSTAT(10, p);
            //MessageBox.Show(result.ToString());

            //Объявляем приложение
            Excel.Application ex = new Excel.Application();

            //Количество листов в рабочей книге
            ex.SheetsInNewWorkbook = 2;
            //Добавить рабочую книгу
            Excel.Workbook workBook = ex.Workbooks.Add(Type.Missing);
            //Отключить отображение окон с сообщениями
            ex.DisplayAlerts = false;
            //Получаем первый лист документа (счет начинается с 1)
            Excel.Worksheet sheet = (Excel.Worksheet)ex.Worksheets.get_Item(1);
            //Название листа (вкладки снизу)
            sheet.Name = "Отчет за 13.12.2017";
            sheet.StandardWidth = 3;
            #endregion
            for (int y = 1; y <= 29; y++)
            {
                for (int x = 1; x <= 24; x++)
                {
                    sheet.Cells[y, x] = MyArray[y, x];
                }

            }
            //Отобразить Excel
            ex.Visible = true;


            //for (int i = 0; i< divider.Length; i++)
            //{
            //    sheet.Cells[1, i] = divider[i];
            //}
            //ex.Visible = true;

            //Microsoft.Office.Interop.Excel.Range r = sheet.Cells[10, 1] as Microsoft.Office.Interop.Excel.Range;

            //Microsoft.Office.Interop.Excel.Range formulaRange = sheet.get_Range(sheet.Cells[4, 1], sheet.Cells[9, 1]);
            //string adder = formulaRange.get_Address(1, 1, Microsoft.Office.Interop.Excel.XlReferenceStyle.xlA1, Type.Missing, Type.Missing);
            //r.Formula = String.Format("=СУММ({0}", adder);
            //MessageBox.Show(r.ToString());


            //    for (int i = 0; i < 25; i++)
            //    {
            //        a7[i] = (dividend[0] * divider[i]) % p;
            //    }


            //    for (int i = 0; i < 25; i++)
            //    {
            //        a8[i] = (dividend[i] - a7[i]) % p;
            //    }
            //    //var s = string.Join(" ", a8);
            //    //MessageBox.Show(s.ToString());

            //    for (int i = 1; i < dividend.Length - 1; i++)
            //    {
            //        a9[i] = (a8[1] * divider[i - 1]) % p;
            //    }
            //    //var s = string.Join(" ", a9);
            //    //MessageBox.Show(s.ToString());
            //    for (int i = 1; i < dividend.Length - 1; i++)
            //    {
            //        a10[i] = (a8[i] - a9[i]) % p;



            //        //var s = string.Join(" ", a10);
            //        //MessageBox.Show(s.ToString());
            //    }

            //    //int sum = p %  der;

            //    int der = -1;
            //    decimal result = (decimal)der / (decimal)p;
            //    int sum = (int)result;
            //    double roundDown(double number, int p)
            //    {
            //        return Math.Round(number - number % Math.Pow(10, p));
            //    }





            //    MessageBox.Show(p+" " + der+" "+ sum.ToString());


            //}
            //public bool CheckWebsite(string url)
            //{
            //    try
            //    {
            //        using (WebClient wc = new WebClient())
            //        {
            //            string HTMLSource = wc.DownloadString(url);
            //            return true;
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        return false;
            //    }
            //}
        }
    }
}
