using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace POS_System.Screens.Admin.Products.DB_Operations
{
    internal class Insert
    {
        private Product prd = null;
        private readonly DBConnection connectionOBJ = null;
        private SqlCommand cmd = null;

        public Insert(Product prd)
        {
            connectionOBJ = DBConnection.GetConnection();
            this.prd = prd;
        }

        public void Insert_Query()
        {

            try
            {
                connectionOBJ.GetConn().Open();
                cmd = new SqlCommand("INSERT INTO Product (PCode, Barcode, Manufactor, Model,Full_Name,Price,Category,Description,Year,Warranty,Quantity,Dealer, Img,added_time,added_by,Reorder) VALUES (@PCode, @Barcode, @Manufactor,@Model,@Full_Name,@Price,@Category,@Description,@Year,@Warranty,@Quantity,@Dealer,@Img,@added_time,@added_by,@Reorder)", connectionOBJ.GetConn());

                _ = cmd.Parameters.AddWithValue("@PCode", prd.PCode);
                _ = cmd.Parameters.AddWithValue("@Barcode", prd.Barcode);
                _ = cmd.Parameters.AddWithValue("@Manufactor", prd.Manufactor);
                _ = cmd.Parameters.AddWithValue("@Model", prd.Model);
                _ = cmd.Parameters.AddWithValue("@Full_Name", prd.Full_Name);
                _ = cmd.Parameters.AddWithValue("@Price", prd.Price);
                _ = cmd.Parameters.AddWithValue("@Category", prd.Category);
                _ = cmd.Parameters.AddWithValue("@Description", prd.Description);
                _ = cmd.Parameters.AddWithValue("@Year", prd.Year);
                _ = cmd.Parameters.AddWithValue("@Warranty", prd.Warranty);
                _ = cmd.Parameters.AddWithValue("@Quantity", prd.Quantity);
                _ = cmd.Parameters.AddWithValue("@Dealer", prd.Dealer);
                _ = cmd.Parameters.AddWithValue("@Img", prd.Img);
                _ = cmd.Parameters.AddWithValue("@added_time", prd.Added_time);
                _ = cmd.Parameters.AddWithValue("@added_by", prd.Added_by);
                _ = cmd.Parameters.AddWithValue("@Reorder", prd.Reorder);

                _ = cmd.ExecuteNonQuery();

                _ = MessageBox.Show("Employee Added Succesfully");
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
    }
}
