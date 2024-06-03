using Application.Student.Commands.Create;
using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Student.Commands.Update
{
    internal class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, int>
    {
        private readonly AppDbContext _context;

        public UpdateStudentHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Student.FindAsync(request.Id);
            if (student != null)
            {
                DateOnly.TryParse(request.BirthDate, out var BirthDate);
                student.Name = request.Name;
                student.LastName = request.LastName;
                student.Gender = request.Gender[0];
                student.BirthDate = BirthDate;
                _context.SaveChanges();
            }
            
            return student != null ? student.Id : 0;
        }

    }
}
