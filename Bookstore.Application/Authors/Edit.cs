using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Bookstore.Application.Infrastructure;
using Bookstore.Core.Authors;
using Bookstore.Domain.Interfaces;
using MediatR;

namespace Bookstore.Application.Authors
{
    public static class Edit
    {
        public class Query : IRequest<Command>
        {
            public Guid Id { get; set; }
        }

        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }

        public class Mappings : Profile
        {
            public Mappings()
            {
                CreateMap<Domain.Model.Author, Command>();
            }
        }

        public class QueryHandler : IRequestHandler<Query, Command>
        {
            private readonly IAuthorRepository _authorRepository;
            private readonly IMapper _mapper;

            public QueryHandler(IAuthorRepository authorRepository, IMapper mapper)
            {
                _authorRepository = authorRepository;
                _mapper = mapper;
            }

            public async Task<Command> Handle(Query request, CancellationToken cancellationToken)
            {
                var author = await _authorRepository.GetById(request.Id) ?? throw new NotFoundException();
                return _mapper.Map<Command>(author);
            }
        }

        public class CommandHandler : IRequestHandler<Command>
        {
            private readonly IAuthorRepository _authorRepository;

            public CommandHandler(IAuthorRepository authorRepository)
            {
                _authorRepository = authorRepository;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var author = await _authorRepository.GetById(request.Id) ?? throw new NotFoundException();
                author.ChangeName(request.Name);
                await _authorRepository.Save(author);

                return Unit.Value;
            }
        }
    }
}
