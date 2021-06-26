using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace POS_System.Screens.Admin
{
    internal static class EmpValidation
    {
        private static readonly Regex regex = new Regex(@"^\d+$");

        public static bool IsValidate(string name, string idnum, string address, string mobile, string surname, string dob, string rdate, string sex, string sallary, string age)
        {
            bool error = false;

            if (name.Trim() == "")
            {
                error = true;
                _ = MessageBox.Show("Please enter First Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (idnum.Trim() == "")
            {
                error = true;
                _ = MessageBox.Show("Please enter Index Number", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!regex.IsMatch(idnum))
            {
                error = true;
                _ = MessageBox.Show("Index NUmber is non-numeric", "Type error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (address.Trim() == "")
            {
                error = true;
                _ = MessageBox.Show("Please enter Last Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (mobile.Trim() == "")
            {
                error = true;
                _ = MessageBox.Show("Please enter Index Number", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!regex.IsMatch(mobile))
            {
                error = true;
                _ = MessageBox.Show("Index NUmber is non-numeric", "Type error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (surname.Trim() == "")
            {
                error = true;
                _ = MessageBox.Show("Please enter Email Name", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (dob.Trim() == "")
            {
                error = true;
                _ = MessageBox.Show("Please enter Address Line 01", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (rdate.Trim() == "")
            {
                error = true;
                _ = MessageBox.Show("Please enter Address Line 02", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (sex == "-1")
            {
                error = true;
                _ = MessageBox.Show("Please enter City", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (sallary.Trim() == "")
            {
                error = true;
                _ = MessageBox.Show("Please enter City", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (age.Trim() == "")
            {
                error = true;
                _ = MessageBox.Show("Please enter City", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return error;
        }
    }
}
