using CarBook.Application.Features.Mediator.Results.CarFeatureResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CarFeatureQueries
{
    public class GetCarFeatureByIdQuery:IRequest<List<GetCarFeatureByCarIdQueryResult>>
    {
        public int Id { get; set; }

        public GetCarFeatureByIdQuery(int id)
        {
            Id = id;
        }
    }
}
