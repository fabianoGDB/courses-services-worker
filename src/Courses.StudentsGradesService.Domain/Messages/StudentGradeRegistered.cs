using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Domain.Interfaces.DomainObjects;

namespace Courses.StudentsGradesService.Domain.Messages
{
    public class StudentGradeRegistered : Message
    {
        public StudentGradeRegistered()
        {
            Errors = new();
        }

        public int StudentId { get; set; }

        public int ActivityId { get; set; }

        public bool HasErrors { get; set; }

        public Guid CorrelationId { get; set; }

        public List<string> Errors { get; set; }

        public override bool MessageIsValid()
        {
            if (HasErrors || Errors.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}