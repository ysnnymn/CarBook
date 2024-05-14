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
    public class GetCarBrandAndModelByRentPriceMinQueryHandler : IRequestHandler<GetCarBrandAndModelByRentPriceMinQuery, GetCarBrandAndModelByRentPriceMinQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarBrandAndModelByRentPriceMinQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarBrandAndModelByRentPriceMinQueryResult> Handle(GetCarBrandAndModelByRentPriceMinQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarBrandAndModelByRentPriceMin();
            return new GetCarBrandAndModelByRentPriceMinQueryResult
            {
                CarBrandAndModelByRentPriceMin = values,
            };
        }
    }

}
