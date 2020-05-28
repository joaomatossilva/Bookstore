using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Data.Model
{
    public class Book
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Edition { get; set; }

        [Required]
        public bool Published { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; }

        public virtual ICollection<Chapter> Chapters { get; set; }

        public Book()
        {
            BookAuthors = new HashSet<BookAuthor>();
            Chapters = new HashSet<Chapter>();
        }
    }
}