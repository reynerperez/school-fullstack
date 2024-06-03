using Application.Grade.Queries.List;
using Domain.Entities;
using Infrastructure.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Grade.Queries.Get
{
    public class GetGradeHandler : IRequestHandler<GetGradeQuery, Domain.Entities.Grade?>
    {
        private readonly AppDbContext _context;

        public GetGradeHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Grade?> Handle(GetGradeQuery request, CancellationToken cancellationToken)
        {
            return await _context.Grade.FindAsync(request.Id);
        }
    }
}
