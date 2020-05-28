using System;

namespace Bookstore.Data.Model
{
    public class BookAuthor
    {
        public Guid BookId { get; set; }
        public virtual Book Book { get; set; }

        public Guid AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}