using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Books.Models.Entities
{
    public class Genre
    {
        public Genre() { }

        public Genre(string genre)
        {
            Name = genre;
        }
        public int Id { get; set; }

        [Display(Name = "Жанр")]
        public string Name { get; set; }
    }
}