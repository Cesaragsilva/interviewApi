using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Interview.Application.Interfaces;
using Interview.Application.Services;
using Interview.Core.Interfaces.Repository;
using Interview.Core.Notifications;
using Interview.Infrastructure.Persistence.Context;
using Interview.Infrastructure.Persistence.Repository;

namespace Interview.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services) {
            services.AddDbContext<InterviewDbContext>(opt => opt.UseInMemoryDatabase("InterviewDb"));
            services.AddScoped(typeof(IBaseRepository<>),typeof(BaseRepository<>));
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ICandidateServiceApplication, CandidateServiceApplication>();
            services.AddScoped<IInterviewerServiceApplication, InterviewerServiceApplication>();
            services.AddScoped<NotificationService>();
            return services;
        }
    }
}