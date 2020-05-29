using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Domain.Model
{
    public class Author
    {
        public Guid Id { get; }
        public string Name { get; private set; }
        public bool HasBooks { get; }

        public Author(Guid id, string name, bool hasBooks = false)
        {
            Id = id;
            Name = name;
            HasBooks = hasBooks;
        }

        public void ChangeName(string name)
        {
            this.Name = name;
        }
    }
}
