using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Domain.Model
{
    public class Author
    {
        public Guid Id { get; }
        public string Name { get; private set; }

        public Author(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public void ChangeName(string name)
        {
            this.Name = name;
        }
    }
}
