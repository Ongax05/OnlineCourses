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
        public async Task<ActionResult<IEnumerable<QualificationDto>>> GetByCourse([FromQuery] int CourseId)
        {
            var registers = await _unitOfWork.Qualifications.GetQualificationsByCourse(CourseId);
            var QualificationListDto = _mapper.Map<List<QualificationDto>>(registers);
            return QualificationListDto;
        }
        [HttpGet("ByUser")]
        public async Task<ActionResult<IEnumerable<QualificationDto>>> GetByUser([FromQuery] int UserId)
        {
            var registers = await _unitOfWork.Qualifications.GetQualificationsByUser(UserId);
            var QualificationListDto = _mapper.Map<List<QualificationDto>>(registers);
            return QualificationListDto;
        }
        
        [HttpPost]
        public async Task<ActionResult<int>> Post(QualificationDto QualificationDto)
        {
            var Qualification = _mapper.Map<Qualification>(QualificationDto);
            _unitOfWork.Qualifications.Add(Qualification);
            int CourseId= Qualification.CourseId;
            Console.WriteLine("eNTRO HHPTA");
            await _unitOfWork.Qualifications.UpdateCourseAverage(CourseId);
            Console.WriteLine("SALIO");
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Post),1);
        }
    
    }
}
