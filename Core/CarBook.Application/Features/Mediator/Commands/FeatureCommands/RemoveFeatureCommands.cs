using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.FeatureCommands
{
    public class RemoveFeatureCommands : IRequest
    {
        public int Id { get; set; }

        public RemoveFeatureCommands(int id)
        {
            Id = id;
        }
    }
}
