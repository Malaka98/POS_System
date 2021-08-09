using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace POS_System.Screens.Admin.Users.DB_Operation
{
    internal class Update : IDisposable
    {
        private readonly DBConnection connectionOBJ = null;
        private SqlCommand cmd = null;
        private readonly int Uid;
        private readonly string Name;
        private readonly string Surname;
        private readonly string UserName;
        private readonly string Password;
        private readonly string UserType;
        private readonly string SEX;
        private readonly string Birth_Date;
        private readonly string Img;
        private readonly DateTime Added_Date;
        private readonly int Added_By;
        private bool disposedValue;

        public Update(User userObj)
        {
            connectionOBJ = DBConnection.GetConnection();
            Uid = userObj.UserID;
            Name = userObj.Name;
            Surname = userObj.Surname;
            UserName = userObj.UserName;
            Password = userObj.Password;
            UserType = userObj.UserType;
            SEX = userObj.SEX;
            Birth_Date = userObj.Birth_Date;
            Img = userObj.Img;
            Added_Date = userObj.Added_Date;
            Added_By = userObj.Added_By;
        }

        public void Update_Query()
        {

            try
            {
                if (MessageBox.Show("Click YES to save the changes", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    connectionOBJ.GetConn().Open();
                    cmd = new SqlCommand("UPDATE Login SET Name=@Name,Surname=@Surname,UserName=@UserName,Password=@Password,UserType=@UserType,SEX=@SEX,Birth_Date=@Birth_Date, Img=@Img,Added_Date=@Added_Date, Added_By=@Added_By Where UserID=@UserID", connectionOBJ.GetConn());

                    _ = cmd.Parameters.AddWithValue("@Name", Name);
                    _ = cmd.Parameters.AddWithValue("@Surname", Surname);
                    _ = cmd.Parameters.AddWithValue("@UserName", UserName);
                    _ = cmd.Parameters.AddWithValue("@Password", Password);
                    _ = cmd.Parameters.AddWithValue("@UserType", UserType);
                    _ = cmd.Parameters.AddWithValue("@SEX", SEX);
                    _ = cmd.Parameters.AddWithValue("@Birth_Date", Birth_Date);
                    _ = cmd.Parameters.AddWithValue("@Img", Img);
                    _ = cmd.Parameters.AddWithValue("@Added_Date", Added_Date);
                    _ = cmd.Parameters.AddWithValue("@Added_By", Added_By);
                    _ = cmd.Parameters.AddWithValue("@UserID", Uid);

                    _ = cmd.ExecuteNonQuery();

                    _ = MessageBox.Show("Employee Added Succesfully");
                }
            }
            catch (SqlException e)
            {
                _ = MessageBox.Show(e.ToString());
            }
            finally
            {
                cmd.Dispose();
                connectionOBJ.GetConn().Close();
            }
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
        // ~Update()
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
