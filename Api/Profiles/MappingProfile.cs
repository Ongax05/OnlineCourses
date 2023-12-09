using Api.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    // AutoMapper profile for mapping between entities and DTOs
    public class MappingProfile : Profile
    {
        // Constructor to define mappings
        public MappingProfile()
        {
            // Map between Comment and CommentDto in both directions
            CreateMap<Comment, CommentDto>().ReverseMap();

            // Map between Course and CourseDto in both directions
            CreateMap<Course, CourseDto>().ReverseMap();

            // Map between Instructor and InstructorDto, specifying a custom mapping for the Name property
            CreateMap<Instructor, InstructorDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.Username))
                .ReverseMap();

            // Map between Qualification and QualificationDto in both directions
            CreateMap<Qualification, QualificationDto>().ReverseMap();

            // Map between Course and CourseWithEntities, with a custom mapping for the Instructor's Name property
            CreateMap<Course, CourseWithEntities>()
                .AfterMap((src, dest) => dest.Instructor.Name = src.Instructor.User.Username)
                .ReverseMap();
        }
    }
}
