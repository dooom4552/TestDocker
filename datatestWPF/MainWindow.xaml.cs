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
using System.Data;

namespace datatestWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //DataTable dt = new DataTable();
            //dt.Clear();
            //dt.Columns.Add("Name");
            //dt.Columns.Add("Marks");
            //DataRow _ravi = dt.NewRow();
            //DataRow _cavi = dt.NewRow();
            //_ravi["Name"] = "ravi";
            //_ravi["Marks"] = "500";
            //_cavi["Name"] = "cavi"; 
            //_cavi["Marks"] = "1000";
            //dt.Rows.Add(_ravi);
            //dt.Rows.Add(_cavi);
            //DataRow[] row = dt.Select("Marks > 400");
            ////dt.Clear();
            //dt.Rows.Add(row);



            //Godgrid.ItemsSource = table.DefaultView;

            //Godgrid.ItemsSource = row;

            // Create a table of five different people.
            // ... Store their size and sex.
            DataTable table = new DataTable("Players");
            table.Columns.Add(new DataColumn("Size", typeof(int)));
            table.Columns.Add(new DataColumn("Sex", typeof(char)));

            table.Rows.Add(100, 'f');
            table.Rows.Add(235, 'f');
            table.Rows.Add(250, 'm');
            table.Rows.Add(310, 'm');
            table.Rows.Add(150, 'm');

            // Search for people above a certain size.
            // ... Require certain sex.
            DataRow[] result = table.Select("Size >= 230 AND Sex = 'm'");
            foreach (DataRow row in result)
            {
                Godgrid. = row;
                Console.WriteLine("{0}, {1}", row[0], row[1]);
            }

            //Godgrid.ItemsSource = result;
        }
    }
}

