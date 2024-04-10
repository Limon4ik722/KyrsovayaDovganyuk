using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace KyrsovayaDovganyuk.ClassFolder
{
    internal class ClassCB
    {
        SqlConnection sqlConnection =
      new SqlConnection(App.ConnectionString());
        SqlDataAdapter dataAdapter;
        DataSet dataSet;
        public void LoadGender(ComboBox cbGender)
        {

            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("SELECT IdGender, " +
                    "GenderName FROM dbo.[Gender] Order by IdGender ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[Gender]");
                cbGender.ItemsSource = dataSet.Tables["[Gender]"].DefaultView;
                cbGender.DisplayMemberPath =
                dataSet.Tables["[Gender]"].
                    Columns["GenderName"].ToString();
                cbGender.SelectedValuePath =
                    dataSet.Tables["[Gender]"].Columns["IdGender"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally { sqlConnection.Close(); }
        }
        public void LoadMarital(ComboBox cbGender)
        {

            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("SELECT IdMaritalStatus, " +
                    "MaritalStatusName FROM dbo.[MaritalStatus] Order by IdMaritalStatus ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[MaritalStatus]");
                cbGender.ItemsSource = dataSet.Tables["[MaritalStatus]"].DefaultView;
                cbGender.DisplayMemberPath =
                dataSet.Tables["[MaritalStatus]"].
                    Columns["MaritalStatusName"].ToString();
                cbGender.SelectedValuePath =
                    dataSet.Tables["[MaritalStatus]"].Columns["IdMaritalStatus"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally { sqlConnection.Close(); }
        }
        public void LoadObrazovanie(ComboBox CbObrazovanie)
        {

            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("SELECT IdObrazovanie, " +
                    "ObrazovanieName FROM dbo.[Obrazovanie] Order by IdObrazovanie ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[Obrazovanie]");
                CbObrazovanie.ItemsSource = dataSet.Tables["[Obrazovanie]"].DefaultView;
                CbObrazovanie.DisplayMemberPath =
                dataSet.Tables["[Obrazovanie]"].
                    Columns["ObrazovanieName"].ToString();
                CbObrazovanie.SelectedValuePath =
                    dataSet.Tables["[Obrazovanie]"].Columns["IdObrazovanie"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally { sqlConnection.Close(); }
        }
        public void LoadProfession(ComboBox CbProfession)
        {

            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("SELECT IdTrydKniga, " +
                    "ProfessionName FROM dbo.[Profession] Order by IdTrydKniga ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[Profession]");
                CbProfession.ItemsSource = dataSet.Tables["[Profession]"].DefaultView;
                CbProfession.DisplayMemberPath =
                dataSet.Tables["[Profession]"].
                    Columns["ProfessionName"].ToString();
                CbProfession.SelectedValuePath =
                    dataSet.Tables["[Profession]"].Columns["IdTrydKniga"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally { sqlConnection.Close(); }
        }
    }
}