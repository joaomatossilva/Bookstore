using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Core.Authors
{
    public class AuthorWithPublishedBooksCount : Author
    {
        public int PublishedBooksCount { get; set; }
    }
}
