using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses.StudentsGradesService.Application.Interfaces;
using Courses.StudentsGradesService.Application.Services;
using Courses.StudentsGradesService.Data.Context;
using Courses.StudentsGradesService.Data.Repositories;
using Courses.StudentsGradesService.Domain.Interfaces;
using Courses.StudentsGradesService.Domain.Interfaces.Repositories;
using Courses.StudentsGradesService.Domain.Interfaces.Services;
using Courses.StudentsGradesService.Domain.Notification;
using Courses.StudentsGradesService.Domain.Services;
using Courses.StudentsGradesService.MessageBus.AWS.Client;
using Microsoft.Extensions.DependencyInjection;

namespace Courses.StudentsGradesService.IOC
{
    public static class BootStrapper
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
        {
            RegisterServices(services);
            RegisterRepositories(services);
            RegisterDbContexts(services);
            RegisterQueues(services);
            RegisterNotificationContext(services);
            return services;
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IStudentGradeApplicationService, StudentGradeApplicationService>();
            services.AddScoped<IStudentGradeService, StudentGradeService>();
            services.AddScoped<IStudentGradeValidationService, StudentGradeValidationService>();
        }

        private static void RegisterDbContexts(IServiceCollection services)
        {
            services.AddScoped<FakeDbContext>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        private static void RegisterQueues(IServiceCollection services)
        {
            services.AddScoped<IFakeStudentGradeSubmitClient, FakeStudentGradeSubmitClient>();
        }

        private static void RegisterNotificationContext(IServiceCollection services)
        {
            services.AddScoped<ContextNotification>();
        }


    }
}