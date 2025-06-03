using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.StudentsGradesService.Domain.Interfaces.DomainObjects
{
    public abstract class Message
    {
        public DateTime MessageCreatedAt { get; set; }
        public Message()
        {
        }

        public virtual bool MessageIsValid()
        {
            throw new NotImplementedException();
        }
    }
}