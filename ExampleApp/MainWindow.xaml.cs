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

        private void ButtonMassageBox_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Мы открыли дополнительное окно!");
        }

        private void CloseLabel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void GetInput_Click(object sender, RoutedEventArgs e)
        {
            string userInput = userInputField.Text;
            if (userInput != "")
                MessageBox.Show(userInput);
        }
    }
}
