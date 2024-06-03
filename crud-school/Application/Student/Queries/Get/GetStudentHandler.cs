using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Student.Queries.Get
{
    internal class GetStudentHandler : IRequestHandler<GetStudentQuery, Domain.Entities.Student?>
    {
        private readonly AppDbContext _context;

        public GetStudentHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Student?> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            return await _context.Student.FindAsync(request.Id);
        }
    }
}
