using BubbleAPi.Dtoes;

namespace Doopinger 
{ 
    public interface ICourseReport 
    { 
        public Task<CourseReportGetDto> GetByIdAsync (int id); 
        public Task<List<CourseReportGetDto>> GetAsync (); 
        public Task<List<CourseReportGetDto>> GetAllAsync (); 
        public Task<CourseReportGetDto> PostAsync (CourseReportPostDto dto); 
        public Task<CourseReportGetDto> PutAsync (CourseReportPostDto dto); 
        public Task<bool> DeleteFakeAsync (int id); 
        public Task<bool> DeleteAsync (int id); 
    } 
} 
