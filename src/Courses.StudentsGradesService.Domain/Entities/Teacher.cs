using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.StudentsGradesService.Domain.Entities
{
    public class Teacher : Entity
    {
        public Teacher(string abbreviatedName, string internEmail, bool isTenuredTeacher, bool isSubstituteTeacher, int userId, DateTime createdAt)
        {
            AbbreviatedName = abbreviatedName;
            InternEmail = internEmail;
            IsTenuredTeacher = isTenuredTeacher;
            IsSubstituteTeacher = isSubstituteTeacher;
            UserId = userId;
            CreatedAt = createdAt;
        }

        protected Teacher() { }

        public string AbbreviatedName { get; private set; }
        public string InternEmail { get; private set; }
        public bool IsTenuredTeacher { get; private set; }
        public bool IsSubstituteTeacher { get; private set; }
        public int UserId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public User User { get; private set; }
        public Subject Subject { get; private set; }
    }
}