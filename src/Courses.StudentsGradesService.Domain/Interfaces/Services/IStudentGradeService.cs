using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Domain.Messages;

namespace Courses.StudentsGradesService.Domain.Interfaces.Services
{
    public interface IStudentGradeService
    {
        Task SubmitGradeAsync(RegisterStudentGrade registerStudentGrade);
    }
}