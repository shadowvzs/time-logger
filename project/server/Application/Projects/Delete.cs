using Application.Errors;
using Domain;
using Persistence;

using MediatR;
using Microsoft.EntityFrameworkCore;

using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Projects
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {

                var item = await _context.Projects.FindAsync(request.Id);

                if (item == null)
                    throw new RestException(HttpStatusCode.NotFound, new { Project = "Could not find project" } );
   
   
                _context.Projects.Remove(item);

                if (await _context.SaveChangesAsync() == 0) {
                    throw new RestException(HttpStatusCode.InternalServerError, new { Project = "Problem saving changes" });
                }

                return Unit.Value;
            }
        }

    }
}