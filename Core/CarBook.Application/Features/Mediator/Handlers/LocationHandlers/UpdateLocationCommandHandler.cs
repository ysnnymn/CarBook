﻿using CarBook.Application.Features.Mediator.Commands.LocationCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateLocationCommand>
    {
        private readonly IRepository<Location> _repository;

        public UpdateBlogCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var values=await _repository.GetByIdAsync(request.LocationID);
            values.Name=request.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
