using Application.Student.Commands.Create;
using Infrastructure.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Professor.Commands.Create
{
    internal class CreateProfessorHandler : IRequestHandler<CreateProfessorCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateProfessorHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProfessorCommand request, CancellationToken cancellationToken)
        {
            var professor = new Domain.Entities.Professor() { Name = request.Name, LastName = request.LastName, Gender = request.Gender[0] };
            await _context.Professor.AddAsync(professor);
            _context.SaveChanges();
            return professor.Id;
        }
    }
}
