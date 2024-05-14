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
    public class GetCarCountByFuelElectiricQueryHandler : IRequestHandler<GetCarCountByFuelElectiricQuery, GetCarCountByFuelElectiricQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByFuelElectiricQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByFuelElectiricQueryResult> Handle(GetCarCountByFuelElectiricQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarCountByFuelElectiric();
            return new GetCarCountByFuelElectiricQueryResult
            {
                CarCountByFuelElectiric = values,
            };
        }
    }

}
