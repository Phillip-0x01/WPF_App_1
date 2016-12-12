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
using System.Windows.Shapes;
using System.Data.SQLite;
using System.Data;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for DatabaseView.xaml
    /// </summary>
    public partial class DatabaseView : Window
    {
        string dbConnectionString = @"Data Source=database.db;Version=3";
        public DatabaseView()
        {
            InitializeComponent();

            // Load data grid view
            string Query = "select * from employeeinfo";
            LoadView(grdDatabase, Query);
        }
        

        public void LoadView(ItemsControl control, string commandText)
        {
            try
            {
                SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);

                using (SQLiteCommand command = new SQLiteCommand(commandText, sqliteCon))
                using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    control.ItemsSource = dataTable.AsDataView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
