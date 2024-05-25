using CarBook.Application.Features.Mediator.Commands.BlogCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var values=await _repository.GetByIdAsync(request.BlogId);
            values.AuthorId = request.AuthorId;
            values.CreatedDate = request.CreatedDate;
            values.CategoryId = request.CategoryId;
            values.CoverImageUrl = request.CoverImageUrl;
            values.Title = request.Title;
            values.Description = request.Descripiton;
           
            await _repository.UpdateAsync(values);
        }
    }
}
