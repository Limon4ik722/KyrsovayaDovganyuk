using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KyrsovayaDovganyuk.ClassFolder
{
    internal class ClassMB
    {
        public static void ErrorMB(Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void ErrorMB(string text)
        {
            MessageBox.Show(text, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void InformationMB(string text)
        {
            MessageBox.Show(text, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
