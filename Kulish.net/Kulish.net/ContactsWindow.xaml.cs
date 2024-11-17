using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Kulish.net
{
    /// <summary>
    /// Логика взаимодействия для ContactsWindow.xaml
    /// </summary>
    public partial class ContactsWindow : Window
    {
        public ContactsWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new ContactsWindow();
            newForm.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var newForm = new CatalogWindow();
            newForm.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var newForm = new MainWindow2();
            newForm.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var newForm = new ProfileWindow();
            newForm.Show();
            this.Close();
        }

        private void Button_Click6(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://yandex.ru/maps/213/moscow/house/1_y_shchipkovskiy_pereulok_23s1/Z04YcARhTkQFQFtvfXtzdXhrYA==/?indoorLevel=1&ll=37.631712%2C55.724484&z=16.72") { UseShellExecute = true });
        }
    }
}
