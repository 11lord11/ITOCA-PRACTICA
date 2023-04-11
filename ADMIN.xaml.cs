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
using WpfApp2;
using WpfApp2.online_storeDataSetTableAdapters;

namespace ITOG_PRACTICA
{
    /// <summary>
    /// Логика взаимодействия для ADMIN.xaml
    /// </summary>
    public partial class ADMIN : Window
    {
        rolesTableAdapter roles = new rolesTableAdapter();
        public ADMIN()
        {
            InitializeComponent();
            ROLI.ItemsSource = roles.GetData();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SOTRUDNIKI window = new SOTRUDNIKI();
            window.Show();
            this.Hide();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ADRESA window = new ADRESA();
            window.Show();
            this.Hide();
        }


        private void Button_Click_DOBAV(object sender, RoutedEventArgs e)
        {
            if (NameTbx.Text == "" || PasswordTbx.Password == "" )
            {
                MessageBox.Show("Поля пустые");
            }
            else
            {
                string input = NameTbx.Text;
                string input2 = PasswordTbx.Password;
                
                if (System.Text.RegularExpressions.Regex.IsMatch(input, "^[a-zA-Z]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input2, "^[a-zA-Z0-9!?/.,]+$"))
                {
                    roles.InsertQuery(NameTbx.Text, PasswordTbx.Password);
                    ROLI.ItemsSource = roles.GetData();
                }
            }
        }

        private void Button_Click_DELIT(object sender, RoutedEventArgs e)
        {
            object id = (ROLI.SelectedItem as DataRowView).Row[0];
            roles.DeleteQuery(Convert.ToInt32(id));
            ROLI.ItemsSource = roles.GetData();
        }

        private void Button_Click_ADD(object sender, RoutedEventArgs e)
        {
            if (NameTbx.Text == "" || PasswordTbx.Password == "")
            {
                MessageBox.Show("Поля пустые");
            }
            else
            {
                string input = NameTbx.Text;
                string input2 = PasswordTbx.Password;

                if (System.Text.RegularExpressions.Regex.IsMatch(input, "^[a-zA-Z]+$") &&
                    System.Text.RegularExpressions.Regex.IsMatch(input2, "^[a-zA-Z0-9!?/.,]+$"))
                {
                    object id = (ROLI.SelectedItem as DataRowView).Row[0];
                    roles.UpdateQuery(NameTbx.Text, PasswordTbx.Password, (Convert.ToInt32(id)));
                    ROLI.ItemsSource = roles.GetData();
                }
                
            }
        }

        private void ROLI_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ROLI.SelectedItem != null)
            {
                object selectedRow = (ROLI.SelectedItem as DataRowView).Row[1];
                object selectedRow2 = (ROLI.SelectedItem as DataRowView).Row[2];
                NameTbx.Text = Convert.ToString(selectedRow);
                PasswordTbx.Password = Convert.ToString(selectedRow2);
               
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

        private void Button_Import(object sender, RoutedEventArgs e)
        {
            List<Class1> forImport = Deserializ.DeserializeObject<List<Class1>>();
            foreach (var item in forImport)
            {
                roles.InsertQuery(item.Name, item.Password);

            }
            ROLI.ItemsSource = null;
            ROLI.ItemsSource = roles.GetData();
        }
    }
}
