using Application.Student.Queries.Get;
using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Grade.Queries.List
{
    internal class GetListGradeHandler : IRequestHandler<GetListGradeQuery, List<Domain.Entities.Grade>>
    {
        private readonly AppDbContext _context;

        public GetListGradeHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entities.Grade>> Handle(GetListGradeQuery request, CancellationToken cancellationToken)
        {
            return await _context.Grade.ToListAsync();
        }
    }
}
