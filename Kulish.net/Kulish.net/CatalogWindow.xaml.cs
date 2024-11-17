using Kulish.net.DataBase;
using Kulish.net.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kulish.net
{
    /// <summary>
    /// Логика взаимодействия для CatalogWindow.xaml
    /// </summary>
    public partial class CatalogWindow : Window
    {
        private DbConnectionConfig config;
        private DataBaseContext context;
        private RepositorySneakers repository;
        private RepositoryBaskets repositoryBaskets;

        public static int IdUser { get; set; }

        public CatalogWindow()
        {
            InitializeComponent();
            config = DbConnectionConfig.OpenAsFile();
            context = new DataBaseContext(config.ToString());
            repository = new RepositorySneakers(context);

            DataTable table = repository.Get();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                ProductCard card = CopyElement(Pattern);
                DataRow row = table.Rows[i];
                card.TextOfName = row["name"].ToString();
                card.TextOfDescription = row["descryption"].ToString();
                card.TextOfPrice = row["price"].ToString();
                card.ProductId = Convert.ToInt32(row["sneakersID"]);
                card.PathResourse = row["image"].ToString();

                card.UserId = IdUser;
                card.Add = AddBusket;

                Cards.Children.Add(card);
            }
        }

        public CatalogWindow(DataBaseContext context, DataRow user)
        {
            InitializeComponent();
            this.context = context;
            repository = new RepositorySneakers(context);
            repositoryBaskets = new RepositoryBaskets(context);

            DataTable table = repository.Get();

            IdUser = Convert.ToInt32(user["userID"]);
            ProfileWindow.IdUser = IdUser;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                ProductCard card = CopyElement(Pattern);
                DataRow row = table.Rows[i];
                card.TextOfName = row["name"].ToString();
                card.TextOfDescription = row["descryption"].ToString();
                card.TextOfPrice = row["price"].ToString();
                card.ProductId = Convert.ToInt32(row["sneakersID"]);
                card.PathResourse = row["image"].ToString();

                card.UserId = Convert.ToInt32(user["userID"]);
                card.Add = AddBusket;

                Cards.Children.Add(card);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new ContactsWindow();
            newForm.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var newForm = new MainWindow2();
            newForm.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var newForm = new CatalogWindow();
            newForm.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var newForm = new ProfileWindow();
            newForm.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var newForm = new CartWindow();
            newForm.Show();
            this.Close();
        }

        private ProductCard CopyElement(ProductCard product)
        {
            ProductCard card = new ProductCard
            {
                Width = product.Width,
                Height = product.Height,
                Margin = new Thickness(product.Margin.Left, product.Margin.Top, product.Margin.Right, product.Margin.Bottom)
            };

            card.Effect = new DropShadowEffect
            {
                Color = new Color
                {
                    A = 255,
                    R = 0,
                    G = 0,
                    B = 0,
                },
                Direction = 315,
                BlurRadius = 15,
                ShadowDepth = 5,
                Opacity = 0.5
            };

            return card;
        }

        private void AddBusket(int id_user, int id_sneaker)
        {
            try
            {
                DataRow row = repositoryBaskets.GetByUserIdAndSneakersId(id_user, id_sneaker);
                int id = Convert.ToInt32(row["id"]);
                int count = Convert.ToInt32(row["count"]) + 1;
                repositoryBaskets.Update(id, id_user, id_sneaker, count);
            }
            catch
            {
                repositoryBaskets.Add(id_user, id_sneaker, 1);
            }
        }

        private void Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cards == null) return; 

            Cards.Children.Clear();

            ComboBoxItem? item = Filter.SelectedItem as ComboBoxItem;

            DataTable table = repository.GetAsOrderBy(item.Tag.ToString());

            for (int i = 0; i < table.Rows.Count; i++)
            {
                ProductCard card = CopyElement(Pattern);
                DataRow row = table.Rows[i];
                card.TextOfName = row["name"].ToString();
                card.TextOfDescription = row["descryption"].ToString();
                card.TextOfPrice = row["price"].ToString();
                card.ProductId = Convert.ToInt32(row["sneakersID"]);
                card.PathResourse = row["image"].ToString();

                card.UserId = IdUser;
                card.Add = AddBusket;

                Cards.Children.Add(card);
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (Cards == null) return;

            Cards.Children.Clear();

            DataTable table = repository.GetAsSearch(SearchLine.Text);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                ProductCard card = CopyElement(Pattern);
                DataRow row = table.Rows[i];
                card.TextOfName = row["name"].ToString();
                card.TextOfDescription = row["descryption"].ToString();
                card.TextOfPrice = row["price"].ToString();
                card.ProductId = Convert.ToInt32(row["sneakersID"]);
                card.PathResourse = row["image"].ToString();

                card.UserId = IdUser;
                card.Add = AddBusket;

                Cards.Children.Add(card);
            }
        }
    }
}
