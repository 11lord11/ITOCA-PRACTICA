using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
using WpfApp2;
using WpfApp2.online_storeDataSetTableAdapters;

namespace ITOG_PRACTICA
{
    /// <summary>
    /// Логика взаимодействия для CATEGORII.xaml
    /// </summary>
    public partial class CATEGORII : Window
    {
        categoriesTableAdapter categories = new categoriesTableAdapter();
        productsTableAdapter products = new productsTableAdapter();
        public CATEGORII()
        {
            InitializeComponent();
            CATEGOR.ItemsSource = categories.GetData();
            ProductTbx.ItemsSource = products.GetData();
            ProductTbx.DisplayMemberPath = "name";
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
            PRODUCT window = new PRODUCT();
            window.Show();
            this.Hide();
        }




        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ELEMTT window = new ELEMTT();
            window.Show();
            this.Hide();
        }
        private void Button_Click_DOBAV(object sender, RoutedEventArgs e)
        {
            if (NameTbx.Text == "" || DescriptTbx.Text == "" || ProductTbx.SelectedValue == null)
            {
                MessageBox.Show("Поля пустые");
            }
            else
            {
                string input = NameTbx.Text;
                
                string input3 = DescriptTbx.Text;
                
                if (System.Text.RegularExpressions.Regex.IsMatch(input, "^[a-zA-Z0-9а-яА-Я0-9 ]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input3, "^[a-zA-Z0-9а-яА-Я0-9 ]+$")
                    )
                {
                    object id = (ProductTbx.SelectedItem as DataRowView).Row[0];
                    categories.InsertQuery(NameTbx.Text, DescriptTbx.Text, Convert.ToInt32((ProductTbx.SelectedItem as DataRowView).Row[0]));
                    CATEGOR.ItemsSource = categories.GetData();
                }
            }
        }
        private void Button_Click_DELIT(object sender, RoutedEventArgs e)
        {
            object id = (CATEGOR.SelectedItem as DataRowView).Row[0];
            categories.DeleteQuery(Convert.ToInt32(id));
            CATEGOR.ItemsSource = categories.GetData();
        }
        private void Button_Click_ADD(object sender, RoutedEventArgs e)
        {
            if (NameTbx.Text == "" || DescriptTbx.Text == "" || ProductTbx.SelectedValue == null)
            {
                MessageBox.Show("Поля пустые");
            }
            else
            {
                string input = NameTbx.Text;
                
                string input3 = DescriptTbx.Text;
                
                if (System.Text.RegularExpressions.Regex.IsMatch(input, "^[a-zA-Z0-9а-яА-Я0-9 ]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input3, "^[a-zA-Z0-9а-яА-Я0-9 ]+$"))
                {
                    object id = (CATEGOR.SelectedItem as DataRowView).Row[0];
                    categories.UpdateQuery(NameTbx.Text, DescriptTbx.Text, (Convert.ToInt32(CATEGOR.SelectedItem as DataRowView)), (Convert.ToInt32(id)));
                    CATEGOR.ItemsSource = categories.GetData();
                }
            }
        }
        private void CATEGOR_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CATEGOR.SelectedItem != null)
            {
                object selectedRow = (CATEGOR.SelectedItem as DataRowView).Row[1];
                object selectedRow2 = (CATEGOR.SelectedItem as DataRowView).Row[2];
                object selectedRow3 = (CATEGOR.SelectedItem as DataRowView).Row[3];
               


                NameTbx.Text = Convert.ToString(selectedRow);
                DescriptTbx.Text = Convert.ToString(selectedRow2);
                ProductTbx.Text = Convert.ToString(selectedRow3);
                



            }



        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            List<Class2> forImport2 = Deserializ.DeserializeObject<List<Class2>>();
            foreach (var item in forImport2)
            {
                categories.InsertQuery(item.Name, item.Description,Convert.ToInt32(item.prod_id));

            }
            CATEGOR.ItemsSource = null;
            CATEGOR.ItemsSource = categories.GetData();
        }

       
    }
}
