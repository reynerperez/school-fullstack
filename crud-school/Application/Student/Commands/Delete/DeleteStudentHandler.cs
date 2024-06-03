using Infrastructure.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Student.Commands.Delete
{
    internal class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, int>
    {
        private readonly AppDbContext _context;

        public DeleteStudentHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Student.FindAsync(request.Id);
            if (student != null)
            {
                _context.Student.Remove(student);
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }
    }
}
