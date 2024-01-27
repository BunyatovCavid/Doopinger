using AutoMapper;
using BubbleAPi.Domain.Entities;
using BubbleAPi.Dtoes;

namespace BubbleAPi
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Course, CourseGetDto>();
            CreateMap<Course_Report, CourseReportGetDto>();

            CreateMap<CoursePostDto, Course>();
            CreateMap<CourseReportPostDto, Course>();

            CreateMap<CourseReportPostDto, CourseReportGetDto>();
        }
    }
}
