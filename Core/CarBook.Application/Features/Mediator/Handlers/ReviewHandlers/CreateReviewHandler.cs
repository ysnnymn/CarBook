﻿using CarBook.Application.Features.Mediator.Commands.ReviewCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
	public class CreateReviewHandler : IRequestHandler<CreateReviewCommand>
	{
		private readonly IRepository<Review> _repository;

		public CreateReviewHandler(IRepository<Review> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Review
			{
				CarID= request.CarID,
				CustomerImage= request.CustomerImage,
				CustomerName= request.CustomerName,
				Comment= request.Comment,
				RaytingValue= request.RaytingValue,
				ReviewDate=DateTime.Parse(DateTime.Now.ToShortDateString()),
			});
		}
	}
}
