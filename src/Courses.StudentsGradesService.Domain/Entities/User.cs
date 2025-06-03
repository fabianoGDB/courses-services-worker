using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Domain.DomainObjects;
using Courses.StudentsGradesService.Domain.ValueObjects;

namespace Courses.StudentsGradesService.Domain.Entities
{
    public class User : Entity, IAggregateRoot
    {
        public User(string name, string identificationDocument, DateTime birthDate, bool isActive, string email, Phone phone, int isAdministrative, DateTime createdAt)
        {
            Name = name;
            IdentificationDocument = identificationDocument;
            BirthDate = birthDate;
            IsActive = isActive;
            Email = email;
            Phone = phone;
            IsAdministrative = isAdministrative;
            CreatedAt = createdAt;
        }

        protected User() { }

        public string Name { get; private set; }
        public string IdentificationDocument { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool IsActive { get; private set; }
        public string Email { get; private set; }
        public Phone Phone { get; private set; }
        public int IsAdministrative { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Student Student { get; private set; }
        public Teacher Teacher { get; private set; }

    }
}