using Infrastructure.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Grade.Commands.Delete
{
    internal class DeleteGradeHandler : IRequestHandler<DeleteGradeCommand, int>
    {
        private readonly AppDbContext _context;
        public DeleteGradeHandler(AppDbContext context) {
            _context = context;
        }

        public async Task<int> Handle(DeleteGradeCommand request, CancellationToken cancellationToken)
        {
            var grade = await _context.Grade.FindAsync(request.Id);
            if (grade != null)
            {
                _context.Grade.Remove(grade);
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }
    }
}
