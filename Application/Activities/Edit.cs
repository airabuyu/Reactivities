using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Activity Activity {get; set;}
        }

        public class Handler : IRequestHandler<Command>
        {
            public DataContext context { get; }
            private readonly IMapper mapper;
            public Handler(DataContext context, IMapper mapper)
            {
            this.mapper = mapper;
                this.context = context;
                this.mapper = mapper;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync(request.Activity.Id);

                // activity.Title = request.Activity.Title ?? activity.Title;
                mapper.Map(request.Activity, activity);

                await context.SaveChangesAsync();
            }
        }
    }
}