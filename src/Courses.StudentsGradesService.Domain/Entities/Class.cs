using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Domain.Enums;

namespace Courses.StudentsGradesService.Domain.Entities
{
    public class Class : Entity
    {
        public Class(string name, DayPeriod dayPeriod, DateTime startDate, DateTime endDate, DateTime createdAt, int subjectId)
        {
            Name = name;
            DayPeriod = dayPeriod;
            StartDate = startDate;
            EndDate = endDate;
            CreatedAt = createdAt;
            SubjectId = subjectId;
            StudentClasses = new List<StudentClass>();
        }

        protected Class() { }

        public string Name { get; private set; }

        public DayPeriod DayPeriod { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public int SubjectId { get; private set; }
        public Subject Subject { get; private set; }
        public ICollection<StudentClass> StudentClasses { get; private set; }

    }
}