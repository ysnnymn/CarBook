using CarBook.Application.Features.Mediator.Commands.TestimonailCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class RemoveTestimonailCommandHandler : IRequestHandler<RemoveTestimonailCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public RemoveTestimonailCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveTestimonailCommand request, CancellationToken cancellationToken)
        {
           var values= await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(values);

        }
    }
}
