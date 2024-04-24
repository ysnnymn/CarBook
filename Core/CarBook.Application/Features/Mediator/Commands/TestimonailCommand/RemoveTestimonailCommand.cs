using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TestimonailCommand
{
    public class RemoveTestimonailCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveTestimonailCommand(int id)
        {
            Id = id;
        }
    }
}
