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
    /// Логика взаимодействия для NewSotrydnik.xaml
    /// </summary>
    public partial class NewSotrydnik : Window
    {
        public static string IdGender { get; set; }

        public static string IdMaritalStatus { get; set; }

        public static string IdTrydKniga {  get; set; }

        public static string IdObrazovanie { get; set; }

        SqlConnection sqlConnection =
            new SqlConnection(App.ConnectionString());
        SqlCommand command;
        ClassCB classCB;
        public NewSotrydnik()
        {
            InitializeComponent();
            classCB = new ClassFolder.ClassCB();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)

        {
            if (string.IsNullOrEmpty(TbSurname.Text))
            {
                MessageBox.Show("Введите фамилию", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                TbSurname.Focus();
            }
            else if (CbGender.SelectedItem == null)
            {
                MessageBox.Show("Выберите пол", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                CbGender.Focus();
            }
            else if (string.IsNullOrEmpty(TbName.Text))
            {
                MessageBox.Show("Введите имя", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                TbName.Focus();
            }
            else if (string.IsNullOrEmpty(TbTabel.Text))
            {
                MessageBox.Show("Введите табельный номер", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                TbTabel.Focus();
            }
            else if (string.IsNullOrEmpty(TbDateofbirthday.Text))
            {
                MessageBox.Show("Введите дату рождения", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                TbDateofbirthday.Focus();
            }
            else if (string.IsNullOrEmpty(TbPlaceofbirthday.Text))
            {
                MessageBox.Show("Введите место рождения", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                TbPlaceofbirthday.Focus();
            }
            else if (string.IsNullOrEmpty(TbCity.Text))
            {
                MessageBox.Show("Введите город", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                TbCity.Focus();
            }
            else if (string.IsNullOrEmpty(TbStreet.Text))
            {
                MessageBox.Show("Введите улицу", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                TbStreet.Focus();
            }
            else if (string.IsNullOrEmpty(TbSnils.Text))
            {
                MessageBox.Show("Введите снилс", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                TbSnils.Focus();
            }
            else if (string.IsNullOrEmpty(TbPolis.Text))
            {
                MessageBox.Show("Введите полис", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                TbPolis.Focus();
            }
            else
            {
                IdGender = CbGender.SelectedValue.ToString();
                IdMaritalStatus = CbMarital.SelectedValue.ToString();
                IdTrydKniga = CbProfession.SelectedValue.ToString();
                IdObrazovanie = CbObrazovanie.SelectedValue.ToString();
                try
                {
                    sqlConnection.Open();
                    command = new SqlCommand("Insert into dbo.[Passport] " +
                       "(Surname, Name, LastName, IdGender, IdMaritalStatus, " +
                       "Dateofbirthday, PlaceOfBirthday, SNILS, IdTrydKniga, PolisOms," +
                       "TabelNumber, IdObrazovanie, City, Street) " +
                       "Values " +
                       "(@Surname, " +
                       "@Name, " +
                       "@LastName, " +
                       "@IdGender, " +
                       "@IdMaritalStatus, " +
                       "@Dateofbirthday, " +
                       "@PlaceOfBirthday, " +
                       "@SNILS, " +
                       "@IdTrydKniga, " +
                       "@PolisOms, " +
                       "@TabelNumber, " +
                       "@IdObrazovanie, " +
                       "@City, " +
                       "@Street)", sqlConnection);


                    command.Parameters.AddWithValue("Surname",
                       TbSurname.Text);
                    command.Parameters.AddWithValue("Name",
                        TbName.Text);
                    command.Parameters.AddWithValue("LastName",
                       TbLastname.Text);
                    command.Parameters.AddWithValue("IdGender",
                       IdGender);
                    command.Parameters.AddWithValue("IdMaritalStatus",
                       IdMaritalStatus);
                    command.Parameters.AddWithValue("DateOfBirthday",
                       TbDateofbirthday.Text);
                    command.Parameters.AddWithValue("PlaceOfBirthday",
                       TbPlaceofbirthday.Text);
                    command.Parameters.AddWithValue("SNILS",
                       TbSnils.Text);
                    command.Parameters.AddWithValue("IdTrydKniga",
                       IdTrydKniga);
                    command.Parameters.AddWithValue("PolisOms",
                       TbPolis.Text);
                    command.Parameters.AddWithValue("TabelNumber",
                       TbTabel.Text);
                    command.Parameters.AddWithValue("IdObrazovanie",
                       IdObrazovanie);
                    command.Parameters.AddWithValue("City",
                       TbCity.Text);
                    command.Parameters.AddWithValue("Street",
                       TbStreet.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Добавление сотрудника прошло успешно",
                       "Информация", MessageBoxButton.OK,
                       MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
     MessageBoxImage.Error);
                }
            }

        }
        private void CbGender_Loaded(object sender, RoutedEventArgs e)
        {
            classCB.LoadGender(CbGender);
        }
        private void CbMarital_Loaded(object sender, RoutedEventArgs e)
        {
            classCB.LoadMarital(CbMarital);
        }

        private void CbObrazovanie_Loaded(object sender, RoutedEventArgs e)
        {
            classCB.LoadObrazovanie(CbObrazovanie);
        }

        private void CbProffesion_Loaded(object sender, RoutedEventArgs e)
        {
            classCB.LoadProfession(CbProfession);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Kabinet().Show();
            this.Close();
        }
    }
 }

