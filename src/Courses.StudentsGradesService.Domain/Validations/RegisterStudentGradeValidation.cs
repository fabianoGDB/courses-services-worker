using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Domain.Messages;
using FluentValidation;

namespace Courses.StudentsGradesService.Domain.Validations
{
    public class RegisterStudentGradeValidation : AbstractValidator<RegisterStudentGrade>
    {
        public static RegisterStudentGradeValidation Instance => new RegisterStudentGradeValidation();
        public static string StudentIdErrorMsg => "Student Id is not valid";
        public static string TeacherIdErrorMsg => "Teacher Id is not valid";
        public static string ActivityIdErrorMsg => "Activity Id is not valid";
        public static string CorrelationIdErrorMsg => "Transaction Id is not valid";
        public static string GradeValueErrorMsg => "The grade value cant be negative";
        public RegisterStudentGradeValidation()
        {
            RuleFor(x => x.StudentId).GreaterThan(default(int)).WithMessage(StudentIdErrorMsg);
            RuleFor(x => x.TeacherId).GreaterThan(default(int)).WithMessage(TeacherIdErrorMsg);
            RuleFor(x => x.ActivityId).GreaterThan(default(int)).WithMessage(ActivityIdErrorMsg);
            RuleFor(x => x.CorrelationId).NotNull().NotEqual(Guid.Empty).WithMessage(CorrelationIdErrorMsg);

            RuleFor(x => x.GradeValue).GreaterThan(default(int)).WithMessage(GradeValueErrorMsg);
        }
    }
}