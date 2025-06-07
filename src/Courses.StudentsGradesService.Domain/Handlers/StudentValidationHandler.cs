using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Domain.Handlers.Request;

namespace Courses.StudentsGradesService.Domain.Handlers
{
    public class StudentValidationHandler : BaseHandler<StudentGradeValidationRequest>
    {
        public override void Handle(StudentGradeValidationRequest request)
        {
            base.Handle(request);
        }
    }
}