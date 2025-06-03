using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.StudentsGradesService.MessageBus.Messages
{
    public class QueueMessage<T>
    {
        public string MessageId { get; set; }
        public string MessageHandle { get; set; }
        public T Message { get; set; }
        public int ReceiveCount { get; set; }
    }
}