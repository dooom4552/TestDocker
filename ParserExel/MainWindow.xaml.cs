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
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using Excel = Microsoft.Office.Interop.Excel;





namespace ParserExel
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        IWebDriver PJS;

        string inn = " 1658027444 ";
        //Excel.Application ex;
        Excel.Worksheet xlWorkSheet;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_OpenSearch(object sender, RoutedEventArgs e)
        {
            
            PJS = new PhantomJSDriver();
            PJS.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            PJS.Manage().Window.Maximize();
            PJS.Navigate().GoToUrl("https://www.rusprofile.ru");
            IWebElement Search = PJS.FindElement(By.Name("query"));
            
            Search.SendKeys(inn);
            Search.SendKeys(OpenQA.Selenium.Keys.Enter);

            //Excel.Application ex = new Excel.Application();
            Excel.Workbook workbook = new Excel.Workbook();
            //ex.Workbooks.Add();
            //ex.Cells[1, 1] = "Номер документа";
            //ex.Cells[1, 2] = "Дата";
            //ex.Cells[1, 3] = "Название";
            //ex.Cells[1, 4] = "Изобретатели";
            //ex.Cells[1, 5] = "Заявитель";
            //ex.Cells[1, 6] = "МПК";
            //ex.Cells[1, 7] = "Номер заявки";
            //ex.Cells[1, 8] = "Дата завяки";
            //ex.Cells[1, 9] = "Приоритетный документ";
            //ex.Cells[1, 10] = "Дата приоритетного документа";
            //ex.Cells[1, 11] = "Другие публикации";
            //ex.Cells[1, 12] = "Реферат";

            //xlWorkSheet = (Excel.Worksheet)ex.Worksheets.get_Item(1);
            //xlWorkSheet.Name = "Данные о патентах";
            //xlWorkSheet.Cells.Font.Name = "Times New Roman";
            ////Размер шрифта для диапазона
            //xlWorkSheet.Cells.Font.Size = 10;

            //ex.Visible = true;













            // (PJS as PhantomJSDriver).GetScreenshot().SaveAsFile("C:\\Users\\mypc\\source\\repos\\ParserExel\\page.png", ScreenshotImageFormat.Png);
        }

        private void Button_Close(object sender, RoutedEventArgs e) 
        {
            PJS.Quit();
        }
    }
}
