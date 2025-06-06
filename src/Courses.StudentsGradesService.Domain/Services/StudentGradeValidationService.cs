using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Domain.Entities;
using Courses.StudentsGradesService.Domain.Interfaces.Services;

namespace Courses.StudentsGradesService.Domain.Services
{
    public class StudentGradeValidationService : IStudentGradeValidationService
    {
        public async Task ValidateSubmit(Student student, Teacher teacher, Subject subject)
        {
            ValidateTeacher(teacher);
            ValidateStudent(student);
            ValidateSubject(subject);
        }

        private void ValidateSubject(Subject subject)
        {
            throw new NotImplementedException();
        }

        private void ValidateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        private void ValidateTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}