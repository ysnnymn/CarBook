﻿using CarBook.Application.Features.Mediator.Results.TestimonialResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.TestimonailQueries
{
    public class GetTestimonailQuery:IRequest<List<GetTestimonialQueryResult>>

    {
    }
}
