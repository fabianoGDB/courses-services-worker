using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Domain.Entities;
using Courses.StudentsGradesService.Domain.Handlers.Request;

namespace Courses.StudentsGradesService.Domain.Interfaces.Services
{
    public interface IStudentGradeValidationService
    {
        void ValidateSubmission(Student student, Teacher teacher, Subject subject);
        void ValidateSubmission(StudentGradeValidationRequest request);
    }
}