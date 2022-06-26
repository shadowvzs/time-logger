using Domain;
using Persistence;

using MediatR;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Linq;
using System;

namespace Application.Projects
{
    public class List
    {

        public class FilterQuery
        {
            public Guid? CompanyId { get; set; }
            public string SortKey { get; set; }
            public string SortDir { get; set; }
            public int Index { get; set; } = 0;
            public int Count { get; set; } = 100;
        }

        public class Query : IRequest<PaginationResult<Project>>
        {
            public Guid? CompanyId { get; set; }
            public string SortKey { get; set; } = "Name";
            public string SortDir { get; set; } = "ASC";
            public int Index { get; set; }
            public int Count { get; set; }
        }

        public class Handler : IRequestHandler<Query, PaginationResult<Project>>
        {

            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;            
            }

            public async Task<PaginationResult<Project>> Handle(Query request, CancellationToken cancellationToken)
            {            
                var query = _context.Projects.AsQueryable();
                if (request.CompanyId != null && request.CompanyId != Guid.Empty) {
                    query = query.Where(x => x.CompanyId == request.CompanyId);
                }
                
                
                var asc = request.SortDir != "DESC";
                if (!string.IsNullOrWhiteSpace(request.SortKey) && !string.IsNullOrWhiteSpace(request.SortDir)) {
                    switch (request.SortKey) {
                        case "name":
                            query = asc ? query.OrderBy(x => x.Name) : query.OrderByDescending(x => x.Name);
                            break;
                        case "companyName":
                            query = asc ? query.OrderBy(x => x.Company.Name) : query.OrderByDescending(x => x.Company.Name);
                            break;                            
                        case "deadline":
                            query = asc ? query.OrderBy(x => x.Deadline) : query.OrderByDescending(x => x.Deadline);
                            break;     
                        case "timeSpent":
                            query = asc ? query.OrderBy(x => x.Logs.Sum(x => x.LoggedMinutes)) : query.OrderByDescending(x => x.Logs.Sum(x => x.LoggedMinutes));
                            break;     
                        case "completed":
                            query = asc ? query.OrderBy(x => x.Completed) : query.OrderByDescending(x => x.Completed);
                            break;  
                        default:
                            query = asc ? query.OrderBy(x => x.Deadline) : query.OrderByDescending(x => x.Deadline);
                            break;
                    }
                }
                var items = await query.ToListAsync();

                return new PaginationResult<Project>
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