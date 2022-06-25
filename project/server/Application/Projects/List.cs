using Domain;
using Persistence;

using MediatR;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Application.Projects
{
    public class List
    {
        public class Query : IRequest<List<Project>>
        {
        }

        public class Handler : IRequestHandler<Query, List<Project>>
        {

            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;            
            }

            public async Task<List<Project>> Handle(Query request, CancellationToken cancellationToken)
            {            
                var items = await _context.Projects
                    // .Where(x => x.Date >= request.StartDate)
                    .OrderBy(x => x.Deadline)
                    .ToListAsync();

                return items;
            }
        }
    }
}