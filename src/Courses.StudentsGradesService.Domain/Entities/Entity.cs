using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.StudentsGradesService.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
    }
}