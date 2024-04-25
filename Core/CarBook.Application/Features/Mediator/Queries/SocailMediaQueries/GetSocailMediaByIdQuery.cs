﻿using CarBook.Application.Features.Mediator.Results.SocialMediaResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.SocailMediaQueries
{
    public class GetSocailMediaByIdQuery:IRequest<GetSocailMediaByIdQueryResult>
    {
        public int Id { get; set; }

        public GetSocailMediaByIdQuery(int id)
        {
            Id = id;
        }
    }
}