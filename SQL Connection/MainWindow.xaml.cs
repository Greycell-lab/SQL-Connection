using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using MySql.Data.MySqlClient;

namespace SQL_Connection
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection conn;
        public MainWindow()
        {
            InitializeComponent();
            connectionStatus.Content = "Not Connected";
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string username = User.Text;
            string password = Pass.Password;
            string cstring = "datasource=127.0.0.1;port=3306;username=" + username + ";password=" + password + ";database=c_sharp;";
            conn = new MySqlConnection(cstring);
            //string commandstring = "CREATE TABLE Person (Name VARCHAR(80));";
            //MySqlCommand newcommand = new MySqlCommand(commandstring, conn);
            //newcommand.CommandTimeout = 60;
            //MySqlDataReader reader;
            try
            {
                conn.Open();
                connectionStatus.Content = "Connected";
                
                //reader = newcommand.ExecuteReader();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string commandstring = commandText.Text;
            MySqlCommand newcommand = new MySqlCommand(commandstring, conn);
            newcommand.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                reader = newcommand.ExecuteReader();
                MessageBox.Show("Executed");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
