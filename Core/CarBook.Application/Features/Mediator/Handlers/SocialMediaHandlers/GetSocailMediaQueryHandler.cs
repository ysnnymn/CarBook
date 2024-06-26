﻿using CarBook.Application.Features.Mediator.Queries.SocailMediaQueries;
using CarBook.Application.Features.Mediator.Results.SocialMediaResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocailMediaQueryHandler : IRequestHandler<GetSocailMediaQuery, List<GetSocailMediaQueryResult>>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocailMediaQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetSocailMediaQueryResult>> Handle(GetSocailMediaQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetSocailMediaQueryResult
            {
                SocialMediaID = x.SocialMediaID,
                Name = x.Name,
                Icon= x.Icon,
                Url= x.Url
            }).ToList();
        }
    }
}
