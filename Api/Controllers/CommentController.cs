using Api.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    // Controller for handling comments with authorization for roles "User" and "Instructor"
    [Authorize(Roles = "User,Instructor")]
    public class CommentController : ApiBaseController
    {
        // Fields for dependency injection
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        // Constructor to initialize the controller with dependencies
        public CommentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        // GET action to retrieve comments by course ID
        [HttpGet ("ByCourse")]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetByCourse([FromQuery] int CourseId)
        {
            // Retrieve comments by course ID from the repository
            var registers = await _unitOfWork.Comments.GetCommentsByCourse(CourseId);
            
            // Map the retrieved comments to CommentDto
            var CommentListDto = _mapper.Map<List<CommentDto>>(registers);

            // Return the mapped CommentDto list
            return CommentListDto;
        }

        // GET action to retrieve comments by user ID
        [HttpGet ("ByUser")]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetByUsers([FromQuery] int UserId)
        {
            // Retrieve comments by user ID from the repository
            var registers = await _unitOfWork.Comments.GetCommentsByUser(UserId);

            // Map the retrieved comments to CommentDto
            var CommentListDto = _mapper.Map<List<CommentDto>>(registers);

            // Return the mapped CommentDto list
            return CommentListDto;
        }
        
         // POST action to create a new comment
        [HttpPost]
        public async Task<ActionResult<Comment>> Post(CommentDto CommentDto)
        {
            // Map the CommentDto to a Comment entity
            var Comment = _mapper.Map<Comment>(CommentDto);

            // Add the comment to the repository
            _unitOfWork.Comments.Add(Comment);

            // Save changes to the database
            await _unitOfWork.SaveAsync();

            // Return the created comment
            return CreatedAtAction(nameof(Post), Comment);
        }
    }
}