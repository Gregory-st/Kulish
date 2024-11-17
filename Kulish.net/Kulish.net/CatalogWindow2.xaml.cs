using Kulish.net.DataBase;
using Kulish.net.UserControls;
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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kulish.net
{
    /// <summary>
    /// Логика взаимодействия для CatalogWindow2.xaml
    /// </summary>
    public partial class CatalogWindow2 : Window
    {
        private DbConnectionConfig config;
        private DataBaseContext context;
        private RepositorySneakers repository;

        public CatalogWindow2()
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

                Cards.Children.Add(card);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new MainWindow();
            newForm.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var newForm = new CatalogWindow2();
            newForm.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var newForm = new ContactsWindow2();
            newForm.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var newForm = new LoginWindow();
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

                Cards.Children.Add(card);
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
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


                Cards.Children.Add(card);
            }
        }
    }
}
