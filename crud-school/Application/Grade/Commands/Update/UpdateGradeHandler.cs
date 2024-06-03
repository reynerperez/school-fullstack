using Infrastructure.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Grade.Commands.Update
{
    internal class UpdateGradeHandler : IRequestHandler<UpdateGradeCommand, int>
    {
        private readonly AppDbContext _context;
        public UpdateGradeHandler(AppDbContext context) {
            _context = context;
        }

        public async Task<int> Handle(UpdateGradeCommand request, CancellationToken cancellationToken)
        {
            var grade = await _context.Grade.FindAsync(request.Id);
            var professor = await _context.Professor.FindAsync(request.Id);
            if (grade != null && professor != null)
            {

                grade.Name = request.Name;
                grade.Professor = professor;
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }
    }
}
