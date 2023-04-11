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
using WpfApp2.online_storeDataSetTableAdapters;
namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для KASSIR.xaml
    /// </summary>
    public partial class KASSIR : Window
    {
        order_itemsTableAdapter order_items = new order_itemsTableAdapter();
        public KASSIR()
        {
            InitializeComponent();
            orders_items.ItemsSource = order_items.GetData();
        }

        private void orders_Click(object sender, RoutedEventArgs e)
        {
            Orders window = new Orders();
            window.Show();
            this.Hide();
        }
    }
}
