using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Student.Queries.List
{
    public class GetListStudentQuery : IRequest<List<Domain.Entities.Student>>
    {
    }
}
