﻿using CarBook.Application.Features.Mediator.Commands.TagCloudCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateTagCloudCommand>
    {
        private readonly IRepository<TagCloud> _repository;

        public CreateBlogCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTagCloudCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new TagCloud
            {
               Title=request.Title,
               BlogID=request.BlogID,
            });
        }
    }
}
