using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Domain.DomainObjects;
using Courses.StudentsGradesService.Domain.Entities;

namespace Courses.StudentsGradesService.Domain.Interfaces
{
    public interface IUserRpository : IRepository<User>
    {
        IUnitOfWork UnitOfWork => throw new NotImplementedException();
        public void Dispose()
        {

        }
    }
}