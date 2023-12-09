using Api.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    // Controller for handling courses
    public class CourseController : ApiBaseController
    {
        // Fields for dependency injection
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        // Constructor to initialize the controller with dependencies
        public CourseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET action to retrieve all courses and just for "Users" and " "Instructors"
        [Authorize(Roles = "User,Instructor")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> Get1_1()
        {
            // Retrieve all courses from the repository
            var registers = await _unitOfWork.Courses.GetAllAsync();
            
            // Map the retrieved courses to CourseDto
            var CourseListDto = _mapper.Map<List<CourseDto>>(registers);

            // Return the mapped CourseDto list
            return CourseListDto;
        }

         // GET action to retrieve a course by its ID and just for "Users" and " "Instructors"
        [Authorize(Roles = "User,Instructor")]
        [HttpGet("ById")]
        public async Task<ActionResult<CourseWithEntities>> GetById([FromQuery] int Id)
        {
            // Retrieve a course by its ID from the repository
            var Register = await _unitOfWork.Courses.GetByIdAsync(Id);

            // Map the retrieved course to CourseWithEntities
            var CourseMapped = _mapper.Map<CourseWithEntities>(Register);

            // Return the mapped CourseWithEntities
            return CourseMapped;
        }
        
         // POST action to create a new course and just can be added by s"Instructors"
        [Authorize(Roles = "Instructor")]
        [HttpPost]
        public async Task<ActionResult<Course>> Post(CourseDto CourseDto)
        {
            // Map the CourseDto to a Course entity
            var Course = _mapper.Map<Course>(CourseDto);

            // Add the course to the repository
            _unitOfWork.Courses.Add(Course);

            // Save changes to the database
            await _unitOfWork.SaveAsync();

            // Update the CourseDto with the generated ID
            CourseDto.Id = Course.Id;

            // Return the created course
            return CreatedAtAction(nameof(Post), new { id = CourseDto.Id }, CourseDto);
        }
    }
}
