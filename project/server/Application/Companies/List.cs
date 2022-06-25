using Domain;
using Persistence;

using MediatR;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Application.Companies
{
    public class List
    {
        public class Query : IRequest<List<Company>>
        {
        }

        public class Handler : IRequestHandler<Query, List<Company>>
        {

            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<Company>> Handle(Query request, CancellationToken cancellationToken)
            {
            
                var items = await _context.Companies
                    // .Where(x => x.Date >= request.StartDate)
                    .OrderBy(x => x.Name)
                    .ToListAsync();

                return items;
            }
        }
    }
}