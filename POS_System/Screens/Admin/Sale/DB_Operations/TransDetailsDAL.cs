using System;
using System.Data.SqlClient;
using System.Windows;

namespace POS_System.Screens.Admin.Sale.DB_Operations
{
    internal class TransDetailsDAL
    {
        private readonly DBConnection connectionOBJ = null;
        private SqlCommand cmd = null;

        public TransDetailsDAL()
        {
            connectionOBJ = DBConnection.GetConnection();
        }

        public bool InsertTransDetails(TransDetails td)
        {
            bool isSuccess = false;

            try
            {

                connectionOBJ.GetConn().Open();
                cmd = new SqlCommand("INSERT INTO TransDetails (ProdID, transno, price, qty, total_price, type, DealCustID, added_date) VALUES (@ProdID, @transno, @price, @qty, @total_price, @type, @DealCustID, @added_date)", connectionOBJ.GetConn());

                _ = cmd.Parameters.AddWithValue("@ProdID", td.ProdID);
                _ = cmd.Parameters.AddWithValue("@transno", 111111111111);
                _ = cmd.Parameters.AddWithValue("@price", td.price);
                _ = cmd.Parameters.AddWithValue("@qty", td.qty);
                _ = cmd.Parameters.AddWithValue("@total_price", td.total_price);
                _ = cmd.Parameters.AddWithValue("@type", td.type);
                _ = cmd.Parameters.AddWithValue("@DealCustID", td.DealCustID);
                _ = cmd.Parameters.AddWithValue("@added_date", td.added_date);

                _ = cmd.ExecuteNonQuery();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
                isSuccess = false;

            }
            finally
            {
                cmd.Dispose();
                connectionOBJ.GetConn().Close();
            }
            return isSuccess;
        }
    }
    
}
