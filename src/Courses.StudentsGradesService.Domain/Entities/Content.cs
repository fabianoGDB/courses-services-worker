using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.StudentsGradesService.Domain.Entities
{
    public class Content : Entity
    {
        public Content(string name, string description, DateTime startDate, DateTime endDate, DateTime createdAt)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            CreatedAt = createdAt;
            Activities = new List<Activity>();
        }

        protected Content() { }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Subject Subject { get; private set; }

        public ICollection<Activity> Activities { get; private set; }

    }
}