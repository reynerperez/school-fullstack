using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Grade.Commands.Delete
{
    public class DeleteGradeCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
