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
using WpfApp2.online_storeDataSetTableAdapters;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Jelania.xaml
    /// </summary>
    public partial class Jelania : Window
    {
        productsTableAdapter products = new productsTableAdapter();
        customersTableAdapter customers = new customersTableAdapter();
        wishlist_itemsTableAdapter wishlist = new wishlist_itemsTableAdapter();
        public Jelania()
        {
            InitializeComponent();
            pol.ItemsSource = wishlist.GetData();
            product.ItemsSource = products.GetData();
            product.DisplayMemberPath = "name";
            customer.ItemsSource = customers.GetData();
            customer.DisplayMemberPath = "first_name";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (product.SelectedValue == null || customer.SelectedValue == null)
            {
                MessageBox.Show("Поля пустые");
            }
            else
            {
                object id = (pol.SelectedItem as DataRowView).Row[0];
                wishlist.InsertQuery(Convert.ToInt32((customer.SelectedItem as DataRowView).Row[1]), Convert.ToInt32((product.SelectedItem as DataRowView).Row[2]));
                pol.ItemsSource = wishlist.GetData();

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (product.SelectedValue == null || customer.SelectedValue == null)
            {
                MessageBox.Show("Поля пустые");
            }
            else
            {
                object id = (pol.SelectedItem as DataRowView).Row[0];
                wishlist.UpdateQuery(Convert.ToInt32((customer.SelectedItem as DataRowView).Row[1]), Convert.ToInt32((product.SelectedItem as DataRowView).Row[2]),Convert.ToInt32(id));
                pol.ItemsSource = wishlist.GetData();

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            object id = (pol.SelectedItem as DataRowView).Row[0];
            wishlist.DeleteQuery(Convert.ToInt32(id));
            pol.ItemsSource = wishlist.GetData();
        }

        private void pol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pol.SelectedItem != null)
            {
               
                object selectedRow3 = (pol.SelectedItem as DataRowView).Row[1];
                object selectedRow4 = (pol.SelectedItem as DataRowView).Row[2];


                product.Text = Convert.ToString(selectedRow3);
                customer.Text = Convert.ToString(selectedRow4);
            }
        }

        private void wish_list_Click(object sender, RoutedEventArgs e)
        {
            POLSOVATELY window = new POLSOVATELY();
            window.Show();
            this.Hide();
        }
    }
}
