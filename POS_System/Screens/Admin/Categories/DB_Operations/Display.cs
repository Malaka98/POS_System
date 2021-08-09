﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System.Screens.Admin.Categories.DB_Operations
{
    internal class Display : IDisposable
    {
        private readonly DBConnection connectionOBJ = null;
        private SqlDataAdapter adapt = null;
        private bool disposedValue;

        public Display()
        {
            connectionOBJ = DBConnection.GetConnection();
        }

        public DataTable Display_query()
        {
            try
            {
                connectionOBJ.GetConn().Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("SELECT CatID, title [Title], description [Description], added_date [Added Time], added_by [Added By]  FROM Category", connectionOBJ.GetConn());
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
                adapt.Dispose();
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
        // ~Display()
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
