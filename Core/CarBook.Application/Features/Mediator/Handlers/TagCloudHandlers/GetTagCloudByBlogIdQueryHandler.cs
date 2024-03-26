using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using CarBook.Application.Features.Mediator.Results.TagCloudResults;
using CarBook.Application.Interfaces.TagCloudInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByIdBlogIdQuery, List<GetTagCloudByIdBlogIdQueryResult>>
    {
        private readonly ITagCloudRepository _repository;

        public GetTagCloudByBlogIdQueryHandler(ITagCloudRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTagCloudByIdBlogIdQueryResult>> Handle(GetTagCloudByIdBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values =  _repository.GetTagCloudByBlogsID(request.Id).ToList();
            return values.Select(x => new GetTagCloudByIdBlogIdQueryResult
            {
                TagCloudID = x.TagCloudID,
                Title = x.Title,
                BlogID = x.BlogID
            }).ToList();
            
        }
    }
}
