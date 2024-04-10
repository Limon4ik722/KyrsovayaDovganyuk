using KyrsovayaDovganyuk.ClassFolder;
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
using System.Windows.Shapes;

namespace KyrsovayaDovganyuk
{
    /// <summary>
    /// Логика взаимодействия для Sotrydnik1.xaml
    /// </summary>
    public partial class Sotrydnik1 : Window
    {
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionString());
        SqlDataReader dataReader;
        SqlCommand sqlCommand;
        public Sotrydnik1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("select * from dbo.FullStaffInfo " +
                    $"where IdPassport = '{ClassPassport.IdPassport}'", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();
                tblSurName.Text = dataReader["Surname"].ToString();
                tblName.Text = dataReader["Name"].ToString();
                tblLastName.Text = dataReader["LastName"].ToString();
                tblDateOfBirthday.Text = dataReader["DateOfBirthday"].ToString();
                tblPlaceOfBirthday.Text = dataReader["PlaceOfBirthday"].ToString();
                tblCity.Text = dataReader["City"].ToString();
                tblStreet.Text = dataReader["Street"].ToString();
                tblMarital.Text = dataReader["MaritalStatusName"].ToString();
                tblGender.Text = dataReader["GenderName"].ToString();
                tblObrazovanie.Text = dataReader["ObrazovanieName"].ToString();
                tblProfa.Text = dataReader["ProfessionName"].ToString();
                tblSnils.Text = dataReader["SNILS"].ToString();
                tblPolis.Text = dataReader["PolisOms"].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Sotrydnikixaml().Show();
            this.Close();
        }
    }
}
