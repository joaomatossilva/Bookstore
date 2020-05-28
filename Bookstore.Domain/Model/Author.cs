using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Domain.Model
{
    public class Author
    {
        public Guid Id { get; }
        public string Name { get; }

        public Author(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
