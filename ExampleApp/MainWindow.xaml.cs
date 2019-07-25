using Microsoft.Win32;
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

        private void ExitProgram_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e) {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
        }

        private void OpenNewFile_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();  
        }

        private void TimesNewRomanFont_Click(object sender, RoutedEventArgs e) {
            textBox.FontFamily = new FontFamily("Times new Roman");
            verdanaFont.IsChecked = false;
        }

        private void VerdanaFont_Click(object sender, RoutedEventArgs e) {
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
    }
}
