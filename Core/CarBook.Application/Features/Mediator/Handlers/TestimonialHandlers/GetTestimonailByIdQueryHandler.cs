using CarBook.Application.Features.Mediator.Queries.TestimonailQueries;
using CarBook.Application.Features.Mediator.Results.TestimonialResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonailByIdQueryHandler : IRequestHandler<GetTestimoanilByIdQuery, GetTestimonailByIdQueryResult>
    {
        private readonly IRepository<Testimonial> _repository;
public GetTestimonailByIdQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<GetTestimonailByIdQueryResult> Handle(GetTestimoanilByIdQuery request, CancellationToken cancellationToken)
        {
           var  values= await _repository.GetByIdAsync(request.Id);
            return new GetTestimonailByIdQueryResult
            {
                Comment=values.Comment,
                ImageUrl=values.ImageUrl,
                Name=values.Name,
                TestimonialID=values.TestimonialID,
                Title=values.Title,
            };
        }
    }
}
