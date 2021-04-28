using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class DeleteActivity
    {
        //Command kad se ne vraca nista, Query kada se vraca nesto
        public class Command : IRequest
        {
            public Guid Id { get; set; } //sta prosledjujem kao parametar
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
                var activity = await _context.Activities.FindAsync(request.Id);
                
                //ovo samo brise iz memorije
                _context.Remove(activity);

                //ovde onda sacuvamo izmene u bazu pa zbog toga ide await
                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }


    }
}