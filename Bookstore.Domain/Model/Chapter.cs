using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Domain.Model
{
    public class Chapter
    {
        public Guid Id { get; }
        public string Name { get; }

        public Chapter(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
