using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Core.Authors;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Index = Bookstore.Application.Authors.Index;

namespace Bookstore.Web.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        public IList<AuthorWithPublishedBooksCount> Authors { get; set; }

        public async Task OnGetAsync()
        {
            Authors = (await _mediator.Send(new Index.Input{ Name = Name })).ToList();
        }
    }
}
