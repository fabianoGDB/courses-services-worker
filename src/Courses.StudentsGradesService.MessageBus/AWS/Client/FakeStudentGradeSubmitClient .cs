using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Domain.Messages;
using Courses.StudentsGradesService.Domain.Notification;
using Courses.StudentsGradesService.MessageBus.Messages;

namespace Courses.StudentsGradesService.MessageBus.AWS.Client
{
    public class FakeStudentGradeSubmitClient : SqsClient<RegisterStudentGrade>, IFakeStudentGradeSubmitClient
    {
        private readonly Queue<QueueMessage<RegisterStudentGrade>> _messagesToRegister;
        private readonly ContextNotification _contextNotification;

        public FakeStudentGradeSubmitClient(ContextNotification contextNotification)
        {
            _messagesToRegister = GetMessagesToProcess();
            _contextNotification = contextNotification;
        }

        public override async Task<QueueMessage<RegisterStudentGrade>> GetMessageAsync()
        {
            QueueMessage<RegisterStudentGrade> message = null;
            try
            {
                message = await Task.FromResult(_messagesToRegister.Dequeue());
            }
            catch (Exception ex)
            {
                _contextNotification.Add(ex.Message);
            }

            return message;

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
                 MessageBody = new RegisterStudentGrade
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