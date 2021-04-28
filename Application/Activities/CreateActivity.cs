using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class CreateActivity
    {
        public class Command : IRequest
        {
            public CarActivity CarActivity { get; set; }
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
                _context.Activities.Add(request.CarActivity);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}