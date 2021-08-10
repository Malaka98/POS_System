using System;

namespace POS_System.Screens.Admin.Dealers
{
    internal class Dealer
    {
        public int DealID { get; set; }
        public string Name { get; set; }
        public string Person { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public DateTime Added_date { get; set; }
        public int Added_by { get; set; }
    }
}
