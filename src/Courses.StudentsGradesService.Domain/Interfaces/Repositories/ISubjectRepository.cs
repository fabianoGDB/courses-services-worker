using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Domain.DomainObjects;
using Courses.StudentsGradesService.Domain.Entities;

namespace Courses.StudentsGradesService.Domain.Interfaces.Repositories
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        Task<Subject> FindSubjectByAtivityId(int activityId);
    }
}