using Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
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
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Courses.GetAllAsync();
            var CourseListDto = _mapper.Map<List<CourseDto>>(registers);
            return CourseListDto;
        }
        
        [HttpPost]
        public async Task<ActionResult<Course>> Post(CourseDto CourseDto)
        {
            var Course = _mapper.Map<Course>(CourseDto);
            _unitOfWork.Courses.Add(Course);
            await _unitOfWork.SaveAsync();
            CourseDto.Id = Course.Id;
            return CreatedAtAction(nameof(Post), new { id = CourseDto.Id }, CourseDto);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<CourseDto>> Put(
            int id,
            [FromBody] CourseDto CourseDto
        )
        {
            if (CourseDto == null)
            {
                return NotFound(404);
            }
            var Course = _mapper.Map<Course>(CourseDto);
            _unitOfWork.Courses.Update(Course);
            await _unitOfWork.SaveAsync();
            return CourseDto;
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Course = await _unitOfWork.Courses.GetByIdAsync(id);
            _unitOfWork.Courses.Remove(Course);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}