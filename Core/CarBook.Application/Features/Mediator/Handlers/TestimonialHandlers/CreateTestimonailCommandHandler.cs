using CarBook.Application.Features.Mediator.Commands.TestimonailCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class CreateTestimonailCommandHandler : IRequestHandler<CreateTestimonailCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public CreateTestimonailCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTestimonailCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Testimonial
            {
                Title = request.Title,
                Comment = request.Comment,
                ImageUrl = request.ImageUrl,
                Name = request.Name,
            });
        }
    }
}
