using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCarCommand command)
        {
            var value = await _repository.GetByIdAsync(command.CarID);
            value.Fuel = command.Fuel;
            value.Name = command.Name;
            value.Seat = command.Seat;
            value.BrandID = command.BrandID;
            value.BigImageUrl = command.BigImageUrl;
            value.CoverImageURl = command.CoverImageURl;
            value.Transmission = command.Transmission;
            value.Km = command.Km;
            value.Model = command.Model;
            value.Luggage = command.Luggage;
            await _repository.UpdateAsync(value);


        }
    }
}
