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
using System.Data.SqlClient;  

namespace Databasedd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string Cs = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\slavicek.martin\source\repos\Databasedd\Databasedd\Katabasis.mdf;Integrated Security = True";
        string Vypis = "";

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Cs))
                {
                    using (SqlCommand cmd = new SqlCommand("", conn))
                    {
                        cmd.CommandText = "select * from zbozi";
                        conn.Open();

                        SqlDataReader sqldata = cmd.ExecuteReader();
                        while (sqldata.Read())
                        {
                            Vypis += $"{sqldata["id"]} ☻";
                            Vypis += $"{sqldata["nazev"].ToString().Trim()} ☻";
                            Vypis += $"{sqldata["cena"]} ☻";
                            Vypis += $"{sqldata["Pkus"]} ☻";


                            Vypis += "\n";

                        }
                        conn.Close();
                        data.Text = Vypis;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
