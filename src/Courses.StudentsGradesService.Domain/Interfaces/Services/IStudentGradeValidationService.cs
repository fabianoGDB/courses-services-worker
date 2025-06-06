using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Domain.Entities;

namespace Courses.StudentsGradesService.Domain.Interfaces.Services
{
    public interface IStudentGradeValidationService
    {
        Task ValidateSubmit(Student student, Teacher teacher, Subject subject);
    }
}