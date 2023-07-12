using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyWithData.Models;

namespace VidlyWithData.ViewModel
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}