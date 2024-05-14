using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarCountByTransmassionIsAutoQueryHandler : IRequestHandler<GetCarCountByTransmassionIsAutoQuery, GetCarCountByTransmassionIsAutoQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByTransmassionIsAutoQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByTransmassionIsAutoQueryResult> Handle(GetCarCountByTransmassionIsAutoQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarCountByTransmassionIsAuto();
            return new GetCarCountByTransmassionIsAutoQueryResult
            {
                CarCountByTransmassionIsAuto = values,
            };
        }
    }

}
