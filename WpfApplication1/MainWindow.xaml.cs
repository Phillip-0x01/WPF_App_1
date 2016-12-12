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
using System.Data.SQLite;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string dbConnectionString = @"Data Source=database.db;Version=3";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_1_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            // Open connection to database
           try
            {
                sqliteCon.Open();
                string Query = "select * from employeeinfo where username=" + this.username.Text + " and password=" + this.password.Text;
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);

                createCommand.ExecuteNonQuery();
                SQLiteDataReader dr = createCommand.ExecuteReader();

                int count = 0;
                while (dr.Read())
                {
                    count++;
                }
                if (count > 1)
                {
                    MessageBox.Show("Duplicate Username and password. Try again");
                }
                if (count == 1)
                {
                    DatabaseView win2 = new DatabaseView();
                    win2.Show();
                    this.Close();
                }
                if (count < 1)
                {
                    MessageBox.Show("Username and password is not correct");
                }


            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
