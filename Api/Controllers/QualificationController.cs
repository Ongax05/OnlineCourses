using Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class QualificationController : ApiBaseController 
    { 
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public QualificationController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QualificationDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Qualifications.GetAllAsync();
            var QualificationListDto = _mapper.Map<List<QualificationDto>>(registers);
            return QualificationListDto;
        }
        
        [HttpPost]
        public async Task<ActionResult<Qualification>> Post(QualificationDto QualificationDto)
        {
            var Qualification = _mapper.Map<Qualification>(QualificationDto);
            _unitOfWork.Qualifications.Add(Qualification);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Post), Qualification);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<QualificationDto>> Put(
            int id,
            [FromBody] QualificationDto QualificationDto
        )
        {
            if (QualificationDto == null)
            {
                return NotFound(404);
            }
            var Qualification = _mapper.Map<Qualification>(QualificationDto);
            _unitOfWork.Qualifications.Update(Qualification);
            await _unitOfWork.SaveAsync();
            return QualificationDto;
        }
        
        [HttpDelete("DeleteByIds")]
        public async Task<ActionResult> Delete([FromQuery]int courseId, int UserId)
        {
            var Qualification = await _unitOfWork.Qualifications.GetByIdsAsync(courseId, UserId);

            _unitOfWork.Qualifications.Remove(Qualification);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
