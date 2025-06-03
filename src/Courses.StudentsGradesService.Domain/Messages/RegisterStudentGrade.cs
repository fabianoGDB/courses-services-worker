using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Domain.Interfaces.DomainObjects;

namespace Courses.StudentsGradesService.Domain.Messages
{
    public class RegisterStudentGrade : Message
    {
        public int StudentId { get; set; }

        public int TeacherId { get; set; }

        public int ActivityId { get; set; }

        public Guid CorrelationId { get; set; }

        public double GradeValue { get; set; }

        public bool IsSubstituteGrade { get; set; }

        public override bool MessageIsValid()
        {
            return base.MessageIsValid();
        }
    }
}