
using CarBook.Application.Features.Mediator.Queries.SocailMediaQueries;
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
    public class GetSocailMediaByIdQueryHandler : IRequestHandler<GetSocailMediaByIdQuery, GetSocailMediaByIdQueryResult>

    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocailMediaByIdQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<GetSocailMediaByIdQueryResult> Handle(GetSocailMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetSocailMediaByIdQueryResult
            {
                SocialMediaID = values.SocialMediaID,
                Icon = values.Icon,
                Name = values.Name,
                Url = values.Url,

            };
        }
    }
}
