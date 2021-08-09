using POS_System.Screens.Admin;
using System;
using System.Data.SqlClient;
using System.Windows;

namespace POS_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string loggedIn;
        public static string _name;
        private readonly DBConnection connectionOBJ = null;
        private SqlCommand cmd;
        private SqlDataReader rd;

        public MainWindow()
        {
            InitializeComponent();
            connectionOBJ = DBConnection.GetConnection();
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string _role = "";
                connectionOBJ.GetConn().Open();
                cmd = new SqlCommand("Select * from Login where username = @username and password = @password", connectionOBJ.GetConn());
                _ = cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                _ = cmd.Parameters.AddWithValue("@password", txtPassword.Password);

                rd = cmd.ExecuteReader();
                _ = rd.Read();

                bool found;
                if (rd.HasRows)
                {
                    found = true;

                    _role = rd["UserType"].ToString();
                    _name = rd["Name"].ToString();
                    loggedIn = txtUsername.Text;
                    _name = rd["Name"].ToString();

                }
                else
                {
                    found = false;
                }

                rd.Close();
                connectionOBJ.GetConn().Close();

                if (found)
                {
                    if (_role == "Admin")
                    {

                        Dashboard dashboard = new Dashboard();
                        dashboard.Show();
                        Close();
                    }
                    //else
                    //{
                    //    frmCashierDashboard c = new frmCashierDashboard();
                    //    c.Show();
                    //    this.Close();
                    //}

                }
                else
                {
                    _ = System.Windows.Forms.MessageBox.Show("Username or Password is incorrect.");
                }
            }catch(Exception ex)
            {
                _ = System.Windows.Forms.MessageBox.Show(ex.ToString());
            }

        }
    }
}
