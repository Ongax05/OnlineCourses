using Api.Dtos;
using Application.UnitOfWork;
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

        [HttpGet("ByName")]
        public async Task<ActionResult<InstructorDto>> GetByName([FromQuery] string Name)
        {
            var Instructor = await _unitOfWork.Instructors.GetInstructorByName(Name);
            return _mapper.Map<InstructorDto>(Instructor);
        }
        
    }
}