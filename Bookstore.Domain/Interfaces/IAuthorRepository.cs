using Bookstore.Domain.Model;
using System;

namespace Bookstore.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        Author GetById(Guid id);
        void Save(Author entity);
    }
}