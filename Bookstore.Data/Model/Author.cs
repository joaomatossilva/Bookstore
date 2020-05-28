using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Data.Model
{
    public class Author
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}