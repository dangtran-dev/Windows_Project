using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Project.Model
{
    public class Listings
    {
        public int UserID { get; set; }
        public int CarID { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string CreateAt { get; set; }
    }
}
