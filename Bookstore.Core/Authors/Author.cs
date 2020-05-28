using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Bookstore.Core.Authors
{
    public class Author
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
