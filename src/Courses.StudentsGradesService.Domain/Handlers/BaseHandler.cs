using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Domain.Handlers.Interfaces;

namespace Courses.StudentsGradesService.Domain.Handlers
{
    public abstract class BaseHandler<T> : IHandler<T>
    {
        private IHandler<T> _nextHandler;
        public virtual void Handle(T request)
        {
            throw new NotImplementedException();
        }

        public IHandler<T> SetNext(IHandler<T> handler)
        {
            _nextHandler = handler;
            return handler;
        }
    }
}