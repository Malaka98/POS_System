using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System.Screens.Admin.Products.DB_Operations
{
    internal class Update
    {
        private Product prd = null;
        private readonly DBConnection connectionOBJ = null;
        private SqlCommand cmd = null;

        public Update(Product prd)
        {
            connectionOBJ = DBConnection.GetConnection();
            this.prd = prd;
        }

        public void Update_Query()
        {

            try
            {
                if (MessageBox.Show("Click YES to save the changes", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    connectionOBJ.GetConn().Open();
                    cmd = new SqlCommand("UPDATE Product SET PCode=@PCode, Barcode=@Barcode, Manufactor=@Manufactor,Model=@Model,Full_Name=@Full_Name,Price=@Price,Category=@Category,Description=@Description,Year=@Year,Warranty=@Warranty,Dealer=@Dealer,Img = @Img,added_time=@added_time,added_by=@added_by,Reorder=@Reorder  WHERE ProdID=@ProdID", connectionOBJ.GetConn());

                    cmd.Parameters.AddWithValue("@PCode", prd.PCode);
                    cmd.Parameters.AddWithValue("@Barcode", prd.Barcode);
                    cmd.Parameters.AddWithValue("@Manufactor", prd.Manufactor);
                    cmd.Parameters.AddWithValue("@Model", prd.Model);
                    cmd.Parameters.AddWithValue("@Full_Name", prd.Full_Name);
                    cmd.Parameters.AddWithValue("@Price", prd.Price);
                    cmd.Parameters.AddWithValue("@Category", prd.Category);
                    cmd.Parameters.AddWithValue("@Description", prd.Description);
                    cmd.Parameters.AddWithValue("@Year", prd.Year);
                    cmd.Parameters.AddWithValue("@Warranty", prd.Warranty);
                    cmd.Parameters.AddWithValue("@Quantity", prd.Quantity);
                    cmd.Parameters.AddWithValue("@Dealer", prd.Dealer);
                    cmd.Parameters.AddWithValue("@ProdID", prd.ProdID);
                    cmd.Parameters.AddWithValue("@Img", prd.Img);
                    cmd.Parameters.AddWithValue("@added_time", prd.Added_time);
                    cmd.Parameters.AddWithValue("@added_by", prd.Added_by);
                    cmd.Parameters.AddWithValue("@Reorder", prd.Reorder);

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
    }
}
