namespace POS_System.Screens.Admin
{
    internal class Employer
    {
        public string name;
        public int idnum;
        public string address;
        public int mobile;
        public string surname;
        public string dob;
        public string rdate;
        public string sex;
        public int sallary;
        public int age;

        public Employer(string name, int idnum, string address, int mobile, string surname, string dob, string rdate, string sex, int sallary, int age)
        {
            this.name = name;
            this.idnum = idnum;
            this.address = address;
            this.mobile = mobile;
            this.surname = surname;
            this.dob = dob;
            this.rdate = rdate;
            this.sex = sex;
            this.sallary = sallary;
            this.age = age;
    }
    }
}
