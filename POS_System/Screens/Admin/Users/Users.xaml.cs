using POS_System.Screens.Admin.Users.DB_Operation;
using System;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Report = POS_System.Screens.Admin.Users.Report;

namespace POS_System.Screens.Admin.Users
{
    /// <summary>
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class Users : UserControl, IDisposable
    {
        private string imgLoc = "user.png";
        private string sourcePath = null;
        private string destinationPath = null;
        private int UID;
        private bool disposedValue;
        

        public Users()
        {
            InitializeComponent();
            DisplayData();
        }

        private void DisplayData()
        {
            Display dis = new Display();
            DataTable dt = dis.Display_query();
            grid_User.ItemsSource = dt.DefaultView;
            dis.Dispose();
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
        // ~Users()
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

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            User newUser = null;
            try
            {
                newUser = new User
                {
                    Name = txtFirstName.Text,
                    Surname = txtLastName.Text,
                    UserName = txtUsername.Text,
                    Password = txtPassword.Password.ToString(),
                    UserType = cmbUserType.Text,
                    SEX = cmbSex.Text,
                    Birth_Date = dtpBirth.Text,
                    Img = imgLoc,
                    Added_Date = DateTime.Now
                };

                using (Insert insertObj = new Insert(newUser))
                {
                    insertObj.Insert_Query();
                    File.Copy(sourcePath, destinationPath);
                }
                DisplayData();
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.ToString());
            }
            finally
            {
                newUser.Dispose();
            }

        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.OpenFileDialog open = new System.Windows.Forms.OpenFileDialog
            {
                Filter = "Image Files (*.jpg; *.jpeg; *.png; *.PNG; *gifs;)|*.jpg; *.jpeg; *.png; *.PNG; *gifs"
            };

            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (open.CheckFileExists)
                {
                    imgBox.ImageSource = new BitmapImage(new Uri(open.FileName));

                    string ext = System.IO.Path.GetExtension(open.FileName);

                    Random random = new Random();
                    int RandInt = random.Next(0, 1000);

                    imgLoc = "POS_USER" + RandInt + ext;

                    sourcePath = open.FileName;

                    string paths = System.Windows.Forms.Application.StartupPath.Substring(0, System.Windows.Forms.Application.StartupPath.Length - 10);

                    destinationPath = paths + "\\Images\\" + imgLoc;
                }
            }
        }

        private void Grid_User_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid gd = (DataGrid)sender;
                DataRowView row_selected = gd.SelectedItem as DataRowView;
                if (row_selected != null)
                {
                    UID = int.Parse(row_selected[0].ToString());
                    txtFirstName.Text = row_selected[1].ToString();
                    txtLastName.Text = row_selected[2].ToString();
                    txtUsername.Text = row_selected[3].ToString();

                    cmbUserType.Text = row_selected[5].ToString();
                    cmbSex.Text = row_selected[6].ToString();
                    dtpBirth.Text = row_selected[7].ToString();
                    imgLoc = row_selected[8].ToString();

                    //Update the Value of Global Variable rowheaderImage
                    //rowHeaderImage = imgLoc;

                    string paths = System.Windows.Forms.Application.StartupPath.Substring(0, System.Windows.Forms.Application.StartupPath.Length - 10);
                    if (imgLoc != "user.png")
                    {
                        string imagePath = paths + "\\Images\\" + imgLoc;
                        imgBox.ImageSource = new BitmapImage(new Uri(imagePath));

                    }
                    else
                    {
                        string imagePath = paths + "\\Images\\user.png";
                        imgBox.ImageSource = new BitmapImage(new Uri(imagePath));
                    }
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            User updateUser = null;
            try
            {
                updateUser = new User
                {
                    UserID = UID,
                    Name = txtFirstName.Text,
                    Surname = txtLastName.Text,
                    UserName = txtUsername.Text,
                    Password = txtPassword.Password.ToString(),
                    UserType = cmbUserType.Text,
                    SEX = cmbSex.Text,
                    Birth_Date = dtpBirth.Text,
                    Img = imgLoc,
                    Added_Date = DateTime.Now
                };

                using (Update updateObj = new Update(updateUser))
                {
                    updateObj.Update_Query();
                    if (sourcePath != null)
                    {
                        File.Copy(sourcePath, destinationPath);
                    }
                }
                DisplayData();
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.ToString());
            }
            finally
            {
                updateUser.Dispose();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            User delUser = null;
            try
            {
                delUser = new User
                {
                    UserID = UID
                };

                using (Delete updateObj = new Delete(delUser))
                {
                    updateObj.Delete_Query();
                }
                DisplayData();
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.ToString());
            }
            finally
            {
                delUser.Dispose();
            }
        }

        private void Report_Button_Click(object sender, RoutedEventArgs e)
        {
            Report::User_Report rObj = new Report.User_Report();
            rObj.Show();
        }
    }
}
