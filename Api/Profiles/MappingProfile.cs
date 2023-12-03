using Api.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile (){
            CreateMap<Comment,CommentDto>().ReverseMap();
            CreateMap<Course,CourseDto>().ReverseMap();
            CreateMap<CourseImage,CourseImageDto>().ReverseMap();
            CreateMap<Instructor,InstructorDto>().ReverseMap();
            CreateMap<Qualification,QualificationDto>().ReverseMap();
        }
    }
}