﻿using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
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
    public class GetAvgRentPriceForMounthlyQueryHandler : IRequestHandler<GetAvgRentPriceForMounthlyQuery, GetAvgRentPriceForMounthlyQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAvgRentPriceForMounthlyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvgRentPriceForMounthlyQueryResult> Handle(GetAvgRentPriceForMounthlyQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetAvgRentPriceForMounthly();
            return new GetAvgRentPriceForMounthlyQueryResult
            {
                AvgRentPriceForMounthly = values,
            };
        }
    }

}
