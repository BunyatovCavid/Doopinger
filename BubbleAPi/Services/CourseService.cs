using AutoMapper;
using BubbleAPi;
using BubbleAPi.Domain;
using BubbleAPi.Domain.Entities;
using BubbleAPi.Dtoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;

namespace Doopinger
{
    public class CourseService : ICourse
    {
        private readonly CourseDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger _log;
        public CourseService(CourseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        private async Task<List<Course>> PrivateGet()
        {
            try
            {
                var data = await _db.Courses.Where(c => c.State != "IsDeleted").ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex, ex.Message);
                return null;
            }

        }
        public async Task<bool> DeleteAsync(string Name)
        {
            try
            {
                var data = await PrivateGetByName(Name);
                if (data != null)
                {
                    _db.Courses.Remove(data);
                    await _db.SaveChangesAsync();
                    return true;
                }
                else
                    throw new SqlNullValueException();
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteFakeAsync(string Name)
        {
            try
            {
                var data = await PrivateGetByName(Name);
                if (data != null)
                {
                    data.State = "IsDelete";
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

        public async Task<List<CourseGetDto>> GetAsync()
        {
            try
            {
                var data = await PrivateGet();
                List<CourseGetDto> response = new();
                _mapper.Map(data, response);
                return response;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
                return null;
            }
        }

        private async Task<Course> PrivateGetByName(string Name)
        {
            try
            {
                var data = await _db.Courses.FirstOrDefaultAsync(c => c.Name == Name && c.State != "IsDeleted");
                return data;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
                return null;
            }
        }


        public async Task<CourseGetDto> GetByNameAsync(string Name)
        {
            try
            {
                var data = await PrivateGetByName(Name);
                CourseGetDto response = new();
                _mapper.Map(data, response);
                return response;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<CourseGetDto> PostAsync(CoursePostDto dto)
        {
            try
            {
                var check = await PrivateGetByName(dto.Name);
                if (check == null)
                {
                    _db.Courses.Add(new Course { Name = dto.Name });
                    await _db.SaveChangesAsync();
                }
                else
                    throw new SqlNullValueException();

                CourseGetDto response = new() { Name = dto.Name };
                return response;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
                return null;
            }

        }

        public async Task<CourseGetDto> PutAsync(CoursePostDto dto)
        {
            try
            {
                var data = await PrivateGetByName(dto.Name);
                if (data != null)
                {
                    _mapper.Map(dto, data);
                    await _db.SaveChangesAsync();
                }
                else
                    throw new Exception();

                CourseGetDto response = new() { Name = dto.Name };
                return response;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<List<CourseGetDto>> GetAllAsync()
        {
            try
            {
                var data = await _db.Courses.ToListAsync();
                List<CourseGetDto> response = new();
                _mapper.Map(data, response);
                return response;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
                return null;
            }
        }
    }
}
