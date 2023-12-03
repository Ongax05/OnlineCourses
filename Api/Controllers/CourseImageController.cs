using Api.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class CourseImageController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseImageController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseImageDto>>> Get1_1()
        {
            var registers = await _unitOfWork.CourseImages.GetAllAsync();
            var CourseImageListDto = _mapper.Map<List<CourseImageDto>>(registers);
            return CourseImageListDto;
        }

        [HttpPost]
        public async Task<ActionResult<CourseImage>> Post(CourseImageDto CourseImageDto)
        {
            var CourseImage = _mapper.Map<CourseImage>(CourseImageDto);
            _unitOfWork.CourseImages.Add(CourseImage);
            await _unitOfWork.SaveAsync();
            CourseImageDto.Id = CourseImage.Id;
            return CreatedAtAction(nameof(Post), new { id = CourseImageDto.Id }, CourseImageDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CourseImageDto>> Put(
            int id,
            [FromBody] CourseImageDto CourseImageDto
        )
        {
            if (CourseImageDto == null)
            {
                return NotFound(404);
            }
            var CourseImage = _mapper.Map<CourseImage>(CourseImageDto);
            _unitOfWork.CourseImages.Update(CourseImage);
            await _unitOfWork.SaveAsync();
            return CourseImageDto;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var CourseImage = await _unitOfWork.CourseImages.GetByIdAsync(id);
            _unitOfWork.CourseImages.Remove(CourseImage);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
