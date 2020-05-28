using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Bookstore.Core.Authors;
using Bookstore.Data.Model;
using Bookstore.Data.Queries;
using Bookstore.Data.Queries.Authors;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Data
{
    public static class ConfigureExtensions
    {
        public static IServiceCollection AddDataDependencies(this IServiceCollection services)
        {
            services.AddDbContext<BookstoreDbContext>();

            //TODO: Move this to some auto discover types
            services.AddScoped<IQueryObject<SearchAuthorInput, IList<AuthorWithPublishedBooksCount>>, AllAuthorsWithBookPublished.Query>();

            return services;
        }
    }
}
