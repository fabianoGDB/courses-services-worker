using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.MessageBus.Messages;

namespace Courses.StudentsGradesService.MessageBus.AWS.Client
{
    public class SqsClient<T> : IQueueClient<T>
    {
        public virtual Task DeleteMessageAsync(string messageHandle)
        {
            throw new NotImplementedException();
        }

        public virtual Task<QueueMessage<T>> GetMessageAsync()
        {
            throw new NotImplementedException();
        }

        public virtual Task<List<QueueMessage<T>>> GetMessageAsync(int count)
        {
            throw new NotImplementedException();
        }

        public virtual Task SendMessageAsync(T message)
        {
            throw new NotImplementedException();
        }

        public virtual Task SendMessageAsync(List<T> messageList)
        {
            throw new NotImplementedException();
        }
    }
}