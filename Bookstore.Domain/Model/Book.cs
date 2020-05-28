using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Domain.Model
{
    public class Book
    {
        public Guid Id { get; }
        public string Title { get; }
        public HashSet<Author> Authors { get; }
        public HashSet<Chapter> Chapters { get; }

        public Book(Guid id, string title, HashSet<Author> authors, HashSet<Chapter> chapters)
        {
            Id = id;
            Title = title;
            Authors = authors;
            Chapters = chapters;
        }
    }
}
