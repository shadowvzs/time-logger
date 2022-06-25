using Domain;
using Persistence;
using Application.Errors;

using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

using System;
using System.Net;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Application.Projects
{
    public class Create
    {
        public class Command : IRequest<Project>
        {
            public Guid Id { get; set; }
            public DateTime Deadline { get; set; }
            public Guid CompanyId { get; set; }
            public string Name { get; set; }
            public bool Completed { get; set; }
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

                var company = await _context.Companies.FindAsync(request.CompanyId);
                if (company == null) {
                    throw new RestException(HttpStatusCode.NotFound, new { Company = "Could not find company" } );
                }

                var project = new Project
                {
                    Id = request.Id,
                    Deadline = request.Deadline,
                    CompanyId = request.CompanyId,
                    Company = company,
                    Name = request.Name,
                    Completed = request.Completed,
                    Logs = new List<TimeLog>()
                };

                _context.Projects.Add(project);

                if (await _context.SaveChangesAsync() == 0) {
                    throw new RestException(HttpStatusCode.InternalServerError, new { Project = "Problem saving changes" });
                }
                
                return project;
            }
        }
    }
}