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
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;

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
            DBConnection.getConnection();
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


            //switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            //{
            //case "ItemHome":
            UserControl usc = new SummerDetails();
            GridMain.Children.Clear();
            GridMain.Children.Add(usc);
                    //break;
                //case "ItemCreate":
                //    usc = new UserControlCreate();
                //    GridMain.Children.Add(usc);
                //    break;
                //default:
                    //break;
            //}
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
