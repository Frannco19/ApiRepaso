using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        public Task<List<Book>> GetBooks();

        public Task<int> AddBook(Book book);

        public Task DeleteBook(int id);
    }
}
