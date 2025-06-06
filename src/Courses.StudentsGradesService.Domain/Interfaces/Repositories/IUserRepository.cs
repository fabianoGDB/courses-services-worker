using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Domain.DomainObjects;
using Courses.StudentsGradesService.Domain.Entities;

namespace Courses.StudentsGradesService.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<Student> FindStudentById(int id);
        Task<Teacher> FindTeacherById(int id);
    }
}