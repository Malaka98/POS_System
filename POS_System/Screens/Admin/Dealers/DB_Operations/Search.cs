﻿using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace POS_System.Screens.Admin.Dealers.DB_Operations
{
    internal class Search
    {
        private readonly DBConnection connectionOBJ = null;
        private SqlCommand cmd = null;
        private SqlDataAdapter adapt = null;
        private string keyword = null;

        public Search()
        {
            connectionOBJ = DBConnection.GetConnection();
            
        }

        public DataTable Search_Query(string keyword)
        {
            this.keyword = keyword;

            DataTable dt = new DataTable();
            try
            {
                connectionOBJ.GetConn().Open();
                cmd = new SqlCommand("SELECT * FROM Dealers WHERE DealID LIKE '%" + keyword + "%' OR name LIKE '%" + keyword + "%' OR person LIKE '%" + keyword + "%' ", connectionOBJ.GetConn());

                adapt = new SqlDataAdapter(cmd);
                _ = adapt.Fill(dt);
                return dt;
            }
            catch (SqlException e)
            {
                _ = MessageBox.Show(e.ToString());
                return null;
            }
            finally
            {
                cmd.Dispose();
                adapt.Dispose();
                connectionOBJ.GetConn().Close();
            }

        }

        public int GetDealCustIDFromName(string Name)
        {
            DataTable dt = new DataTable();

            try
            {
                connectionOBJ.GetConn().Open();
                cmd = new SqlCommand("SELECT DealCustID FROM DealCust WHERE name='" + Name + "'", connectionOBJ.GetConn());

                adapt = new SqlDataAdapter(cmd);
                _ = adapt.Fill(dt);

                return dt.Rows.Count > 0 ? int.Parse(dt.Rows[0]["DealCustID"].ToString()) : -1;
            }
            catch (SqlException e)
            {
                _ = MessageBox.Show(e.ToString());
                return -1;
            }
            finally
            {
                cmd.Dispose();
                adapt.Dispose();
                connectionOBJ.GetConn().Close();
            }
        }

    }
}
