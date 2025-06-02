using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.StudentsGradesService.Domain.Entities
{
    public class Grade : Entity
    {
        public Grade(int studentId, int activityId, decimal value, DateTime postingDate, int userId, bool isCanceledDueToRetake)
        {
            StudentId = studentId;
            ActivityId = activityId;
            Value = value;
            PostingDate = postingDate;
            UserId = userId;
            IsCanceledDueToRetake = isCanceledDueToRetake;
        }

        protected Grade() { }
        public int StudentId { get; private set; }
        public int ActivityId { get; private set; }
        public decimal Value { get; private set; }
        public DateTime PostingDate { get; private set; }
        public int UserId { get; private set; }
        public bool IsCanceledDueToRetake { get; private set; }
        public Student Student { get; set; }
        public Activity Activity { get; set; }
    }
}