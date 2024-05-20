﻿using CarBook.Application.Features.Mediator.Commands.ReviewCommand;
using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Validators.ReviewValidators;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ReviewsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> ReviewListByCarId(int id)
		{
			var values=await _mediator.Send(new GetReviewByCarIdQuery(id));
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateReview(CreateReviewCommand command)
		{
			CreateReviewValidator validator= new CreateReviewValidator();
			var validationResult=validator.Validate(command);
			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors);
			}
			await _mediator.Send(command);
			return Ok("EKleme İşlemi Gerçekleştirildi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateReview(UpdateReviewCommand command)
		{
			UpdateReviewValidator validator = new UpdateReviewValidator();
			var validationResult = validator.Validate(command);
			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors);
			}
			await _mediator.Send(command);
			return Ok("Güncelleme İşlemi Gerçekleştirildi");
		}
	}
}
