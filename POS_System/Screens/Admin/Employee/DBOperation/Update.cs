﻿using System;
using System.Data.SqlClient;
using System.Windows;

namespace POS_System.Screens.Admin
{
    internal class Update : IDisposable
    {
        private readonly DBConnection connectionOBJ = null;
        private SqlCommand cmd = null;
        private bool disposedValue;
        private readonly string name;
        private readonly int idnum;
        private readonly string address;
        private readonly int mobile;
        private readonly string surname;
        private readonly string dob;
        private readonly string rdate;
        private readonly string sex;
        private readonly int sallary;
        private readonly int age;

        public Update(Employer updateEmp)
        {
            connectionOBJ = DBConnection.GetConnection();
            name = updateEmp.name;
            idnum = updateEmp.idnum;
            address = updateEmp.address;
            mobile = updateEmp.mobile;
            surname = updateEmp.surname;
            dob = updateEmp.dob;
            rdate = updateEmp.rdate;
            sex = updateEmp.sex;
            sallary = updateEmp.sallary;
            age = updateEmp.age;
        }

        public void Update_Query(int empId)
        {
            try
            {
                connectionOBJ.GetConn().Open();
                cmd = new SqlCommand("Update Employee Set Name=@Name,Surname=@Surname,ID=@ID,SEX=@SEX,Birth_Date=@Birth_Date,Age=@Age,Address=@Address,Mobile=@Mobile,DateOfReciving=@DateOfReciving,Sallary=@Sallary,added_date=@added_date Where EmpID=@EmpID", connectionOBJ.GetConn());

                _ = cmd.Parameters.AddWithValue("@EmpID", empId);
                _ = cmd.Parameters.AddWithValue("@Name", name);
                _ = cmd.Parameters.AddWithValue("@Surname", surname);
                _ = cmd.Parameters.AddWithValue("@ID", idnum);
                _ = cmd.Parameters.AddWithValue("@SEX", sex);
                _ = cmd.Parameters.AddWithValue("@Birth_Date", dob);
                _ = cmd.Parameters.AddWithValue("@Age", age);
                _ = cmd.Parameters.AddWithValue("@Address", address);
                _ = cmd.Parameters.AddWithValue("@Mobile", mobile);
                _ = cmd.Parameters.AddWithValue("@DateOfReciving", rdate);
                _ = cmd.Parameters.AddWithValue("@Sallary", sallary);
                _ = cmd.Parameters.AddWithValue("@added_date", DateTime.Now);

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
