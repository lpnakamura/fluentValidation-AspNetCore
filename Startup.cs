using System.Collections.Generic;
using CQSSample.CommandHandlers;
using CQSSample.Commands;
using CQSSample.Data;
using CQSSample.Domain.Entity;
using CQSSample.Domain.Notification;
using CQSSample.Domain.Queries;
using CQSSample.Domain.QueryHandlers;
using CQSSample.Infra.BehaviorMediatR;
using CQSSample.Infra.Repository;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CQSSample {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices (IServiceCollection services) {
            services.AddDbContext<DataContext> (options =>
                options.UseInMemoryDatabase ("InMemoryDatabase"));
            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_2).
            AddFluentValidation (fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidation> ());

            services.AddScoped (typeof (IPipelineBehavior<,>), typeof (ValidationRequestBehavior<,>));
            services.AddMediatR (typeof (Startup));
            services.AddScoped<IDomainNotificationContext, DomainNotificationContext> ();
            services.AddScoped<IUserRepository, UserRepository> ();
            services.AddScoped<AsyncRequestHandler<CreateUserCommand>, UserCommandHandler> ();
            services.AddScoped<IRequestHandler<GetPagedUsersQuery, IEnumerable<UserEntity>>, UserQueryHandler > ();
        }

        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseHsts ();
            }

            app.UseHttpsRedirection ();
            app.UseMvc ();
        }
    }
}