using AnoraksAlmanacModel;
using System.Collections.Generic;

namespace AnoraksAlmanacSite.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Movie> Watching
        {
            get;
            set;
        }
    }
}