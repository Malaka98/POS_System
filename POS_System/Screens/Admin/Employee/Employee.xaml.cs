using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;


namespace POS_System.Screens.Admin.Employee
{
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : UserControl, IDisposable
    {
        private int EmpID = -1;
        private bool disposedValue;

        public Employee()
        {
            InitializeComponent();
            DisplayData();
        }

        private void DisplayData()
        {
            Display dis = new Display();
            DataTable dt = dis.Display_query();
            grid_Employee.ItemsSource = dt.DefaultView;
            dis.Dispose();
        }

        private void Insert_Button_Click(object sender, RoutedEventArgs e)
        {

            if (!EmpValidation.IsValidate(name.Text, idnum.Text, address.Text, mobile.Text, sname.Text, dob.Text, rdate.Text, sex.SelectedIndex.ToString(), sallary.Text, age.Text))
            {
                Employer newEmp = new Employer(name.Text, int.Parse(idnum.Text), address.Text, int.Parse(mobile.Text), sname.Text, dob.Text, rdate.Text, sex.SelectedItem.ToString(), int.Parse(sallary.Text), int.Parse(age.Text));

                Insert insert_query = new Insert(newEmp);
                insert_query.Insert_Query();
                insert_query.Dispose();
                DisplayData();
            }
        }

        private void Grid_Employee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid gd = (DataGrid)sender;
                DataRowView row_selected = gd.SelectedItem as DataRowView;
                if (row_selected != null)
                {
                    EmpID = Convert.ToInt32(row_selected[0].ToString());
                    name.Text = row_selected[1].ToString();
                    sname.Text = row_selected[2].ToString();
                    idnum.Text = row_selected[3].ToString();
                    sex.Text = row_selected[4].ToString();
                    dob.Text = row_selected[5].ToString();
                    age.Text = row_selected[6].ToString();
                    address.Text = row_selected[7].ToString();
                    mobile.Text = row_selected[8].ToString();
                    rdate.Text = row_selected[9].ToString();
                    sallary.Text = row_selected[10].ToString();
                }
            }


            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
            }
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!EmpValidation.IsValidate(name.Text, idnum.Text, address.Text, mobile.Text, sname.Text, dob.Text, rdate.Text, sex.SelectedIndex.ToString(), sallary.Text, age.Text))
            {
                if (EmpID != -1)
                {
                    Employer updateEmp = new Employer(name.Text, int.Parse(idnum.Text), address.Text, int.Parse(mobile.Text), sname.Text, dob.Text, rdate.Text, sex.SelectedIndex.ToString(), int.Parse(sallary.Text), int.Parse(age.Text));
                    Update updEmp = new Update(updateEmp);
                    updEmp.Update_Query(EmpID);
                    updEmp.Dispose();
                    DisplayData();
                }
                else
                {
                    _ = MessageBox.Show("Please select Employer");
                }
            }
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (EmpID != -1)
            {

                Delete delEmp = new Delete();
                delEmp.Delete_Query(EmpID);
                delEmp.Dispose();
                DisplayData();
            }
            else
            {
                _ = MessageBox.Show("Please select Employer");
            }
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search sch = new Search();
            DataTable dt = sch.Search_Query(search.Text);
            grid_Employee.ItemsSource = dt.DefaultView;
            sch.Dispose();

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Employee()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
