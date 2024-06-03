using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Grade.Queries.List
{
    public class GetListGradeQuery: IRequest<List<Domain.Entities.Grade>>
    {
    }
}
