using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(ApiContentDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Book>> GetBooks()
        {
            return await _dbContext.Books
                .Include(x => x.Authors)
                .ToListAsync();
        }

        public async Task<int> AddBook(Book book)
        {
            if (book.Authors != null && book.Authors.Any())
            {
                foreach (var author in book.Authors)
                {
                    _dbContext.Entry(author).State = EntityState.Unchanged;
                }
            }

            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();

            return book.Id;
        }

        public async Task DeleteBook(int id)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (book != null)
            {
                _dbContext.Books.Remove(book);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
