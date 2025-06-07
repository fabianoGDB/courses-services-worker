using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Domain.Entities;

namespace Courses.StudentsGradesService.Domain.Handlers.Request
{
    public class StudentGradeValidationRequest
    {
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }
    }
}