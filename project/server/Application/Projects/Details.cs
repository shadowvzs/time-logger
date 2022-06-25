using Domain;
using Persistence;
using Application.Errors;

using MediatR;
using AutoMapper;

using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Projects
{
    public class Details
    {
        public class Query : IRequest<Project>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Project>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Project> Handle(Query request, CancellationToken cancellationToken)
            {
                var item = await _context.Projects.FindAsync(request.Id);

                if (item == null) {
                    throw new RestException(HttpStatusCode.NotFound, new { Project = "Could not find project" } );
                }

                return item;
            }
        }
    }
}