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
    using Application.Authors;
    using MediatR;

    public class DeleteModel : PageModel
    {
        private readonly IMediator mediator;

        public DeleteModel(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [BindProperty]
        public Delete.Command Command { get; set; }
        public Delete.Model Model { get; set; }

        public async Task<IActionResult> OnGetAsync(Delete.Query query)
        {
            Model = await mediator.Send(query);
            Command = new Delete.Command {Id = Model.Id};
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await mediator.Send(Command);
            return RedirectToPage("./Index");
        }
    }
}
