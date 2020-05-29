using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Application.Authors
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Interfaces;
    using Domain.Model;
    using MediatR;

    public static class Create
    {
        public class Command : IRequest
        {
            public string Name { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command>
        {
            private readonly IAuthorRepository authorRepository;

            public CommandHandler(IAuthorRepository authorRepository)
            {
                this.authorRepository = authorRepository;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var author = new Author(Guid.NewGuid(), request.Name);
                await authorRepository.Save(author);
                return Unit.Value;
            }
        }
    }
}
