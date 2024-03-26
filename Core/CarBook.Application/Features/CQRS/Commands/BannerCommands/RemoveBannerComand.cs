using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.BannerCommands
{
    public class RemoveBannerComand
    {
        public int Id { get; set; }

        public RemoveBannerComand(int id)
        {
            Id = id;
        }
    }
}
