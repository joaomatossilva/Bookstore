using Bookstore.Domain.Model;
using System;
using System.Threading.Tasks;

namespace Bookstore.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        Task<Author> GetById(Guid id);
        Task Save(Author entity);
    }
}