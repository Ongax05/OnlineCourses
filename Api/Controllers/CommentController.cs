using Dtos;
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
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Comments.GetAllAsync();
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
        
        [HttpPut("{id}")]
        public async Task<ActionResult<CommentDto>> Put(
            int id,
            [FromBody] CommentDto CommentDto
        )
        {
            if (CommentDto == null)
            {
                return NotFound(404);
            }
            var Comment = _mapper.Map<Comment>(CommentDto);
            _unitOfWork.Comments.Update(Comment);
            await _unitOfWork.SaveAsync();
            return CommentDto;
        }
        
        [HttpDelete("DeleteByIds")]
        public async Task<ActionResult> Delete([FromQuery]int courseId, int UserId)
        {
            var Comment = await _unitOfWork.Comments.GetByIdsAsync(courseId,UserId);
            _unitOfWork.Comments.Remove(Comment);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}