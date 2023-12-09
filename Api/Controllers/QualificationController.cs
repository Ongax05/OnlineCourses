using Api.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    // Controller for handling qualifications with authorization for roles "User" and "Instructor"
    [Authorize(Roles = "User,Instructor")]
    public class QualificationController : ApiBaseController 
    { 
        // Fields for dependency injection
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        // Constructor to initialize the controller with dependencies
        public QualificationController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        // GET action to retrieve the average qualification for a specific course
        [HttpGet("ByCourse")]
        public async Task<ActionResult<AverageDto>> GetByCourse([FromQuery] int CourseId)
        {
            // Retrieve the average qualification for a specific course from the repository
            var average = await _unitOfWork.Qualifications.GetAverageQualificationByCourse(CourseId);
            
            // Create an AverageDto with the retrieved average qualification
            var AverageDto = new AverageDto()
            {
                Average = average
            };

            // Return the AverageDto
            return AverageDto;
        }

        // GET action to retrieve qualifications for a specific user
        [HttpGet("ByUser")]
        public async Task<ActionResult<List<QualificationDto>>> GetByUser([FromQuery] int UserId)
        {
            // Retrieve qualifications for a specific user from the repository
            var qualifications = await _unitOfWork.Qualifications.GetQualificationsByUser(UserId);

            // Map the retrieved qualifications to QualificationDto
            return _mapper.Map<List<QualificationDto>>(qualifications);
        }
        
        // POST action to create a new qualification
        [HttpPost]
        public async Task<ActionResult<int>> Post(QualificationDto QualificationDto)
        {
            // Map the QualificationDto to a Qualification entity
            var Qualification = _mapper.Map<Qualification>(QualificationDto);

            // Add the qualification to the repository
            _unitOfWork.Qualifications.Add(Qualification);

            // Retrieve the CourseId from the qualification
            int CourseId = Qualification.CourseId;

            // Update the average rating for the associated course
            await _unitOfWork.Qualifications.UpdateCourseAverage(CourseId);

            // Save changes to the database
            await _unitOfWork.SaveAsync();

            // Return the created qualification
            return CreatedAtAction(nameof(Post), 1);
        }
    }
}
