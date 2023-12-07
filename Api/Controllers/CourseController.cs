using Api.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class CourseController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "User,Instructor")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Courses.GetAllAsync();
            var CourseListDto = _mapper.Map<List<CourseDto>>(registers);
            return CourseListDto;
        }

        [Authorize(Roles = "User,Instructor")]
        [HttpGet("ById")]
        public async Task<ActionResult<CourseWithEntities>> GetById([FromQuery] int Id)
        {
            var Register = await _unitOfWork.Courses.GetByIdAsync(Id);
            var CourseMapped = _mapper.Map<CourseWithEntities>(Register);
            return CourseMapped;
        }
        
        [Authorize(Roles = "Instructor")]
        [HttpPost]
        public async Task<ActionResult<Course>> Post(CourseDto CourseDto)
        {
            var Course = _mapper.Map<Course>(CourseDto);
            _unitOfWork.Courses.Add(Course);
            await _unitOfWork.SaveAsync();
            CourseDto.Id = Course.Id;
            return CreatedAtAction(nameof(Post), new { id = CourseDto.Id }, CourseDto);
        }
    }
}
