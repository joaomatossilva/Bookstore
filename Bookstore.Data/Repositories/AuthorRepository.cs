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
                .FirstOrDefaultAsync(x => x.Id == id);

            return author == null ? null : new Author(author.Id, author.Name);
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
