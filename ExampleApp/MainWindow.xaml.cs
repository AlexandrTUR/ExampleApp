using Microsoft.Win32;
using System;
using System.Configuration;
using System.Data.SqlClient;
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
using System.IO;

namespace ExampleApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // this.Title = "Hello To All";        //задаём значение для title
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;  // установка укна в центр

        }

        private void ExitProgram_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            saveToFile();
        }

        private void OpenNewFile_Click(object sender, RoutedEventArgs e)
        { 
            OpenFileDialog ofd = new OpenFileDialog();

            bool? res = ofd.ShowDialog(); // чтобы можно было поместить значение null в bool

            if (res != false) { 
                Stream myStream;
                if ((myStream = ofd.OpenFile()) != null)
                {
                    string file_name = ofd.FileName;
                    string file_text = File.ReadAllText(file_name);
                    textBox.Text = file_text;
                }
            }
        }
        private void TimesNewRomanFont_Click(object sender, RoutedEventArgs e)
        {
            textBox.FontFamily = new FontFamily("Times new Roman");
            verdanaFont.IsChecked = false;
        }

        private void VerdanaFont_Click(object sender, RoutedEventArgs e)
        {
            textBox.FontFamily = new FontFamily("Verdana");
            timesNewRomanFont.IsChecked = false;
        }

        private void SelectFotnSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            string fontSize = selectFotnSize.SelectedItem.ToString();
            fontSize = fontSize.Substring(fontSize.Length - 2);
            switch (fontSize)
            {
                case "10":
                    textBox.FontSize = 10;
                    break;
                case "12":
                    textBox.FontSize = 12;
                    break;
                case "14":
                    textBox.FontSize = 14;
                    break;
                case "16":
                    textBox.FontSize = 16;
                    break;
                case "18":
                    textBox.FontSize = 18;
                    break;
                case "20":
                    textBox.FontSize = 20;
                    break;
            }
        }

        private void CreateNewFile_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text != "") {
                saveToFile();
            }
            textBox.Text = "";

        }

        private void saveToFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();
             bool ? res = sfd.ShowDialog();

            if (res!= false)
            { 
            using (Stream s = File.Open(sfd.FileName, FileMode.OpenOrCreate))
            {
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(textBox.Text);
                }

                }
            }
        }

        private void RegBn_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = ConfigurationManager.AppSettings["connectionString"];

            SqlConnection sql = new SqlConnection(connectionString);

            try
            {
                if (sql.State == System.Data.ConnectionState.Closed)
                    sql.Open();

                string query = "SELECT COUNT(1) FROM Users WHERE login=@login AND password=@pass";
                SqlCommand sqlCom = new SqlCommand(query, sql);
                sqlCom.CommandType = System.Data.CommandType.Text;
                sqlCom.Parameters.Add("@login", loginField.Text);
                sqlCom.Parameters.Add("@pass", passField.Password);

                int countUser = Convert.ToInt32(sqlCom.ExecuteScalar());
                if (countUser == 0)
                {
                    query = "INSERT INTO Users(login, password) VALUES(@login, @pass)";
                    SqlCommand com = new SqlCommand(query, sql);
                    com.CommandType = System.Data.CommandType.Text;
                    com.Parameters.Add("@login", loginField.Text);
                    com.Parameters.Add("@pass", passField.Password);

                    com.ExecuteNonQuery();
                    MessageBox.Show("Мы добавили вас в БД");
                }
                else {
                    MessageBox.Show("Вы успешно авторизовались!");
                    AuthPage authPage = new AuthPage();
                    authPage.Show();

                    App.Current.MainWindow.Hide();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally {
                sql.Close();
            }
        }
    }
}
