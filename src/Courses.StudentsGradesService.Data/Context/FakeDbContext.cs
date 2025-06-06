using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Domain.DomainObjects;
using Courses.StudentsGradesService.Domain.Entities;
using Courses.StudentsGradesService.Domain.Enums;

namespace Courses.StudentsGradesService.Data.Context
{
    public class FakeDbContext : IDisposable, IUnitOfWork
    {
        public FakeDbContext()
        {
            Students = GetFakeStudents();
            Teachers = GetFakeTeachers();
            Subjects = GetFakeSubjects();
        }

        public ICollection<Student> Students { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Subject> Subjects { get; set; }

        private ICollection<Student> GetFakeStudents()
        {
            var students = new List<Student>();

            Student student = new(1234, "Raphael", "raphael.s@email.com", 1212, DateTime.Now);

            students.Add(student);

            return students;
        }

        private ICollection<Teacher> GetFakeTeachers()
        {
            var teachers = new List<Teacher>();

            var teacher = new Teacher(
                id: 1282727,
                abbreviatedName: "Danilo",
                internEmail: "danilo.s@email.com",
                isTenuredTeacher: true,
                isSubstituteTeacher: false,
                userId: 1212,
                createdAt: DateTime.Now
            );

            teachers.Add(teacher);

            return teachers;
        }

        private ICollection<Subject> GetFakeSubjects()
        {
            var subjects = new List<Subject>();

            var subject = new Subject("Mathematics", "High school level basic mathematics", new DateTime(2021, 10, 12), new DateTime(2022, 02, 12), SubjectType.Theoretical, 1282727, new DateTime(2021, 09, 12));

            var content = new Content("Quadratic Equations", "Learning second-degree equations", new DateTime(2021, 10, 18), new DateTime(2021, 11, 18), new DateTime(2021, 10, 15));

            var activity = new Activity(34545, "Quadratic equation evaluation activity", ActivityType.Evaluative, new DateTime(2021, 11, 10), new DateTime(2021, 11, 01), false);


            content.AddActivity(activity);
            subject.AddContents(content);
            subjects.Add(subject);

            return subjects;
        }

        public void Dispose()
        {
            Console.WriteLine("GC WORKED");
        }

        public async Task<bool> Commit() => await Task.FromResult(true);
    }

}