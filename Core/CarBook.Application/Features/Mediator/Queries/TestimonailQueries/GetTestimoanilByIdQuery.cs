using CarBook.Application.Features.Mediator.Results.TestimonialResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.TestimonailQueries
{
    public class GetTestimoanilByIdQuery:IRequest<GetTestimonailByIdQueryResult>
    {
        public int Id { get; set; }

        public GetTestimoanilByIdQuery(int id)
        {
            Id = id;
        }
    }
}
