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
        public class Query : IRequest<PaginationResult<Company>>
        {
            public int Index { get; set; } = 0;
            public int Count { get; set; } = 100;
        }

        public class Handler : IRequestHandler<Query, PaginationResult<Company>>
        {

            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<PaginationResult<Company>> Handle(Query request, CancellationToken cancellationToken)
            {
            
                var items = await _context.Companies
                    .OrderBy(x => x.Name)
                    .ToListAsync();

                return new PaginationResult<Company>
                {
                    Index = request.Index,
                    Count = request.Count,
                    TotalCount = items.Count,
                    Data = items
                };
            }
        }
    }
}