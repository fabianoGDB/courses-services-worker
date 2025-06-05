using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace Courses.StudentsGradesService.Domain.Notification
{
    public class ContextNotification : IReadOnlyCollection<string>
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions = new()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        private readonly Collection<string> _notifications = new();

        public bool HasNotifications => _notifications.Any();

        public int Count => _notifications.Count;

        public void Add(string notification)
        {
            _notifications.Add(notification);
        }

        public void AddRange(IEnumerable<string> notifications)
        {
            foreach (var n in notifications)
            {
                _notifications.Add(n);
            }
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(_notifications, _jsonSerializerOptions);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _notifications.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => _notifications.GetEnumerator();
    }
}