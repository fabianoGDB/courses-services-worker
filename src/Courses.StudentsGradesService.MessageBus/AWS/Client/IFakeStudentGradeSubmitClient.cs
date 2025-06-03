using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Domain.Messages;

namespace Courses.StudentsGradesService.MessageBus.AWS.Client
{
    public interface IFakeStudentGradeSubmitClient : IQueueClient<RegisterStudentGrade>
    {

    }
}