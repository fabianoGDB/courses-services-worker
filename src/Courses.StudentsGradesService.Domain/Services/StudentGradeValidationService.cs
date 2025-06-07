using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Domain.Entities;
using Courses.StudentsGradesService.Domain.Enums;
using Courses.StudentsGradesService.Domain.Handlers.Interfaces;
using Courses.StudentsGradesService.Domain.Handlers.Request;
using Courses.StudentsGradesService.Domain.Interfaces.Services;
using Courses.StudentsGradesService.Domain.Notification;
using Courses.StudentsGradesService.Domain.Utils;

namespace Courses.StudentsGradesService.Domain.Services
{
    public class StudentGradeValidationService : IStudentGradeValidationService
    {
        private readonly ContextNotification _notificationContext;
        private readonly IHandler<StudentGradeValidationRequest> _validationHandler;

        public StudentGradeValidationService(ContextNotification notificationContext,
                                             IHandler<StudentGradeValidationRequest> validationHandler)
        {
            _notificationContext = notificationContext;
            _validationHandler = validationHandler;
        }

        private bool ValidateTeacher(Teacher teacher, int subjectId)
        {
            if (!teacher.IsActive)
            {
                _notificationContext.Add(Constants.ValidationMessages.TeacherInactive);
                return false;
            }

            if (teacher.Subject.Id != subjectId)
            {
                _notificationContext.Add(Constants.ValidationMessages.TeacherNotAssignedToSubject);
                return false;
            }

            if (!teacher.IsTenuredTeacher && teacher.IsSubstituteTeacher)
            {
                _notificationContext.Add(Constants.ValidationMessages.TeacherMustBeMain);
                return false;
            }

            return true;
        }

        private bool ValidateSubject(Subject subject)
        {
            if (subject.SubjectType == SubjectType.Meeting)
            {
                _notificationContext.Add(Constants.ValidationMessages.SubjectSessionTypeNotAllowed);
                return false;
            }

            if (!IsSubjectActive(subject))
            {
                _notificationContext.Add(Constants.ValidationMessages.SubjectInactive);
                return false;
            }

            return true;
        }

        private bool ValidateStudent(Student student, int subjectId)
        {
            if (!student.IsActive)
            {
                _notificationContext.Add(Constants.ValidationMessages.StudentInactive);
                return false;
            }

            if (!IsStudentEnrolled(student, subjectId))
            {
                _notificationContext.Add(Constants.ValidationMessages.StudentNotEnrolled);
                return false;
            }

            return true;
        }

        private bool IsSubjectActive(Subject subject) =>
            subject.StartDate <= DateTime.Now && subject.EndDate >= DateTime.Now;

        private bool IsStudentEnrolled(Student student, int subjectId) =>
            student.StudentClasses
                   .Select(sc => sc.Classes)
                   .Any(c => c.SubjectId == subjectId);

        public void ValidateSubmission(Student student, Teacher teacher, Subject subject)
        {
            if (!ValidateStudent(student, subject.Id)) return;
            if (!ValidateTeacher(teacher, subject.Id)) return;
            ValidateSubject(subject);
        }

        public void ValidateSubmit(StudentGradeValidationRequest request)
        {
            _validationHandler.Handle(request);
        }
    }
}