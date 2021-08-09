using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Screens.Admin.Products
{
    internal class Product
    {
        public int ProdID { get; set; }
        public string PCode { get; set; }
        public string Barcode { get; set; }
        public string Manufactor { get; set; }
        public string Model { get; set; }
        public string Full_Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Year { get; set; }
        public int Warranty { get; set; }
        public int Quantity { get; set; }
        public string Dealer { get; set; }
        public string Img { get; set; }
        public DateTime Added_time { get; set; }
        public int Added_by { get; set; }
        public int Reorder { get; set; }
    }
}
