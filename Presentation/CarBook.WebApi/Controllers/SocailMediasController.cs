
using CarBook.Application.Features.Mediator.Commands.SocialMediaCommand;
using CarBook.Application.Features.Mediator.Queries.SocailMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocailMediasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocailMediasController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> SocailMediaList()
        {
            var values = await _mediator.Send(new GetSocailMediaQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocailMedia(int id)
        {
            var values = await _mediator.Send(new GetSocailMediaByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocailMedia(CreateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sosyal Medya Bilgisi Başarıyla Eklendi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSocailMedia(UpdateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sosyal Medya Bilgisi Başarıyla Güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSocailMedia(int id)
        {
            await _mediator.Send(new RemoveSocialMediaCommand(id));
            return Ok("Sosyal Medya Bilgisi Başarıyla Silindi.");
        }

    }
}
