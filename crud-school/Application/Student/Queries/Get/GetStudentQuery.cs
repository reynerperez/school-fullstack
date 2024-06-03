using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Student.Queries.Get
{
    public class GetStudentQuery : IRequest<Domain.Entities.Student>
    {
        public int Id { get; set; }
    }
}
