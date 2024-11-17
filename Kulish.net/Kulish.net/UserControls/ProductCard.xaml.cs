using System.ComponentModel;
using System.Windows.Controls;

namespace Kulish.net.UserControls
{
    public delegate void AddInBusket(int id_user, int id_sneaker);
    /// <summary>
    /// Логика взаимодействия для ProductCard.xaml
    /// </summary>
    public partial class ProductCard : UserControl
    {
        private int id = -1;
        private int user_id = -1;
        private AddInBusket Method;

        public ProductCard()
        {
            InitializeComponent();
        }

        public string TextOfDescription
        {
            set => ProductDiscription.Text = value;
            get => ProductDiscription.Text;
        }
        public string TextOfName
        {
            set => ProductName.Text = value;
            get => ProductName.Text;
        }
        public string TextOfPrice
        {
            set => ProductPrice.Text = value;
            get => ProductPrice.Text;
        }
        public int ProductId
        {
            set => id = value;
            get => id;
        }
        public int UserId
        {
            set => user_id = value;
            get => user_id;
        }
        public AddInBusket Add
        {
            set => Method = value;
        }

        private void Border_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Method == null) return;
            Method.Invoke(user_id, id);
        }
    }
}
