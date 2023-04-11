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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp2;
using WpfApp2.online_storeDataSetTableAdapters;


namespace ITOG_PRACTICA
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        customersTableAdapter adapter = new customersTableAdapter();
    
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var allLogins = adapter.GetData();
            for (int i = 0; i < allLogins.Count; i++)
            {
                if (allLogins[i][1].ToString () == LOGIN.Text &&
                    allLogins[i][4].ToString() == PASSWORD.Password)
                {
                    int role_id = (int)allLogins[i][5];
                    switch (role_id)
                    {
                        case 1:
                            ADMIN window1 = new ADMIN();
                            window1.Show();
                            break;
                        case 2:
                            KASSIR window2 = new KASSIR();
                            window2.Show();
                            break;
                        case 2003:
                            POLSOVATELY window3 = new POLSOVATELY();
                            window3.Show();
                            break;
                    }

                }
                    
            }
        }
        
    }
}
