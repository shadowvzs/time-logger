using Domain;
using Persistence;
using Application.Errors;

using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Application.Projects
{
    public class Edit
    {
        public class Command : IRequest<Project>
        {
            public Guid Id { get; set; }
            public DateTime Deadline { get; set; }
            public Guid CompanyId { get; set; }
            public string Name { get; set; }
            public bool Completed { get; set; }
            public List<TimeLog> Logs { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.CompanyId).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command, Project>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Project> Handle(Command request, CancellationToken cancellationToken)
            {

                var project = await _context.Projects.FindAsync(request.Id);

                if (project == null) {
                    throw new RestException(HttpStatusCode.NotFound, new { Project = "Not found" });
                }

                project.Deadline = request.Deadline;
                project.CompanyId = request.CompanyId;
                project.Name = request.Name;
                project.Completed = request.Completed;
                
                // ideal case should be go over on existing logs and update them and not delete all then readd them
                var deletedTimeLogs = project.Logs;
                if (deletedTimeLogs.Count > 0) {
                    _context.TimeLogs.RemoveRange(deletedTimeLogs);
                    await _context.SaveChangesAsync();
                }

                if (request.Logs.Count > 0) {
                    _context.TimeLogs.AddRange(request.Logs
                        .Select(x => new TimeLog() { 
                            Id = x.Id,
                            LoggedMinutes = x.LoggedMinutes,
                            CreatedAt = x.CreatedAt,
                            ProjectId = x.ProjectId
                        }
                    )
                    .ToList());
                    await _context.SaveChangesAsync();
                }
                
                return project;
            }
        }
    }
}