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
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApiContentDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Author>> GetAuthorsByIds(List<int> authorIds)
        {
            return await _dbContext.Authors.Where(a => authorIds.Contains(a.Id)).ToListAsync();
        }
    }
}
