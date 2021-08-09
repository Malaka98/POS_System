using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Screens.Admin.Categories
{
    internal class Category
    {
        public int CatID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Added_date { get; set; }
        public int Added_by { get; set; }
    }
}
