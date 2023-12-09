using Api.Dtos;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    // Controller for handling instructors with authorization for roles "User" and "Instructor"
    [Authorize(Roles = "User,Instructor")]
    public class InstructorController : ApiBaseController
    {
        // Fields for dependency injection
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        // Constructor to initialize the controller with dependencies
        public InstructorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET action to retrieve an instructor by name
        [HttpGet("ByName")]
        public async Task<ActionResult<InstructorDto>> GetByName([FromQuery] string Name)
        {
            // Retrieve an instructor by name from the repository
            var Instructor = await _unitOfWork.Instructors.GetInstructorByName(Name);

            // Map the retrieved instructor to InstructorDto
            return _mapper.Map<InstructorDto>(Instructor);
        }
    }
}
