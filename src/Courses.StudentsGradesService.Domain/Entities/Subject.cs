using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Domain.Enums;

namespace Courses.StudentsGradesService.Domain.Entities
{
    public class Subject : Entity
    {
        public Subject(string name, string description, DateTime startDate, DateTime endDate, SubjectType subjectType, int teacherId, DateTime createdAt)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            SubjectType = subjectType;
            TeacherId = teacherId;
            CreatedAt = createdAt;
            Contents = new List<Content>();
        }

        protected Subject() { }
        public string Name { get; private set; }

        public string Description { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public SubjectType SubjectType { get; private set; }

        public int TeacherId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Teacher Teacher { get; private set; }
        public ICollection<Content> Contents { get; private set; }
    }
}