using CarBook.Application.Features.Mediator.Commands.ReviewCommand;
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
	public class UpdateReviewHandler : IRequestHandler<UpdateReviewCommand>
	{
		private readonly IRepository<Review> _repository;

		public UpdateReviewHandler(IRepository<Review> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.ReviewID);
			value.CustomerName = request.CustomerName;
			value.ReviewDate = request.ReviewDate;
			value.CarID = request.CarID;
			value.Comment=	request.Comment;
			value.RaytingValue = request.RaytingValue;
			await _repository.UpdateAsync(value);

		}
	}
	
	}

