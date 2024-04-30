using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TagCloudCommand
{
    public class UpdateTagCloudCommand:IRequest
    {
        public int TagCloudID { get; set; }
        public string Title { get; set; }
        public int BlogID { get; set; }
    }
}
