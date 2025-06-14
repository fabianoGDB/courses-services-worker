using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Application.Interfaces;
using Courses.StudentsGradesService.Domain.Excpetions;
using Courses.StudentsGradesService.Domain.Interfaces.Services;
using Courses.StudentsGradesService.Domain.Messages;

namespace Courses.StudentsGradesService.Application.Services
{
    public class StudentGradeApplicationService : IStudentGradeApplicationService
    {
        private readonly IStudentGradeService _studentGradeService;
        public StudentGradeApplicationService(IStudentGradeService studentGradeService)
        {
            _studentGradeService = studentGradeService;
        }
        public async Task ProcessStudentGradeSubmitAsync(RegisterStudentGrade registerStudentGrade)
        {
            try
            {
                Console.WriteLine($"Orchestrating the application flow");
                await _studentGradeService.SubmitGradeAsync(registerStudentGrade);
            }
            catch (DomainException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

        }


    }
}