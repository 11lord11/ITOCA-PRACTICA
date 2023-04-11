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
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders : Window
    {
        ordersTableAdapter order = new ordersTableAdapter();
        public Orders()
        {
            InitializeComponent();
            orders_items.ItemsSource = order.GetData();
        }

        private void orders_Click(object sender, RoutedEventArgs e)
        {
            KASSIR window = new KASSIR();
            window.Show();
            this.Hide();
        }
    }
}
