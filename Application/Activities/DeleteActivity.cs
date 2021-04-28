using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class DeleteActivity
    {
        public class Command : IRequest //Command kad se ne vraca nista, Query kada se vraca nesto
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

                var activity = _context.Activities.FindAsync(request.Id);
                _context.Remove(activity); //nzm zasto ne moze _context.Activities.Remove(activity)
                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }


    }
}