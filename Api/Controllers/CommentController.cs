using Api.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class CommentController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public CommentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet ("ByCourse")]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetByCourse([FromQuery] int CourseId)
        {
            var registers = await _unitOfWork.Comments.GetCommentsByCourse(CourseId);
            var CommentListDto = _mapper.Map<List<CommentDto>>(registers);
            return CommentListDto;
        }

        [HttpGet ("ByUser")]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetByUsers([FromQuery] int UserId)
        {
            var registers = await _unitOfWork.Comments.GetCommentsByUser(UserId);
            var CommentListDto = _mapper.Map<List<CommentDto>>(registers);
            return CommentListDto;
        }
        
        [HttpPost]
        public async Task<ActionResult<Comment>> Post(CommentDto CommentDto)
        {
            var Comment = _mapper.Map<Comment>(CommentDto);
            _unitOfWork.Comments.Add(Comment);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Post), Comment);
        }
    }
}