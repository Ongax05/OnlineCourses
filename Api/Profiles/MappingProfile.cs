using Api.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Instructor, InstructorDto>()
                .ForMember(dest => dest.Name, Opt => Opt.MapFrom(en => en.User.Username))
                .ReverseMap();
            CreateMap<Qualification, QualificationDto>().ReverseMap();
            CreateMap<Course, CourseWithEntities>()
                .AfterMap((src, dest) => dest.Instructor.Name = src.Instructor.User.Username)
                .ReverseMap();
        }
    }
}
