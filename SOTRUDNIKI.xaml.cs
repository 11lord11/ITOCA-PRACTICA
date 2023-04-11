using WpfApp2.online_storeDataSetTableAdapters;
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

namespace ITOG_PRACTICA
{
    /// <summary>
    /// Логика взаимодействия для SOTRUDNIKI.xaml
    /// </summary>
    public partial class SOTRUDNIKI : Window
    {
        customersTableAdapter customers = new customersTableAdapter();
        rolesTableAdapter roles = new rolesTableAdapter();  
        public SOTRUDNIKI()
        {
            InitializeComponent();
            SOTRUDNIK.ItemsSource = customers.GetData();
            RoliTbx.ItemsSource = roles.GetData();
            RoliTbx.DisplayMemberPath = "role_name";
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
        private void Button_Click_DOBAV(object sender, RoutedEventArgs e)
        {
            if (NameTbx.Text == "" || FamilTbx.Text == "" || PochtaTbx.Text == "" || PasswordTbxROL.Password == ""|| PasswordTbx.Password == "" || RoliTbx.SelectedValue == null)
            {
                MessageBox.Show("Поля пустые");
            }
            else
            {
                string input = NameTbx.Text;
                string input2 = FamilTbx.Text;
                string input3 = PochtaTbx.Text;
                string input4 = PasswordTbx.Password;
                string input5 = PasswordTbxROL.Password;
                if (System.Text.RegularExpressions.Regex.IsMatch(input, "^[a-zA-ZА-Яа-я]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input2, "^[a-zA-ZА-Яа-я]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input3, "^[a-zA-ZА-Яа-я@.,/0-9]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input4, "^[a-zA-Z0-9]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input5, "^[a-zA-Z0-9]+$"))
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(input3, "^[a-zA-Z0-9]+$"))
                    {
                        MessageBox.Show("в маиле нет собаки");

                    }
                    else
                    {
                        object id = (RoliTbx.SelectedItem as DataRowView).Row[0];
                        customers.InsertQuery(NameTbx.Text, FamilTbx.Text, PochtaTbx.Text, PasswordTbx.Password, (Convert.ToInt32(id)), PasswordTbxROL.Password);
                        SOTRUDNIK.ItemsSource = customers.GetData();
                    }
                    

                }

            }
            
            
        }
        private void Button_Click_DELIT(object sender, RoutedEventArgs e)
        {
            object id = (SOTRUDNIK.SelectedItem as DataRowView).Row[0];
            customers.DeleteQuery(Convert.ToInt32(id));
            SOTRUDNIK.ItemsSource = customers.GetData();
        }
        private void Button_Click_ADD(object sender, RoutedEventArgs e)
        {
            if (NameTbx.Text == "" || FamilTbx.Text == "" || PochtaTbx.Text == "" || PasswordTbxROL.Password == "" || PasswordTbx.Password == "" || RoliTbx.SelectedValue == null)
            {
                MessageBox.Show("Поля пустые");
            }
            else
            {
                string input = NameTbx.Text;
                string input2 = FamilTbx.Text;
                string input3 = PochtaTbx.Text;
                string input4 = PasswordTbx.Password;
                string input5 = PasswordTbxROL.Password;
                if (System.Text.RegularExpressions.Regex.IsMatch(input, "^[a-zA-ZА-Яа-я]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input2, "^[a-zA-ZА-Яа-я]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input3, "^[a-zA-ZА-Яа-я@.,/0-9]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input4, "^[a-zA-Z0-9]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input5, "^[a-zA-Z0-9]+$"))
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(input3, "^[a-zA-Z0-9]+$"))
                    {
                        MessageBox.Show("в маиле нет собаки");
Ы
                    }
                    else
                    {
                        object id = (SOTRUDNIK.SelectedItem as DataRowView).Row[0];
                        customers.UpdateQuery(NameTbx.Text, FamilTbx.Text, PochtaTbx.Text, PasswordTbx.Password, Convert.ToInt32((RoliTbx.SelectedItem as DataRowView).Row[0]), PasswordTbxROL.Password, (Convert.ToInt32(id)));
                        SOTRUDNIK.ItemsSource = customers.GetData();
                    }
                }
            }
        }

        private void SOTRUDNIK_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SOTRUDNIK.SelectedItem != null)
            {
                object selectedRow = (SOTRUDNIK.SelectedItem as DataRowView).Row[1];
                object selectedRow2 = (SOTRUDNIK.SelectedItem as DataRowView).Row[2];
                object selectedRow3 = (SOTRUDNIK.SelectedItem as DataRowView).Row[3];
                object selectedRow4 = (SOTRUDNIK.SelectedItem as DataRowView).Row[4];
                object selectedRow5= (SOTRUDNIK.SelectedItem as DataRowView).Row[5];
                object selectedRow6 = (SOTRUDNIK.SelectedItem as DataRowView).Row[6];
                

                NameTbx.Text = Convert.ToString(selectedRow);
                FamilTbx.Text = Convert.ToString(selectedRow2);
                PochtaTbx.Text = Convert.ToString(selectedRow3);
                PasswordTbx.Password = Convert.ToString(selectedRow4);
                RoliTbx.Text = Convert.ToString(selectedRow5);
                PasswordTbxROL.Password = Convert.ToString(selectedRow6);
                

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CATEGORII window = new CATEGORII();
            window.Show();
            this.Hide();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PRODUCT window = new PRODUCT();
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
