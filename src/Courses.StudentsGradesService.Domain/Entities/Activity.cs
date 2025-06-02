using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Domain.Enums;

namespace Courses.StudentsGradesService.Domain.Entities
{
    public class Activity : Entity
    {
        public Activity(string description, ActivityType activityType, DateTime activityDate, DateTime createdAt, bool hasRetake)
        {
            Description = description;
            ActivityType = activityType;
            ActivityDate = activityDate;
            CreatedAt = createdAt;
            HasRetake = hasRetake;
            Grades = new List<Grade>();
        }

        protected Activity() { }

        public string Description { get; private set; }

        public ActivityType ActivityType { get; private set; }

        public DateTime ActivityDate { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public bool HasRetake { get; private set; }
        public Content Content { get; private set; }
        public ICollection<Grade> Grades { get; private set; }
    }
}