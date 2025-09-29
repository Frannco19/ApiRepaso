using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ApiContentDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public ApiContentDbContext() { }

        public ApiContentDbContext(DbContextOptions<ApiContentDbContext> options) : base(options)
        {

        }
    }
}
