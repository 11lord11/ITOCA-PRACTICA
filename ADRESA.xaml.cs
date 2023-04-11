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
using WpfApp2.online_storeDataSetTableAdapters;

namespace ITOG_PRACTICA
{
    
    public partial class ADRESA : Window
    {
        addressesTableAdapter addresses = new addressesTableAdapter();
        customersTableAdapter customers = new customersTableAdapter();
        public ADRESA()
        {
            InitializeComponent();
            ADRES.ItemsSource = addresses.GetData();
            PolysovatelTbx.ItemsSource = customers.GetData();
            PolysovatelTbx.DisplayMemberPath = "first_name";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ADMIN window = new ADMIN();
            window.Show();
            this.Hide();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SOTRUDNIKI window = new SOTRUDNIKI();
            window.Show();
            this.Hide();
        }
        private void Button_Click_DOBAV(object sender, RoutedEventArgs e)
        {
            if (NameTbx.Text == "" || GorodTbx.Text == "" || StateTbx.Text == "" || ZipCodeTbx.Text == "" || PolysovatelTbx.SelectedValue == null)
            {
                MessageBox.Show("Поля пустые");
            }
            else
            {
                string input = NameTbx.Text;
                string input2 = GorodTbx.Text;
                string input3 = StateTbx.Text;
                string input4 = ZipCodeTbx.Text;
                if (System.Text.RegularExpressions.Regex.IsMatch(input, "^[a-zA-Z.,А-Яа-я0-9 ]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input2, "^[a-zA-ZА-Яа-я ]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input3, "^[a-zA-ZА-Яа-я ]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input4, "^[0-9]+$"))
                {
                    object id = (PolysovatelTbx.SelectedItem as DataRowView).Row[0];
                    addresses.InsertQuery(Convert.ToInt32((PolysovatelTbx.SelectedItem as DataRowView).Row[0]), NameTbx.Text, GorodTbx.Text, StateTbx.Text, ZipCodeTbx.Text);
                    ADRES.ItemsSource = addresses.GetData();
                }
            }
        }
        private void Button_Click_DELIT(object sender, RoutedEventArgs e)
        {
            object id = (ADRES.SelectedItem as DataRowView).Row[0];
            addresses.DeleteQuery(Convert.ToInt32(id));
            ADRES.ItemsSource = addresses.GetData();
        }
        private void Button_Click_ADD(object sender, RoutedEventArgs e)
        {
            if (NameTbx.Text == "" || GorodTbx.Text == "" || StateTbx.Text == "" || ZipCodeTbx.Text == "" || PolysovatelTbx.SelectedValue == null)
            {
                MessageBox.Show("Поля пустые");
            }
            else
            {
                string input = NameTbx.Text;
                string input2 = GorodTbx.Text;
                string input3 = StateTbx.Text;
                string input4 = ZipCodeTbx.Text;
                if (System.Text.RegularExpressions.Regex.IsMatch(input, "^[a-zA-Z.,А-Яа-я0-9 ]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input2, "^[a-zA-ZА-Яа-я ]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input3, "^[a-zA-ZА-Яа-я ]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input4, "^[0-9]+$"))
                {
                    object id = (ADRES.SelectedItem as DataRowView).Row[0];
                    addresses.UpdateQuery(Convert.ToInt32((PolysovatelTbx.SelectedItem as DataRowView).Row[0]), NameTbx.Text, GorodTbx.Text, StateTbx.Text, ZipCodeTbx.Text, (Convert.ToInt32(id)));
                    ADRES.ItemsSource = addresses.GetData();
                }
            }
        }

        private void ADRES_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ADRES.SelectedItem != null)
            {
                object selectedRow = (ADRES.SelectedItem as DataRowView).Row[1];
                object selectedRow2 = (ADRES.SelectedItem as DataRowView).Row[2];
                object selectedRow3 = (ADRES.SelectedItem as DataRowView).Row[3];
                object selectedRow4 = (ADRES.SelectedItem as DataRowView).Row[4];
                object selectedRow5 = (ADRES.SelectedItem as DataRowView).Row[5];


                NameTbx.Text = Convert.ToString(selectedRow);
                GorodTbx.Text = Convert.ToString(selectedRow2);
                StateTbx.Text = Convert.ToString(selectedRow3);
                ZipCodeTbx.Text = Convert.ToString(selectedRow4);
                PolysovatelTbx.Text = Convert.ToString(selectedRow5);
               


            }

            

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PRODUCT window = new PRODUCT();
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
    }
}
