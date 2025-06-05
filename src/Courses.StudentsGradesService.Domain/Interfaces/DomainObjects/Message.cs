using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Courses.StudentsGradesService.Domain.Interfaces.DomainObjects
{
    public abstract class Message
    {
        public DateTime MessageCreatedAt { get; protected set; }
        public ValidationResult ValidationResult { get; protected set; }
        public Message()
        {
        }

        public virtual bool MessageIsValid()
        {
            throw new NotImplementedException();
        }
    }
}