using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Application.Authors
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain.Interfaces;
    using Domain.Model;
    using Infrastructure;
    using MediatR;

    public static class Delete
    {
        public class Query : IRequest<Model>
        {
            public Guid Id { get; set; }
        }

        public class Model
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public bool HasBooks { get; set; }
        }

        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public bool? Confirmed { get; set; }
        }

        public class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Author, Model>();
            }
        }

        public class QueryHandler : IRequestHandler<Query, Model>
        {
            private readonly IAuthorRepository authorRepository;
            private readonly IMapper mapper;

            public QueryHandler(IAuthorRepository authorRepository, IMapper mapper)
            {
                this.authorRepository = authorRepository;
                this.mapper = mapper;
            }

            public async Task<Model> Handle(Query request, CancellationToken cancellationToken)
            {
                var author = await authorRepository.GetById(request.Id) ?? throw new NotFoundException();
                var model = mapper.Map<Model>(author);

                return model;
            }
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
                if (request.Confirmed != true)
                {
                    return Unit.Value;
                }

                var author = await authorRepository.GetById(request.Id);
                if (author == null)
                {
                    return Unit.Value;
                }

                if (author.HasBooks)
                {
                    //TODO: Throw operation not permitted
                    return Unit.Value;
                }

                await authorRepository.Delete(author);
                return Unit.Value;
            }
        }
    }
}
