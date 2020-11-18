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
using MySql.Data.MySqlClient;

namespace LoginDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ReloadContent();

        }

        public void ReloadContent()
        {
            string cs = @"server=localhost;userid=PHP;password=Password;database=registration";

            using var con = new MySqlConnection(cs);
            con.Open();

            string sql = "SELECT * FROM users";
            using var cmd = new MySqlCommand(sql, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            List<User> Users = new List<User>();

            while (rdr.Read())
            {
                Users.Add(new User(rdr.GetString("email"), rdr.GetString("username"), rdr.GetString("password"), rdr.GetString("salt")));
            }

            dataGridView1.ItemsSource = Users;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReloadContent();
        }
    }
}
