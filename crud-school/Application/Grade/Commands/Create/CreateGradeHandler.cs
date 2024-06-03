using Infrastructure.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Grade.Commands.Create
{
    internal class CreateGradeHandler : IRequestHandler<CreateGradeCommand, int>
    {
        private readonly AppDbContext _context;
        public CreateGradeHandler(AppDbContext context) {
            _context = context;
        }

        public async Task<int> Handle(CreateGradeCommand request, CancellationToken cancellationToken)
        {
            var professor = await _context.Professor.FindAsync(request.ProfessorId);

            if (professor == null) { return 0; }
            var grade = new Domain.Entities.Grade() { Name = request.Name };
            await _context.Grade.AddAsync(grade);
            _context.SaveChanges();
            return grade.Id;
        }
    }
}
