using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarCountByFuelGassolineOrDieselQueryHandler : IRequestHandler<GetCarCountByFuelGassolineOrDieselQuery, GetCarCountByFuelGassolineOrDieselQueryReslut>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByFuelGassolineOrDieselQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByFuelGassolineOrDieselQueryReslut> Handle(GetCarCountByFuelGassolineOrDieselQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByFuelGassolineOrDiesel();
            return new GetCarCountByFuelGassolineOrDieselQueryReslut
            {
                CarCountByFuelGassolineOrDiesel = value,
            };
        }
    }
}
