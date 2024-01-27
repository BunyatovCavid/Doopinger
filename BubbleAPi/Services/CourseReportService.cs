using AutoMapper;
using BubbleAPi.Domain.Entities;
using BubbleAPi.Domain;
using BubbleAPi.Dtoes;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;

namespace Doopinger
{
    public class CourseReportService : ICourseReport
    {
        private readonly CourseDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger _log;
        public CourseReportService(CourseDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        private async Task<List<Course_Report>> PrivateGet()
        {
            try
            {
                var data = await _db.Course_Reports.ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                _log.LogInformation(ex, ex.Message);
                return null;
            }

        }



        private async Task<Course_Report> PrivateGetById(int id)
        {
            try
            {
                var data = await _db.Course_Reports.FirstOrDefaultAsync(c => c.Id == id);
                return data;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
                return null;
            }
        }




        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var data = await PrivateGetById(id);
                if (data != null)
                {
                    _db.Course_Reports.Remove(data);
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

        public async Task<bool> DeleteFakeAsync(int id)
        {
            try
            {
                var data = await PrivateGetById(id);
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

        public async Task<List<CourseReportGetDto>> GetAsync()
        {
            try
            {
                var data = await PrivateGet();
                List<CourseReportGetDto> response = new();
                _mapper.Map(data, response);
                return response;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<CourseReportGetDto> GetByIdAsync(int id)
        {
            try
            {
                var data = await PrivateGetById(id);
                CourseReportGetDto response = new();
                _mapper.Map(data, response);
                return response;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<CourseReportGetDto> PostAsync(CourseReportPostDto dto)
        {
            try
            {
                Course_Report request = new();
                _mapper.Map(dto, request);
                _db.Course_Reports.Add(request);
                await _db.SaveChangesAsync();

                CourseReportGetDto response = new();
                _mapper.Map(dto, response);
                return response;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
                return null;
            }

        }

        public async Task<CourseReportGetDto> PutAsync(CourseReportPostDto dto)
        {
            try
            {
                var data = await PrivateGetById(dto.Id);
                if (data != null)
                {
                    _mapper.Map(dto, data);
                    await _db.SaveChangesAsync();
                }
                else
                    throw new Exception();

                CourseReportGetDto response = new();
                _mapper.Map(dto, response);
                return response;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, ex.Message);
                return null;
            }
        }

        public async Task<List<CourseReportGetDto>> GetAllAsync()
        {

            try
            {
                var data = await _db.Course_Reports.ToListAsync();
                List<CourseReportGetDto> response = new();
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
