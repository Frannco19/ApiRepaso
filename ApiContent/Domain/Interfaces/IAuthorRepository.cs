using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        public Task<List<Author>> GetAuthorsByIds(List<int> authorIds);
    }
}
