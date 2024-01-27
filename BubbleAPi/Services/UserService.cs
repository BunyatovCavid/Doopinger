using AutoMapper;
using BubbleAPi.Domain;
using BubbleAPi.Domain.Entities;
using BubbleAPi.Dtoes;
using BubbleAPi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BubbleAPi.Services
{
    public class UserService : IUser
    {
        private readonly CourseDbContext _db;

        private readonly ILogger _log;
        public UserService(CourseDbContext db)
        {
            _db = db;
        }


        private async Task<List<User>> PrivateGet()
        {
            var data = await _db.Users.ToListAsync();
            return data;
        }

        public async Task<bool> CreateUSer(UserPostDto dto)
        {
            try
            {
                var data = await PrivateGet();
                if (!data.Contains(new User() { Name = dto.Name, Password = dto.Password }))
                {
                    _db.Users.AddAsync(new() { Name = dto.Name, Password = dto.Password });
                    await _db.SaveChangesAsync();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
                return false;
            }
        }
    }
}
