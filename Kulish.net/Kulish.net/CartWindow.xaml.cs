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
    /// Логика взаимодействия для CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        private static int idUser;
        private DataBaseContext context;
        private RepositoryBaskets baskets;
        private RepositorySneakers sneakers;

        public CartWindow()
        {
            InitializeComponent();

            DbConnectionConfig config = DbConnectionConfig.OpenAsFile();
            context = new DataBaseContext(config.ToString());

            baskets = new RepositoryBaskets(context);
            sneakers = new RepositorySneakers(context);

            DataTable table = baskets.GetByUserId(idUser);

            foreach (DataRow i in table.Rows)
            {
                int id = Convert.ToInt32(i["id_sneaker"]);

                DataRow row = sneakers.GetAsId(id);
                ProductCard card = CopyElement(Pattern);

                card.TextOfName = row["name"].ToString();
                card.TextOfDescription = row["descryption"].ToString();
                card.TextOfPrice = i["price"].ToString();
                card.ProductId = Convert.ToInt32(row["sneakersID"]);
                card.PathResourse = row["image"].ToString();

                Cards.Children.Add(card);
            }
        }

        public CartWindow(int iduser, DataBaseContext context)
        {
            InitializeComponent();
            idUser = iduser;
            this.context = context;

            baskets = new RepositoryBaskets(context);
            sneakers = new RepositorySneakers(context);

            DataTable table = baskets.GetByUserId(iduser);

            foreach(DataRow i in table.Rows)
            {
                int id = Convert.ToInt32(i["id_sneaker"]);

                DataRow row = sneakers.GetAsId(id);
                ProductCard card = CopyElement(Pattern);

                card.TextOfName = row["name"].ToString();
                card.TextOfDescription = row["descryption"].ToString();
                card.TextOfPrice = i["price"].ToString();
                card.ProductId = Convert.ToInt32(row["sneakersID"]);
                card.PathResourse = row["image"].ToString();

                Cards.Children.Add(card);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var newForm = new MainWindow2();
            newForm.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var newForm = new CatalogWindow();
            newForm.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new ContactsWindow();
            newForm.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var newForm = new ProfileWindow();
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
    }
}
