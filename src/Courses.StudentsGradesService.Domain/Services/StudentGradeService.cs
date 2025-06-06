using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Domain.Entities;
using Courses.StudentsGradesService.Domain.Excpetions;
using Courses.StudentsGradesService.Domain.Interfaces;
using Courses.StudentsGradesService.Domain.Interfaces.Repositories;
using Courses.StudentsGradesService.Domain.Interfaces.Services;
using Courses.StudentsGradesService.Domain.Messages;
using Courses.StudentsGradesService.Domain.Notification;
using static Courses.StudentsGradesService.Domain.Utils.Constants;

namespace Courses.StudentsGradesService.Domain.Services
{
    public class StudentGradeService : IStudentGradeService
    {
        private readonly ContextNotification _contextNotification;
        private readonly IUserRepository _userRepository;
        private readonly ISubjectRepository _subjectRepository;

        public StudentGradeService(ContextNotification contextNotification, IUserRepository userRepository, ISubjectRepository subjectRepository)
        {
            _contextNotification = contextNotification;
            _userRepository = userRepository;
            _subjectRepository = subjectRepository;
        }

        public async Task SubmitGradeAsync(RegisterStudentGrade registerStudentGrade)
        {

            Console.WriteLine("Processing business logic...");
            if (!registerStudentGrade.MessageIsValid())
            {
                AddErrorMessagesToContext(registerStudentGrade);
                return;
            }

            var (student, teacher, subject) = await SearchStudentTeacherSubject(registerStudentGrade);


        }


        private async Task<(Student student, Teacher teacher, Subject subject)> SearchStudentTeacherSubject(RegisterStudentGrade registerStudentGrade)
        {
            var student = (await _userRepository.FindStudentById(registerStudentGrade.StudentId))
            ?? throw new DomainException(ExceptionsMessages.STUDENT_NOT_FOUND);
            var teacher = (await _userRepository.FindTeacherById(registerStudentGrade.TeacherId))
            ?? throw new DomainException(ExceptionsMessages.TEACHER_NOT_FOUND);
            var subject = (await _subjectRepository.FindSubjectByAtivityId(registerStudentGrade.ActivityId))
             ?? throw new DomainException(ExceptionsMessages.SUBJECT_NOT_FOUND);

            return (student, teacher, subject);
        }

        private void AddErrorMessagesToContext(RegisterStudentGrade registerStudentGrade)
        {
            _contextNotification.AddRange(registerStudentGrade.ValidationResult.Errors.Select(msg => msg.ErrorMessage));
        }


    }
}