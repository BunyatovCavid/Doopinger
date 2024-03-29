﻿using AutoMapper;
using BubbleAPi.Domain;
using BubbleAPi.Domain.Entities;
using BubbleAPi.Dtoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BubbleAPi.Services
{
    public class JWTService
    {
        private readonly IMapper _mapper;
        private readonly CourseDbContext _db;
        private readonly IConfiguration _iconfiguration;
        public JWTService(IMapper mapper, CourseDbContext db, IConfiguration iconfiguration)
        {
            _mapper = mapper;
            _db = db;
            _iconfiguration = iconfiguration;
        }

        private async Task<string[]> GetUserAsync(LoginDto dto)
        {
            var data = await _db.User_Role_Crosses.Include(c => c.User).Include(c => c.Role).Where(a => a.User.Name == dto.Name && a.User.Password == dto.Password).ToListAsync();
            string[] users = new string[data.Count + 1];
            int i = 0;
            foreach (var item in data)
            {
                if (i == 0)
                {
                    users[i] = item.User.Name;
                    i++;
                    users[i] = item.Role.Name;
                    i++;
                    continue;
                }
                if (i <= data.Count)
                {
                    users[i] = item.Role.Name;
                }
                else
                {
                    break;
                }
                i++;
            }
            return users;
        }
        public async Task<string> LogIn(LoginDto dto)
        {
            var user = await GetUserAsync(dto);
            if (user != null)
            {
                var tokenhandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(_iconfiguration["JWT:Key"]);
                List<Claim> data = new List<Claim>();
                for (int i = 0; i < user.Length; i++)
                {
                    if (i == 0)
                    {
                        data.Add(new Claim(ClaimTypes.Name, user[i]));
                    }
                    else
                    {
                        data.Add(new Claim(ClaimTypes.Role, user[i]));
                    }
                }

                Claim[] b_data = new Claim[data.Count];
                int j = 0;
                foreach (var item in data)
                {
                    b_data[j] = item;
                    j++;
                }

                var tokenDecriptor = new SecurityTokenDescriptor
                {

                    Subject = new ClaimsIdentity(b_data),
                    Expires = DateTime.UtcNow.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)

                };

                var token = tokenhandler.CreateToken(tokenDecriptor);
                return tokenhandler.WriteToken(token);
            }
            else return "User not registered.";
        }
    }
}
