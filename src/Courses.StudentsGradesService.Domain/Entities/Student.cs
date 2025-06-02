using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.StudentsGradesService.Domain.Entities
{
    public class Student : Entity
    {
        public string AbbreviatedName { get; private set; }
        public string InternEmail { get; private set; }
        public int UserId { get; private set; }
    }
}