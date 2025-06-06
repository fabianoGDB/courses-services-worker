using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.StudentsGradesService.Domain.Excpetions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {

        }

        public DomainException(string message, Exception innerException) : base(message, innerException)
        {

        }

    }
}