using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Domain.Messages;
using Courses.StudentsGradesService.MessageBus.Messages;

namespace Courses.StudentsGradesService.MessageBus.AWS.Client
{
    public class FakeStudentGradeSubmitClient : SqsClient<RegisterStudentGrade>, IFakeStudentGradeSubmitClient
    {
        private readonly Queue<QueueMessage<RegisterStudentGrade>> _messagesToRegister;

        public FakeStudentGradeSubmitClient()
        {
            _messagesToRegister = GetMessagesToProcess();
        }

        public override async Task<QueueMessage<RegisterStudentGrade>> GetMessageAsync()
        {
            return await Task.FromResult(_messagesToRegister.Dequeue());
        }

        private Queue<QueueMessage<RegisterStudentGrade>> GetMessagesToProcess()
        {
            var queue = new Queue<QueueMessage<RegisterStudentGrade>>();
            queue.Enqueue(

             new()
             {

                 MessageId = Guid.NewGuid().ToString(),
                 MessageHandle = Guid.NewGuid().ToString(),
                 ReceiveCount = 0,
                 Message = new RegisterStudentGrade
                 {
                     StudentId = 1234,
                     ActivityId = 34545,
                     CorrelationId = Guid.NewGuid(),
                     TeacherId = 1282727,
                     GradeValue = 10,
                     IsSubstituteGrade = false
                 }
             }
            );
            return queue;
        }


    }
}