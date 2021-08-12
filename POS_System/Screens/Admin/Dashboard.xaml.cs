using System.Windows;
using System.Windows.Controls;
using Employee = POS_System.Screens.Admin.Employee;
using User = POS_System.Screens.Admin.Users;
using Produts = POS_System.Screens.Admin.Products;
using Categories = POS_System.Screens.Admin.Categories;
using Dealers = POS_System.Screens.Admin.Dealers;
using Customers = POS_System.Screens.Admin.Customers;
using Inventory = POS_System.Screens.Admin.Inventory;
using Transactions = POS_System.Screens.Admin.Transactions;
using Sale = POS_System.Screens.Admin.Sale;
using Purchase = POS_System.Screens.Admin.Purchase;

namespace POS_System.Screens.Admin
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
            _ = DBConnection.GetConnection();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //UserControl usc = null;


            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    GridMain.Children.Clear();
                    using (SummerDetails usc = new SummerDetails())
                    {
                        _ = GridMain.Children.Add(usc);
                    }
                    break;
                case "ItemCreate":
                    GridMain.Children.Clear();
                    using (Employee::Employee usc = new Employee::Employee())
                    {
                        _ = GridMain.Children.Add(usc);
                    }
                    break;
                case "User":
                    GridMain.Children.Clear();
                    using (User::Users usc = new User::Users())
                    {
                        _ = GridMain.Children.Add(usc);
                    }
                    break;
                case "Products":
                    GridMain.Children.Clear();
                    using (Produts::Products usc = new Produts::Products())
                    {
                        _ = GridMain.Children.Add(usc);
                    }
                    break;
                case "Categories":
                    GridMain.Children.Clear();
                    using (Categories::Categories usc = new Categories::Categories())
                    {
                        _ = GridMain.Children.Add(usc);
                    }
                    break;
                case "Dealers":
                    GridMain.Children.Clear();
                    using (Dealers::Dealers usc = new Dealers::Dealers())
                    {
                        _ = GridMain.Children.Add(usc);
                    }
                    break;
                case "Customers":
                    GridMain.Children.Clear();
                    using (Customers::Customers usc = new Customers::Customers())
                    {
                        _ = GridMain.Children.Add(usc);
                    }
                    break;
                case "Inventory":
                    GridMain.Children.Clear();
                    using (Inventory::Inventory usc = new Inventory::Inventory())
                    {
                        _ = GridMain.Children.Add(usc);
                    }
                    break;
                case "Transactions":
                    GridMain.Children.Clear();
                    using (Transactions::Transactions usc = new Transactions::Transactions())
                    {
                        _ = GridMain.Children.Add(usc);
                    }
                    break;
                case "Sale":
                    GridMain.Children.Clear();
                    using (Sale::FrmSale usc = new Sale::FrmSale())
                    {
                        _ = GridMain.Children.Add(usc);
                    }
                    break;
                case "Purchase":
                    GridMain.Children.Clear();
                    using (Purchase::Purchase usc = new Purchase::Purchase())
                    {
                        _ = GridMain.Children.Add(usc);
                    }
                    break;
                default:
                    break;
            }
        }

        private void Dash_Loaded(object sender, RoutedEventArgs e)
        {
            using (SummerDetails usc = new SummerDetails())
            {
                Uname.Text = MainWindow._name;
                _ = GridMain.Children.Add(usc);
            }
        }

        //public void ChartLoad()
        //{

        //    PieChart1.InnerRadius = 30;
        //    PieChart1.LegendLocation = LegendLocation.Bottom;



        //    PieChart1.Series = new SeriesCollection { };


        //        PieChart1.Series.Add(
        //            new PieSeries
        //            {
        //                Title = "year",
        //                Values = new ChartValues<double> { 25.25 },
        //                DataLabels = true
        //            }
        //        );


        //}

    }
}
