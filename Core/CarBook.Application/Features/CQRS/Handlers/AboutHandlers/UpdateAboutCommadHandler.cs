using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommadHandler
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutCommadHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAboutCommad commad)
        {
            var values = await _repository.GetByIdAsync(commad.AboutID);
            values.Description = commad.Description;
            values.Title = commad.Title;
            values.ImageUrl = commad.ImageUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
