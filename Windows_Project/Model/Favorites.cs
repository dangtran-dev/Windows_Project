using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Project.Model
{
    /// <summary>
    /// This class is used to store the favorite listings of the users
    /// </summary>
    public class Favorites
    {
        public int FavoriteID { get; set; }
        public int UserID { get; set; }
        public int ListingID { get; set; }
    }
}
