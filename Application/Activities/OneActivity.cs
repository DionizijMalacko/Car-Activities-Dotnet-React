using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class OneActivity
    {
        //mora da se navede sta se vraca ako ga ima, inace imamo exception
        public class Query : IRequest<CarActivity> 
        {
            public Guid Id { get; set; } //parametar koji prosledjujemo
        }

        public class Handler : IRequestHandler<Query, CarActivity>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<CarActivity> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Activities.FindAsync(request.Id);
                
            }
        }
    }
}