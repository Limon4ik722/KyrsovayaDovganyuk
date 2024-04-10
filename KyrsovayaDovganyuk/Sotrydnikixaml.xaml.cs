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

namespace KyrsovayaDovganyuk
{
    /// <summary>
    /// Логика взаимодействия для Sotrydnikixaml.xaml
    /// </summary>
    public partial class Sotrydnikixaml : Window
    {
        ClassFolder.classDG classDG;
        public Sotrydnikixaml()
        {
            InitializeComponent();
            classDG = new ClassFolder.classDG(DgStaff);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DgStaff.SelectedItem == null)
            {

            }
            else
            {
                try
                {
                    ClassFolder.ClassPassport.IdPassport = classDG.SelectId();
                    new Sotrydnik1().Show();
                    this.Close();
                    classDG.LoadDB("Select * from dbo.ViewStaff");
                }
                catch (Exception ex)
                {

                }
                
            }
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            classDG.LoadDB("Select * from dbo.ViewStaff");
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result =
    MessageBox.Show("Вы действительно желаете удалить?",
    "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                classDG.DeleteRowDB("Delete dbo.[Passport] " +
                $"Where [IdPassport]='{classDG.SelectId()}'");
                classDG.LoadDB("Select * From dbo.[ViewStaff]");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Kabinet().Show();
            this.Close();
        }
    }
}
