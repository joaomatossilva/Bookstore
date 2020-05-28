using System;
using Bookstore.Domain.Model;

namespace Bookstore.Domain.Interfaces
{
    public interface IBookRepository
    {
        Book GetById(Guid id);
        void Save(Book entity);
    }
}