using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Grade.Queries.Get
{
    public class GetGradeQuery : IRequest<Domain.Entities.Grade?>
    {
        public int Id { get; set; } 
    }
}
