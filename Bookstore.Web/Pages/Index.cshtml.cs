using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Data;
using Bookstore.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Bookstore.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly BookstoreDbContext _dbContext;

        public IndexModel(ILogger<IndexModel> logger, BookstoreDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            var books = _dbContext.Books.ToList();
        }
    }
}
