using System.Data;
using System.Data.SqlClient;
using System.Windows;
using POS_System.Screens.Admin.Dealers;

namespace POS_System.Screens.Admin.Purchase.DB_Operations
{
    internal class Purchase_D_Search
    {
        private readonly DBConnection connectionOBJ = null;
        private SqlDataAdapter adapt = null;
        private readonly string keyword;

        public Purchase_D_Search(string keyword)
        {
            connectionOBJ = DBConnection.GetConnection();
            this.keyword = keyword;
        }

        public Dealer Search_query()
        {
            Dealer cus = new Dealer();
            try
            {
                connectionOBJ.GetConn().Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("SELECT name [Name], person [Person], email [Email], contact [Contact], address [Address] from Dealers WHERE DealID LIKE '%" + keyword + "%' OR name LIKE '%" + keyword + "%' OR person LIKE '%" + keyword + "%'", connectionOBJ.GetConn());
                _ = adapt.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    cus.Name = dt.Rows[0]["name"].ToString();
                    cus.Person = dt.Rows[0]["person"].ToString();
                    cus.Email = dt.Rows[0]["email"].ToString();
                    cus.Contact = dt.Rows[0]["contact"].ToString();
                    cus.Address = dt.Rows[0]["address"].ToString();
                }
                return cus;
            }
            catch (SqlException e)
            {
                _ = MessageBox.Show(e.ToString());
                return null;
            }
            finally
            {
                adapt.Dispose();
                connectionOBJ.GetConn().Close();
            }
        }

    }
}
