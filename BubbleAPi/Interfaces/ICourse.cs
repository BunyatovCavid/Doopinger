using BubbleAPi.Dtoes;

namespace Doopinger 
{ 
    public interface ICourse 
    { 
        public Task<CourseGetDto> GetByNameAsync (string Name); 
        public Task<List<CourseGetDto>> GetAsync (); 
        public Task<List<CourseGetDto>> GetAllAsync (); 
        public Task<CourseGetDto> PostAsync (CoursePostDto dto); 
        public Task<CourseGetDto> PutAsync (CoursePostDto dto); 
        public Task<bool> DeleteFakeAsync (string Name); 
        public Task<bool> DeleteAsync (string Name); 
    } 
} 
