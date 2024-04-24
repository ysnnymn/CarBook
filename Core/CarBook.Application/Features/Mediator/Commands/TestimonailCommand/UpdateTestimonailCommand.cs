using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TestimonailCommand
{
    public class UpdateTestimonailCommand:IRequest
    {
        public int TestimonialID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
    }
}
