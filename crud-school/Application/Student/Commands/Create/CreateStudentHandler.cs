using Domain.Entities;
using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Student.Commands.Create
{
    internal class CreateStudentHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateStudentHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            DateOnly.TryParse(request.BirthDate, out var BirthDate);
            var student = new Domain.Entities.Student() { Name = request.Name, LastName = request.LastName, Gender = request.Gender[0], BirthDate = BirthDate };
            await _context.Student.AddAsync(student);
            _context.SaveChanges();
            return student.Id;
        }
    }
}
