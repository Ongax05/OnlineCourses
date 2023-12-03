using Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class InstructorController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public InstructorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstructorDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Instructors.GetAllAsync();
            var InstructorListDto = _mapper.Map<List<InstructorDto>>(registers);
            return InstructorListDto;
        }
        
        [HttpPost]
        public async Task<ActionResult<Instructor>> Post(InstructorDto InstructorDto)
        {
            var Instructor = _mapper.Map<Instructor>(InstructorDto);
            _unitOfWork.Instructors.Add(Instructor);
            await _unitOfWork.SaveAsync();
            InstructorDto.Id = Instructor.Id;
            return CreatedAtAction(nameof(Post), new { id = InstructorDto.Id }, InstructorDto);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<InstructorDto>> Put(
            int id,
            [FromBody] InstructorDto InstructorDto
        )
        {
            if (InstructorDto == null)
            {
                return NotFound(404);
            }
            var Instructor = _mapper.Map<Instructor>(InstructorDto);
            _unitOfWork.Instructors.Update(Instructor);
            await _unitOfWork.SaveAsync();
            return InstructorDto;
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Instructor = await _unitOfWork.Instructors.GetByIdAsync(id);
            _unitOfWork.Instructors.Remove(Instructor);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}