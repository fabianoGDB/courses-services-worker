using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.StudentsGradesService.Domain.Utils
{
    public static class Constants
    {
        public static class ApplicationsMessages
        {
            public const string NO_MESSAGES_IN_QUEUE = "Queue dont have messages to be precessed...";
            public const string STARTING_SERVICE = "Starting the student garde service...";
        }

        public static class ExceptionsMessages
        {
            public const string STUDENT_NOT_FOUND = "Student not found";
            public const string TEACHER_NOT_FOUND = "Teacher not found";
            public const string SUBJECT_NOT_FOUND = "Subject not found";
        }
    }
}