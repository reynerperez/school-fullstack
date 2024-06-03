using Application.Student.Queries.Get;
using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Student.Queries.List
{
    internal class GetListStudentHandler : IRequestHandler<GetListStudentQuery, List<Domain.Entities.Student>>
    {
        private readonly AppDbContext _context;

        public GetListStudentHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entities.Student>> Handle(GetListStudentQuery request, CancellationToken cancellationToken)
        {
            return await _context.Student.ToListAsync();
        }
    }
}
