using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarCount")]
        public async Task<IActionResult> GetCarCount()
        {
            var values = await _mediator.Send(new GetCarCountQuery());
            return Ok(values);

        }
        [HttpGet("GetLocationCount")]
        public async Task<IActionResult> GetLocationCount()
        {
            var values = await _mediator.Send(new GetLocationCountQuery());
            return Ok(values);

        }
        [HttpGet("GetAuthorCount")]
        public async Task<IActionResult> GetAuthorCount()
        {
            var values = await _mediator.Send(new GetAuthorCountQuery());
            return Ok(values);

        }
        [HttpGet("GetBlogCount")]
        public async Task<IActionResult> GetBlogCount()
        {
            var values = await _mediator.Send(new GetBlogCountQuery());
            return Ok(values);

        }
        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var values = await _mediator.Send(new GetBrandCountQuery());
            return Ok(values);

        }
        [HttpGet("GetAvgRentPriceForDaily")]
        public async Task<IActionResult> GetAvgRentPriceForDaily()
        {
            var values = await _mediator.Send(new GetAvgRentPriceForDailyQuery());
            return Ok(values);

        }
        [HttpGet("GetAvgRentPriceForWeekly")]
        public async Task<IActionResult> GetAvgRentPriceForWeekly()
        {
            var values = await _mediator.Send(new GetAvgRentPriceForWeeklyQuery());
            return Ok(values);

        }
        [HttpGet("GetAvgRentPriceForMounthly")]
        public async Task<IActionResult> GetAvgRentPriceForMounthly()
        {
            var values = await _mediator.Send(new GetAvgRentPriceForMounthlyQuery());
            return Ok(values);

        }
        [HttpGet("GetCarCountByTransmassionIsAuto")]
        public async Task<IActionResult> GetCarCountByTransmassionIsAuto()
        {
            var values = await _mediator.Send(new GetCarCountByTransmassionIsAutoQuery());
            return Ok(values);

        }
        [HttpGet("BrandNameByMaxCar")]
        public async Task<IActionResult> BrandNameByMaxCar()
        {
            var values = await _mediator.Send(new GetBrandNameByMaxCarQuery());
            return Ok(values);

        }
        [HttpGet("GetBlogTitleByMaxBlogComment")]
        public async Task<IActionResult> GetBlogTitleByMaxBlogComment()
        {
            var values = await _mediator.Send(new GetBlogTitleByMaxBlogCommentQuery());
            return Ok(values);

        }
        [HttpGet("GetCarCountByKmSmallerThen1000")]
        public async Task<IActionResult> GetCarCountByKmSmallerThen1000()
        {
            var values = await _mediator.Send(new GetCarCountByKmSmallerThen1000Query());
            return Ok(values);

        }
        [HttpGet("GetCarCountByFuelGasolineOrDiesel")]
        public async Task<IActionResult> GetCarCountByFuelGasolineOrDiesel()
        {
            var values = await _mediator.Send(new GetCarCountByFuelGasolineOrDieselQuery());
            return Ok(values);

        }
        [HttpGet("GetCarCountByFuelElectiric")]
        public async Task<IActionResult> GetCarCountByFuelElectiric()
        {
            var values = await _mediator.Send(new GetCarCountByFuelElectiricQuery());
            return Ok(values);

        }
        [HttpGet("GetCarBrandAndModelByRentPriceMax")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceMax()
        {
            var values = await _mediator.Send(new GetCarBrandAndModelByRentPriceMaxQuery());
            return Ok(values);

        }
        [HttpGet("GetCarBrandAndModelByRentPriceMin")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceMin()
        {
            var values = await _mediator.Send(new GetCarBrandAndModelByRentPriceMinQuery());
            return Ok(values);

        }

    }
}
