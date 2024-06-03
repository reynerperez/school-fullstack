using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public char Gender { get; set; }
        public DateOnly BirthDate { get; set; }
        public List<Grade>? Grades { get; } = [];
    }
}
