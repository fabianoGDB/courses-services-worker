using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.MessageBus.Messages;

namespace Courses.StudentsGradesService.MessageBus.AWS.Client
{
    public interface IQueueClient<T>
    {
        Task SendMessageAsync(T message);

        Task SendMessageAsync(List<T> messageList);

        Task<QueueMessage<T>> GetMessageAsync();

        Task<List<QueueMessage<T>>> GetMessageAsync(int count);

        Task DeleteMessageAsync(string messageHandle);

    }
}