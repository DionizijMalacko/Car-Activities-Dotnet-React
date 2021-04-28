using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class EditActivity
    {
        public class Command : IRequest
        {
            public CarActivity CarActivity {get; set;} //mora get i set
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper; //mora mapper posto cemo mapirati polja koja nisu izmenjena
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.CarActivity.Id);

                _mapper.Map(request.CarActivity, activity);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}