using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Project
{
    /// <summary>
    /// This class is used to store the car details along with the user details
    /// </summary>
    public class CarWithUserItem
    {
        public Cars car { get; set; }
        public Users user { get; set; }
        public Model.Listings listing { get; set; }
    }
}
