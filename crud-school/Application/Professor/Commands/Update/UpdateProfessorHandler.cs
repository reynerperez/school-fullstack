using Application.Student.Commands.Update;
using Infrastructure.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Professor.Commands.Update
{
    internal class UpdateProfessorHandler : IRequestHandler<UpdateProfessorCommand, int>
    {
        private readonly AppDbContext _context;

        public UpdateProfessorHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateProfessorCommand request, CancellationToken cancellationToken)
        {
            var professor = await _context.Professor.FindAsync(request.Id);
            if (professor != null)
            {
                professor.Name = request.Name;
                professor.LastName = request.LastName;
                professor.Gender = request.Gender[0];
                _context.SaveChanges();
            }

            return professor != null ? professor.Id : 0;
        }
    }
}
