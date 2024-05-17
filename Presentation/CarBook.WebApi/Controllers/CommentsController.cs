using CarBook.Application.Features.Mediator.Commands.CommentCommand;
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _repository;
        private readonly IMediator _mediator;

        public CommentsController(IGenericRepository<Comment> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _repository.GetAll();

            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            _repository.Create(comment);
            return Ok("Yorum Başırıyla Eklendi.");

        }
        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _repository.Update(comment);
            return Ok("Yorum Başırıyla Güncellendi.");

        }
        [HttpDelete]
        public IActionResult RemoveComment(int id)
        {
            var value = _repository.GetById(id);
            _repository.Remove(value);
            return Ok("Yorum Başırıyla Silindi.");

        }
        [HttpGet("id")]
        public IActionResult GetComment(int id)
        {
            var values = _repository.GetById(id);
            return Ok(values);

        }
        [HttpGet("CommentListByBlog")]
        public IActionResult CommentListByBlog(int id)
        {
            var values = _repository.GetCommandByBlogId(id);
            return Ok(values);

        }
        [HttpGet("CommentCountByBlog")]
        public IActionResult CommentCountByBlog(int id)
        {
            var values = _repository.GetCountCommentByBlog(id);
            return Ok(values);

        }
        [HttpPost("CreateCommentWithMediator")]
        public  async Task<IActionResult> CreateCommentWithMediator(CreateCommentCommand command)
        {
             await _mediator.Send(command);
            return Ok("Yorum Başarıyla Eklendi");

        }
    }
}
