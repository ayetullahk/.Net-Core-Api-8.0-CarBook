using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.CategoryCommand
{
    public class UpdateCategoryCommand
    {
        public int CategortID { get; set; }
        public string Name { get; set; }
    }
}
