using Kulish.net.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        private DbConnectionConfig config;
        private DataBaseContext context;
        private RepositoryUsers repository;

        public static int IdUser { get; set; }

        public ProfileWindow()
        {
            InitializeComponent();

            config = DbConnectionConfig.OpenAsFile();
            context = new DataBaseContext(config.ToString());
            repository = new RepositoryUsers(context);

            try
            {
                DataRow row = repository.GetById(IdUser);
                FIO.Text = row["fullName"].ToString();
                PhoneNumber.Text = row["phoneNumber"].ToString();
                Login.Text = row["Login"].ToString();
                Password.Text = row["Password"].ToString();
                RepeatPassword.Text = row["Password"].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                repository.Update(IdUser, FIO.Text, PhoneNumber.Text, Login.Text, Password.Text);
                var newForm = new ContactsWindow();
                newForm.Show();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var newForm = new CatalogWindow();
            newForm.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var newForm = new MainWindow();
            newForm.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var newForm = new ProfileWindow();
            newForm.Show();
            this.Close();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            var newForm = new LoginWindow();
            newForm.Show();
            this.Close();
        }
    }
}
