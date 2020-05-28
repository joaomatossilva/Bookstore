using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bookstore.Core.Authors;
using Bookstore.Data.Model;
using Microsoft.EntityFrameworkCore;
using Author = Bookstore.Data.Model.Author;

namespace Bookstore.Data.Queries.Authors
{
    public static class AllAuthorsWithBookPublished
    {
        public class Mapping : Profile
        {
            public Mapping()
            {
                this.CreateMap<Author, AuthorWithPublishedBooksCount>()
                    .ForMember(dst => dst.PublishedBooksCount,
                        src => src.MapFrom(author => author.BookAuthors.Count(b => b.Book.Published)));
            }
        }

        public class Query : IQueryObject<SearchAuthorInput, IList<AuthorWithPublishedBooksCount>>
        {
            private readonly BookstoreDbContext _dbContext;
            private readonly IMapper _mapper;

            public Query(BookstoreDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<IList<AuthorWithPublishedBooksCount>> ExecuteQuery(SearchAuthorInput input)
            {
                var query = (IQueryable<Author>) _dbContext.Authors;
                if (!string.IsNullOrEmpty(input.Name))
                {
                    query = query.Where(a => a.Name.Contains(input.Name));
                }

                return await query
                    .ProjectTo<AuthorWithPublishedBooksCount>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            }
        }
    }
}
