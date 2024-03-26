using CarBook.Application.Features.Mediator.Results.TagCloudResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudByIdBlogIdQuery : IRequest<List<GetTagCloudByIdBlogIdQueryResult>>
    {
        public int Id { get; set; }

        public GetTagCloudByIdBlogIdQuery(int id)
        {
            Id = id;
        }
    }
}
