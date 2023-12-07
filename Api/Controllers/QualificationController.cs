using Api.Dtos;
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
        
        [HttpGet("ByCourse")]
        public async Task<ActionResult<AverageDto>> GetByCourse([FromQuery] int CourseId)
        {
            var average = await _unitOfWork.Qualifications.GetAverageQualificationByCourse(CourseId);
            var AverageDto = new AverageDto()
            {
                Average = average
            };
            return AverageDto;
        }
        [HttpGet("ByUser")]
        public async Task<ActionResult<List<QualificationDto>>> GetByUser([FromQuery] int UserId)
        {
            var qualifications = await _unitOfWork.Qualifications.GetQualificationsByUser(UserId);
            return _mapper.Map<List<QualificationDto>>(qualifications);
        }
        
        [HttpPost]
        public async Task<ActionResult<int>> Post(QualificationDto QualificationDto)
        {
            var Qualification = _mapper.Map<Qualification>(QualificationDto);
            _unitOfWork.Qualifications.Add(Qualification);
            int CourseId= Qualification.CourseId;
            await _unitOfWork.Qualifications.UpdateCourseAverage(CourseId);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Post),1);
        }
    
    }
}
