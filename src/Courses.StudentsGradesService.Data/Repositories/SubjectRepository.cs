using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Data.Context;
using Courses.StudentsGradesService.Domain.DomainObjects;
using Courses.StudentsGradesService.Domain.Entities;
using Courses.StudentsGradesService.Domain.Interfaces.Repositories;

namespace Courses.StudentsGradesService.Data.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly FakeDbContext _context;

        public SubjectRepository(FakeDbContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<Subject> FindSubjectByAtivityId(int activityId)
            => await Task.FromResult(_context.Subjects.FirstOrDefault(
            x => x.Contents.SelectMany(y => y.Activities).Any(y => y.Id == activityId)));
    }
}