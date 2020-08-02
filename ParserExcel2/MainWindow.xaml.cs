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
using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using Excel = Microsoft.Office.Interop.Excel;//headless запуск хрома в скрытом режиме

namespace ParserExcel2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IWebDriver PJS;

        
        Excel.Application ex;
        
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_OpenSearch(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dial = new OpenFileDialog();
            Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();    
            dial.Filter = "Excel files (*.xls, *.xlsx, *.xlsm)|*.xls;*.xlsx;*.xlsm";
            if (dial.ShowDialog() == DialogResult) { }
            Microsoft.Office.Interop.Excel.Workbook ObjWorkBook = ObjExcel.Workbooks.Open(dial.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                 Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                 Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                 Type.Missing, Type.Missing);

            Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;

            ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];


            Organization[] organization = new Organization[ObjWorkSheet.UsedRange.Rows.Count];
            Excel.Worksheet  xlWorkSheet;



            //Excel.Application ex = new Excel.Application();
            //ExcelCostom costom = new ExcelCostom();
            //ex= costom.Costom();


            for (int i = 1; i < ObjWorkSheet.UsedRange.Rows.Count; i++)
            {
                organization[i] = new Organization();
                organization[i].Name = ObjWorkSheet.Cells[i + 1, 1].Value;
                organization[i].Inn = " " + (ObjWorkSheet.Cells[i + 1, 2].Value).ToString() + " ";
                organization[i].City = ObjWorkSheet.Cells[i + 1, 3].Value;


                //var driverService = PhantomJSDriverService.CreateDefaultService();//эта фигня
                //driverService.HideCommandPromptWindow = true;//скрывает браузер

                //PJS = new PhantomJSDriver(driverService);


                //PJS.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                //PJS.Manage().Window.Maximize();
                //PJS.Navigate().GoToUrl("https://www.rusprofile.ru");
                //IWebElement Search = PJS.FindElement(By.Name("query"));
                //Search.SendKeys(organization[i].Inn);
                //System.Threading.Thread.Sleep(500);
                //Search.SendKeys(OpenQA.Selenium.Keys.Enter);

                //organization[i].State = PJS.FindElement(By.ClassName("company-status")).Text;
                //organization[i].Supervisor = PJS.FindElement(By.CssSelector("#anketa > div.clear > div.rightcol > div.company-row.hidden-parent > span.company-info__text")).Text;
                //organization[i].Adress = PJS.FindElement(By.CssSelector("#anketa > div.clear > div.leftcol > div.company-row > address > span:nth-child(4)")).Text;
                //PJS.Quit();
                //MessageBox.Show(organization[i].State);

                Excel.Application ex = new Excel.Application();
                ExcelCostom costom = new ExcelCostom();
                ex= costom.Costom();

                //ex.Cells[1, 1] = "Наименование";
                //ex.Cells[2, 1] = "ИНН";
                //ex.Cells[3, 1] = "Руководитель";
                //ex.Cells[4, 1] = "Адрес";
                //ex.Cells[5, 1] = "Основной вид деятельности";
                //ex.Cells[6, 1] = "Действующая организация";
                //ex.Cells[7, 1] = "телефон";
                //ex.Cells[8, 1] = "телефон";
                //ex.Cells[9, 1] = "телефон";
                //ex.Cells[10, 1] = "телефон";
                //ex.Cells[11, 1] = "email";
                //ExcelCostom costom2  = new ExcelCostom();
                //ex = costom2.Costom();




                ex.Cells[1, 2] = organization[i].Name;
                ex.Cells[2, 2] = organization[i].Inn;
                //ex.Cells[6, 2] = organization[i].State;
                ex.Cells[3, 2] = organization[i].Supervisor;
                //ex.Cells[4, 2] = organization[i].Adress;




                xlWorkSheet = (Excel.Worksheet)ex.Worksheets.get_Item(1);

                xlWorkSheet.Name = organization[i].Name + organization[i].Inn;
                ex.Worksheets.Add(xlWorkSheet);
                Schetchik.Content = i;
            }

            //ex.ActiveWorkbook.Sheets[1].Delete();/// это для того чтобы удалить первый лишний лист
            ex.Visible = true;
            




            //Organization organization = new Organization();
            //organization.Name = ObjWorkSheet.Cells[2,1].Value;
            //organization.Inn = " "+ (ObjWorkSheet.Cells[2, 2].Value).ToString()+" ";
            //organization.City = ObjWorkSheet.Cells[2, 3].Value;


            //PJS = new PhantomJSDriver();
            //PJS.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            //PJS.Manage().Window.Maximize();
            //PJS.Navigate().GoToUrl("https://www.rusprofile.ru");
            //IWebElement Search = PJS.FindElement(By.Name("query"));

            //Search.SendKeys(organization.Inn);
            //Search.SendKeys(OpenQA.Selenium.Keys.Enter);

            //IWebElement InnwebElement  = PJS.FindElement(By.Id("clip_inn"));

            //organization.State= PJS.FindElement(By.ClassName("company-status")).Text;// действует ли организация

            //organization.Supervisor = PJS.FindElement(By.CssSelector("#anketa > div.clear > div.rightcol > div.company-row.hidden-parent > span.company-info__text")).Text;// директор
            //organization.Adress = PJS.FindElement(By.CssSelector("#anketa > div.clear > div.leftcol > div.company-row > address > span:nth-child(4)")).Text;// адресс
            //MessageBox.Show(organization.Supervisor);








            //ex.Cells[1, 2] = organization.Name;
            //ex.Cells[2, 2] = organization.Inn;
            //ex.Cells[6, 2] = organization.State;
            //ex.Cells[3, 2] = organization.Supervisor;
            //ex.Cells[4, 2] = organization.Adress;



            //xlWorkSheet.Cells.Font.Name = "Times New Roman";
            //Размер шрифта для диапазона




            
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            PJS.Quit();
        }
    }
}
