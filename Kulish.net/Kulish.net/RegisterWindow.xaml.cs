using Kulish.net.DataBase;
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

namespace Kulish.net
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private DataBaseContext context;
        private RepositoryUsers repository;
        public RegisterWindow()
        {
            InitializeComponent();
        }

        public RegisterWindow(DataBaseContext context)
        {
            InitializeComponent();
            this.context = context;
            repository = new RepositoryUsers(context);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new LoginWindow();
            newForm.Show();
            this.Close();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new RegisterWindow();
            newForm.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                repository.Add(FIO.Text, PhoneNumber.Text, Login.Text, Password.Text);
                var newForm = new CatalogWindow(context, repository.GetByLoginAndPassword(Login.Text, Password.Text));
                newForm.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var newForm = new MainWindow();
            newForm.Show();
            this.Close();
        }
    }
}
