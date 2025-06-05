using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Domain.Messages;

namespace Courses.StudentsGradesService.Application.Interfaces
{
    public interface IStudentGradeApplicationService
    {
        Task ProcessStudentGradeSubmitAsync(RegisterStudentGrade registerStudentGrade);
    }
}