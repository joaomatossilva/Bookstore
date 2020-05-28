using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Bookstore.Core.Authors;
using Bookstore.Data.Queries;
using MediatR;
using Microsoft.Extensions.Logging;
using SearchAuthorInput = Bookstore.Core.Authors.SearchAuthorInput;

namespace Bookstore.Application.Authors
{
    public static class Index
    {
        public class Input : IRequest<IList<AuthorWithPublishedBooksCount>>
        {
            public string Name { get; set; }
        }

        public class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Input, SearchAuthorInput>();
            }
        }

        public class Handler : IRequestHandler<Input, IList<AuthorWithPublishedBooksCount>>
        {
            private readonly IQueryObject<SearchAuthorInput, IList<AuthorWithPublishedBooksCount>> _queryObject;
            private readonly IMapper _mapper;
            private readonly ILogger<Handler> _logger;

            public Handler(IQueryObject<SearchAuthorInput, IList<AuthorWithPublishedBooksCount>> queryObject, IMapper mapper, ILogger<Handler> logger)
            {
                _queryObject = queryObject;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<IList<AuthorWithPublishedBooksCount>> Handle(Input request, CancellationToken cancellationToken)
            {
                return await _queryObject.ExecuteQuery(_mapper.Map<SearchAuthorInput>(request));
            }
        }
    }
}
