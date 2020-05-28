using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bookstore.Data.Model;

namespace Bookstore.Web.Pages.Authors
{
    public class DetailsModel : PageModel
    {
        private readonly Bookstore.Data.Model.BookstoreDbContext _context;

        public DetailsModel(Bookstore.Data.Model.BookstoreDbContext context)
        {
            _context = context;
        }

        public Author Author { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Author = await _context.Authors.FirstOrDefaultAsync(m => m.Id == id);

            if (Author == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
