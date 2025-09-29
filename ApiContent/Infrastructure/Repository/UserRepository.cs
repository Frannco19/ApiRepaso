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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        
        public UserRepository(ApiContentDbContext dbContext) : base(dbContext)
        {
           
        }

        public async Task<User?> GetUser(string email, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return user;
            }
            return null;
        }

        public async Task<User> CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
