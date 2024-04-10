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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        public static int IdRole { get; set; }
        public Authorization()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            {
                if (string.IsNullOrEmpty(tbLogin.Text))
                {
                    ClassFolder.ClassMB.InformationMB("Введите логин");
                }
                else if (string.IsNullOrEmpty(pbPassword.Password))
                {
                    ClassFolder.ClassMB.InformationMB("Введите пароль");
                }
                else
                {
                    try
                    {
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand("Select Password, IdRole from dbo.[Accountantdd] " +    
                            $"where Login = '{tbLogin.Text}'", sqlConnection);
                        dataReader = sqlCommand.ExecuteReader();
                        dataReader.Read();

                        if (pbPassword.Password != dataReader[0].ToString())
                        {
                            ClassFolder.ClassMB.ErrorMB("Неправильный логин или пароль");
                        }
                        else
                        {
                            IdRole = Convert.ToInt32(dataReader[1].ToString());

                            switch (IdRole)
                            {
                                case 1:
                                    new Kabinet().Show();
                                    Close();
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ClassFolder.ClassMB.ErrorMB(ex);
                    }
                }
            }
        }
    }

}