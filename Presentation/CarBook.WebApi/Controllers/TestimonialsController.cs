using CarBook.Application.Features.Mediator.Commands.TestimonailCommand;
using CarBook.Application.Features.Mediator.Queries.TestimonailQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestimonialsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> TestimonailList()
        {
            var values = await _mediator.Send(new GetTestimonailQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonail(int id)
        {
            var values = await _mediator.Send(new GetTestimoanilByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonail(CreateTestimonailCommand command)
        {
            await _mediator.Send(command);
            return Ok("Referans Bilgisi Başarıyla Eklendi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTestimonail(UpdateTestimonailCommand command)
        {
            await _mediator.Send(command);
            return Ok("Referans Bilgisi Başarıyla Güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTestimonail(int id)
        {
            await _mediator.Send(new RemoveTestimonailCommand(id));
            return Ok("Referans Bilgisi Başarıyla Silindi.");
        }
    }
}
