using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace POS_System.Screens.Admin.Sale.DB_Operations
{
    internal class ProductDAL
    {
        private readonly DBConnection connectionOBJ = null;
        

        public ProductDAL()
        {
            connectionOBJ = DBConnection.GetConnection();
        }

        public bool IncreaseProduct(int ProductID, decimal IncreaseQty)
        {
            bool success = false;

            try
            {
                decimal currentQty = GetProductQty(ProductID);
                decimal NewQty = currentQty + IncreaseQty;
                success = UpdateQuantity(ProductID, NewQty);
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
            }

            return success;
        }

        public bool DecraseProduct(int ProductID, decimal Qty)
        {
            bool success = false;

            try
            {
                decimal currentQty = GetProductQty(ProductID);

                decimal NewQty = currentQty - Qty;

                success = UpdateQuantity(ProductID, NewQty);


            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
            }

            return success;
        }

        private decimal GetProductQty(int ProductID)
        {
            decimal Quantity = 0;
            DataTable dt = new DataTable();
            SqlDataAdapter adapt;
            SqlCommand cmd;

            try
            {

                connectionOBJ.GetConn().Open();
                cmd = new SqlCommand("SELECT Quantity FROM Product WHERE ProdID = " + ProductID, connectionOBJ.GetConn());

                adapt = new SqlDataAdapter(cmd);
                _ = adapt.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Quantity = decimal.Parse(dt.Rows[0]["Quantity"].ToString());
                }
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
            }
            finally
            {
                connectionOBJ.GetConn().Close();
            }

            return Quantity;
        }

        private bool UpdateQuantity(int ProductID, decimal Qty)
        {
            bool success = false;
            SqlCommand cmd;

            try
            {
                connectionOBJ.GetConn().Open();
                cmd = new SqlCommand("UPDATE Product SET Quantity=@Quantity WHERE ProdID=@ProdID", connectionOBJ.GetConn());

                _ = cmd.Parameters.AddWithValue("@Quantity", Qty);
                _ = cmd.Parameters.AddWithValue("@ProdID", ProductID);

                _ = cmd.ExecuteNonQuery();
                success = true;

            }
            catch(Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
                success = false;
            }
            finally
            {
                connectionOBJ.GetConn().Close();
            }

            return success;
        }
    }
}
