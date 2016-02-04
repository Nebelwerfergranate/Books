using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Books.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        
        public virtual Genre Genre { get; set; }

        [Display(Name = "Кол-во страниц")]
        public int Pages { get; set; }
    }
}