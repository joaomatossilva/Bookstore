using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bookstore.Data.Model;

namespace Bookstore.Web.Pages.Authors
{
    public class CreateModel : PageModel
    {
        private readonly Bookstore.Data.Model.BookstoreDbContext _context;

        public CreateModel(Bookstore.Data.Model.BookstoreDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Author Author { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Authors.Add(Author);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
