using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Data.Context;
using Courses.StudentsGradesService.Domain.DomainObjects;
using Courses.StudentsGradesService.Domain.Entities;
using Courses.StudentsGradesService.Domain.Interfaces;

namespace Courses.StudentsGradesService.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FakeDbContext _context;

        public UserRepository(FakeDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<Student> FindStudentById(int id) =>
            await Task.FromResult(_context.Students.FirstOrDefault(x => x.Id == id));

        public async Task<Teacher> FindTeacherById(int id) =>
            await Task.FromResult(_context.Teachers.FirstOrDefault(x => x.Id == id));
    }
}