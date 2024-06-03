using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Grade.Commands.Create
{
    public class CreateGradeCommand: IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public int ProfessorId { get; set; }
    }
}
