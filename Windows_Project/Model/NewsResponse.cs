using NewsAPI.Constants;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Project.Model
{
    public class NewsResponse
    {
        public Statuses Status { get; set; }
        public int TotalResults { get; set; }
        public List<NewsArticle> Articles { get; set; }
    }
}
