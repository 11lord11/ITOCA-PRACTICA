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
using System.Xml.Linq;
using WpfApp2.online_storeDataSetTableAdapters;
namespace ITOG_PRACTICA
{
    /// <summary>
    /// Логика взаимодействия для PRODUCT.xaml
    /// </summary>
    public partial class PRODUCT : Window
    {
        productsTableAdapter products = new productsTableAdapter();
        public PRODUCT()
        {
            InitializeComponent();
            PRODUCTT.ItemsSource = products.GetData();
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
             ELEMTT window = new ELEMTT();
             window.Show();
             this.Hide();
         }

        private void Button_Click_DOBAV(object sender, RoutedEventArgs e)
        {
            if (NameTbx.Text == "" || DescriptTbx.Text == "" || Price.Text == "" || CategoryaTbx.Text == "" )
            {
                MessageBox.Show("Поля пустые");
            }
            else
            {
                string input = NameTbx.Text;
                string input2 = Price.Text;
                string input3 = DescriptTbx.Text;
                string input4 = CategoryaTbx.Text;
                if (System.Text.RegularExpressions.Regex.IsMatch(input, "^[a-zA-Zа-яА-Я0-9 ]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input2, "^[0-9]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input3, "^[a-zA-Zа-яА-Я ]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input4, "^[a-zA-Zа-яА-Я0-9 ]+$"))
                {

                    products.InsertQuery(NameTbx.Text, DescriptTbx.Text, Convert.ToDecimal(Price.Text), CategoryaTbx.Text);
                    PRODUCTT.ItemsSource = products.GetData();
                }
            }

        }
        private void Button_Click_DELIT(object sender, RoutedEventArgs e)
        {
            object id = (PRODUCTT.SelectedItem as DataRowView).Row[0];
            products.DeleteQuery(Convert.ToInt32(id));
            PRODUCTT.ItemsSource = products.GetData();
        }
        private void Button_Click_ADD(object sender, RoutedEventArgs e)
        {
            if (NameTbx.Text == "" || DescriptTbx.Text == "" || Price.Text == "" || CategoryaTbx.Text == "" )
            {
                MessageBox.Show("Поля пустые");
            }
            else
            {
                string input = NameTbx.Text;
                string input2 = Price.Text;
                string input3 = DescriptTbx.Text;
                string input4 = CategoryaTbx.Text;
                if (System.Text.RegularExpressions.Regex.IsMatch(input, "^[a-zA-Zа-яА-Я0-9 ]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input2, "^[0-9]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input3, "^[a-zA-Zа-яА-Я ]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input4, "^[a-zA-Zа-яА-Я0-9 ]+$"))
                {
                    object id = (PRODUCTT.SelectedItem as DataRowView).Row[0];
                    products.UpdateQuery(NameTbx.Text, DescriptTbx.Text, Convert.ToDecimal(Price), CategoryaTbx.Text, (Convert.ToInt32(id)));
                    PRODUCTT.ItemsSource = products.GetData();
                }
            }
        }
        private void PRODUCT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PRODUCTT.SelectedItem != null)
            {
                object selectedRow = (PRODUCTT.SelectedItem as DataRowView).Row[1];
                object selectedRow2 = (PRODUCTT.SelectedItem as DataRowView).Row[2];
                object selectedRow3 = (PRODUCTT.SelectedItem as DataRowView).Row[3];
                object selectedRow4 = (PRODUCTT.SelectedItem as DataRowView).Row[4];
                NameTbx.Text = Convert.ToString(selectedRow);
                DescriptTbx.Text = Convert.ToString(selectedRow2);
                Price.Text = Convert.ToString(selectedRow3);
                CategoryaTbx.Text = Convert.ToString(selectedRow4);


            }
        }


    }
}
