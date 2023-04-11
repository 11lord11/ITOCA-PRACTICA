using ITOG_PRACTICA;
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
    /// Логика взаимодействия для POLSOVATELY.xaml
    /// </summary>
    public partial class POLSOVATELY : Window
    {
        reviewsTableAdapter reviews = new reviewsTableAdapter();
        productsTableAdapter products = new productsTableAdapter();
        customersTableAdapter customers = new customersTableAdapter();
        public POLSOVATELY()
        {
            InitializeComponent();
            pol.ItemsSource = reviews.GetData();
            product.ItemsSource = products.GetData();
            product.DisplayMemberPath = "name";
            customer.ItemsSource = customers.GetData();
            customer.DisplayMemberPath = "first_name";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (rating.Text == "" || review_text.Text == "" || customer.SelectedValue == null || product.SelectedValue == null)
            {
                MessageBox.Show("Поля пустые");
            }
            else
            {
                string input = rating.Text;
                string input2 = review_text.Text;

                if (System.Text.RegularExpressions.Regex.IsMatch(input, "^[0-9]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input2, "^[a-zA-Z0-9 .,]+$"))
                {
                    object id = (customer.SelectedItem as DataRowView).Row[0];
                    object id2 = (product.SelectedItem as DataRowView).Row[0];
                    reviews.InsertQuery(Convert.ToInt32(id),Convert.ToInt32(id2),Convert.ToInt32(rating.Text), review_text.Text);
                    pol.ItemsSource = reviews.GetData();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (rating.Text == "" || review_text.Text == "" || customer.SelectedValue == null || product.SelectedValue == null)
            {
                MessageBox.Show("Поля пустые");
            }
            else
            {
                string input = rating.Text;
                string input2 = review_text.Text;

                if (System.Text.RegularExpressions.Regex.IsMatch(input, "^[0-9]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input2, "^[a-zA-Z0-9 .,]+$"))
                {
                    object id = (customer.SelectedItem as DataRowView).Row[0];
                    object id2 = (product.SelectedItem as DataRowView).Row[0];
                    object id3 = (pol.SelectedItem as DataRowView).Row[0];
                    reviews.UpdateQuery(Convert.ToInt32(id), Convert.ToInt32(id2), Convert.ToInt32(rating.Text), review_text.Text,Convert.ToInt32(id3));
                    pol.ItemsSource = reviews.GetData();
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            object id = (pol.SelectedItem as DataRowView).Row[0];
            reviews.DeleteQuery(Convert.ToInt32(id));
            pol.ItemsSource = reviews.GetData();
        }

        private void pol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pol.SelectedItem != null)
            {
                object selectedRow = (pol.SelectedItem as DataRowView).Row[1];
                object selectedRow2 = (pol.SelectedItem as DataRowView).Row[2];
                object selectedRow3 = (pol.SelectedItem as DataRowView).Row[3];
                object selectedRow4 = (pol.SelectedItem as DataRowView).Row[4];


                rating.Text = Convert.ToString(selectedRow3);
                review_text.Text = Convert.ToString(selectedRow4);
                customer.Text = Convert.ToString(selectedRow);
                product.Text = Convert.ToString(selectedRow2);



            }
        }

        private void wish_list_Click(object sender, RoutedEventArgs e)
        {
            Jelania window = new Jelania();
            window.Show();
            this.Hide();
        }
    }
}
