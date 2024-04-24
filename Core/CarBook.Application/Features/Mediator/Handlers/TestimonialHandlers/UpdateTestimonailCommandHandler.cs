using CarBook.Application.Features.Mediator.Commands.TestimonailCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class UpdateTestimonailCommandHandler : IRequestHandler<UpdateTestimonailCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public UpdateTestimonailCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTestimonailCommand request, CancellationToken cancellationToken)
        {
            var values= await _repository.GetByIdAsync(request.TestimonialID);
            values.Comment = request.Comment;
            values.Title = request.Title;
            values.Name = request.Name;
            values.ImageUrl = request.ImageUrl;
            await _repository.UpdateAsync(values);
            
        }
    }
}
