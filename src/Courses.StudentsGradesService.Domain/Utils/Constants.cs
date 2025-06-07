using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.StudentsGradesService.Domain.Utils
{
    public static class Constants
    {
        public static class ApplicationMessages
        {
            public const string NoMessagesInQueue = "There are no messages to be processed in the queue...";
            public const string StartingService = "Starting the grade service...";
            public const string NoChangesInProcessing = "No changes were made during this submission.";
        }

        public static class ExceptionMessages
        {
            public const string StudentNotFound = "The specified student does not exist.";
            public const string TeacherNotFound = "The specified teacher does not exist.";
            public const string SubjectNotFound = "The specified activity does not have an associated subject.";
        }

        public static class ValidationMessages
        {
            public const string StudentInactive = "The student is not active to receive grades.";
            public const string StudentNotEnrolled = "The student is not enrolled in the subject to receive grades for this activity.";
            public const string TeacherInactive = "The teacher is not active to submit grades.";
            public const string TeacherNotAssignedToSubject = "The teacher is not assigned to the subject to submit grades.";
            public const string TeacherMustBeMain = "To submit grades, the teacher must be the main instructor for the subject.";
            public const string SubjectSessionTypeNotAllowed = "A session-type subject cannot receive grades.";
            public const string SubjectInactive = "The subject is outside the grading period.";
        }
    }
}