﻿using CarBook.Application.Features.Mediator.Results.CarPricingResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CarPricingQueries
{
	public class GetCarPricingWithTimeQuery:IRequest<List<GetCarPricingWithTimePeriodQueryResult>>
	{
	}
}
