using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class CreateMovieEntity
    {
        // todo: annotation
        public string Title { get; set; }
        public string Director { get; set; }
    }
}
