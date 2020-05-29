using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Data.Model;
using Bookstore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Author = Bookstore.Domain.Model.Author;

namespace Bookstore.Data.Repositories
{
    using System.Linq;

    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookstoreDbContext _dbContext;

        public AuthorRepository(BookstoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Author> GetById(Guid id)
        {
            var author = await _dbContext.Authors
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new { Entity = x, HasBooks = x.BookAuthors.Count > 0 })
                .FirstOrDefaultAsync();

            return author == null ? null : new Author(author.Entity.Id, author.Entity.Name, author.HasBooks);
        }

        public async Task Save(Author entity)
        {
            //it is possible to avoid this roundtrip by creating the Author with properties and attaching
            var author = await _dbContext.Authors
                .FirstOrDefaultAsync(x => x.Id == entity.Id);

            //upsert the author
            if (author == null)
            {
                author = new Model.Author
                {
                    Id = entity.Id
                };
                _dbContext.Authors.Add(author);
            }

            author.Name = entity.Name;

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Author entity)
        {
            //it is possible to avoid this roundtrip by creating the Author with properties and attaching
            var author = await _dbContext.Authors
                .FirstOrDefaultAsync(x => x.Id == entity.Id);

            _dbContext.Authors.Remove(author);
            await _dbContext.SaveChangesAsync();
        }
    }
}
