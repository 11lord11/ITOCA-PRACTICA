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
using WpfApp2.online_storeDataSetTableAdapters;
namespace ITOG_PRACTICA
{
    /// <summary>
    /// Логика взаимодействия для ELEMTT.xaml
    /// </summary>
    public partial class ELEMTT : Window
    {
        cart_itemsTableAdapter cart_Items = new cart_itemsTableAdapter();
        customersTableAdapter customers = new customersTableAdapter();
        productsTableAdapter products = new productsTableAdapter();
        public ELEMTT()
        {
            InitializeComponent();
            ELEMET.ItemsSource = cart_Items.GetData();
            NameTbx.ItemsSource = customers.GetData();
            NameTbx.DisplayMemberPath = "last_name"; 
            product.ItemsSource = products.GetData();
            product.DisplayMemberPath = "name";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ADMIN window = new ADMIN();
            window.Show();
            this.Hide();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ADRESA window = new ADRESA();
            window.Show();
            this.Hide();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SOTRUDNIKI window = new SOTRUDNIKI();
            window.Show();
            this.Hide();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CATEGORII window = new CATEGORII();
            window.Show();
            this.Hide();
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            PRODUCT window = new PRODUCT();
            window.Show();
            this.Hide();
        }
        

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            object id = (NameTbx.SelectedItem as DataRowView).Row[0];
            cart_Items.DeleteQuery(Convert.ToInt32(id));
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (Quant.Text == "" || Price.Text == "" || NameTbx.SelectedValue == null || product.SelectedValue == null)
            {
                MessageBox.Show("Поля пустые");
            }
            else
            {
                string input = Quant.Text;
                string input2 = Price.Text;

                if (System.Text.RegularExpressions.Regex.IsMatch(input, "^[0-9.,]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input2, "^[0-9.,]+$"))
                {
                    object id = (NameTbx.SelectedItem as DataRowView).Row[0];
                    object id2 = (product.SelectedItem as DataRowView).Row[0];
                   
                    cart_Items.UpdateQuery(Convert.ToInt32(id), Convert.ToInt32(id2), Convert.ToInt32(Quant.Text), Convert.ToDecimal(Price.Text),Convert.ToInt32(id));
                    ELEMET.ItemsSource = products.GetData();
                }
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (Quant.Text == "" || Price.Text == "" || NameTbx.SelectedValue == null || product.SelectedValue == null)
            {
                MessageBox.Show("Поля пустые");
            }
            else
            {
                string input = Quant.Text;
                string input2 = Price.Text;

                if (System.Text.RegularExpressions.Regex.IsMatch(input, "^[0-9.,]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input2, "^[0-9.,]+$"))
                {
                    object id = (NameTbx.SelectedItem as DataRowView).Row[0];
                    object id2 = (product.SelectedItem as DataRowView).Row[0];
                    cart_Items.InsertQuery(Convert.ToInt32(id), Convert.ToInt32(id2), Convert.ToInt32(Quant.Text), Convert.ToDecimal(Price.Text));
                    ELEMET.ItemsSource = products.GetData();
                }
            }
        }

        private void ELEMET_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ELEMET.SelectedItem != null)
            {
                object selectedRow = (ELEMET.SelectedItem as DataRowView).Row[1];
                object selectedRow2 = (ELEMET.SelectedItem as DataRowView).Row[2];
                object selectedRow3 = (ELEMET.SelectedItem as DataRowView).Row[3];
                object selectedRow4 = (ELEMET.SelectedItem as DataRowView).Row[4];
                


                Quant.Text = Convert.ToString(selectedRow);
                Price.Text = Convert.ToString(selectedRow2);
                NameTbx.Text = Convert.ToString(selectedRow3);
                product.Text = Convert.ToString(selectedRow4);
                


            }
        }
    }
}
