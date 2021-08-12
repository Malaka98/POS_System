using System;
using System.Data.SqlClient;
using System.Windows;

namespace POS_System.Screens.Admin.Sale.DB_Operations
{
    internal class TransactionDAL
    {
        private readonly DBConnection connectionOBJ = null;
        private SqlCommand cmd = null;

        public TransactionDAL()
        {
            connectionOBJ = DBConnection.GetConnection();
        }

        public bool Insert_Transaction(Transaction t)
        {
            bool isSuccess = false;

            try
            {

                connectionOBJ.GetConn().Open();
                cmd = new SqlCommand("INSERT INTO tblTransaction (type, DealCustID, grandTotal, transaction_date, tax, discount) VALUES (@type, @DealCustID, @grandTotal, @transaction_date, @tax, @discount); SELECT @@IDENTITY;", connectionOBJ.GetConn());

                _ = cmd.Parameters.AddWithValue("@type", t.type);
                _ = cmd.Parameters.AddWithValue("@DealCustID", t.DealCustID);
                _ = cmd.Parameters.AddWithValue("@grandTotal", t.grandTotal);
                _ = cmd.Parameters.AddWithValue("@transaction_date", t.transaction_date);
                _ = cmd.Parameters.AddWithValue("@tax", t.tax);
                _ = cmd.Parameters.AddWithValue("@discount", t.discount);

                _ = cmd.ExecuteNonQuery();
                isSuccess = true;
            }
            catch(Exception ex)
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
