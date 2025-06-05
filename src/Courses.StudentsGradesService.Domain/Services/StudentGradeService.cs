using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Domain.Interfaces.Services;
using Courses.StudentsGradesService.Domain.Messages;
using Courses.StudentsGradesService.Domain.Notification;

namespace Courses.StudentsGradesService.Domain.Services
{
    public class StudentGradeService : IStudentGradeService
    {
        private readonly ContextNotification _contextNotification;

        public StudentGradeService(ContextNotification contextNotification)
        {
            _contextNotification = contextNotification;
        }

        public async Task SubmitGradeAsync(RegisterStudentGrade registerStudentGrade)
        {

            Console.WriteLine("Processing business logic...");
            if (registerStudentGrade.MessageIsValid())
            {
                _contextNotification.AddRange(registerStudentGrade.ValidationResult.Errors.Select(msg => msg.ErrorMessage));
                return;
            }

        }


    }
}