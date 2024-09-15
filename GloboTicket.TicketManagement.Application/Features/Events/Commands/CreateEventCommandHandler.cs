using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Exceptions;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Features.Events.Validators;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IMapper _mapper;

        public CreateEventCommandHandler(
            IAsyncRepository<Event> eventRepository,
            IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEventCommandValidator((IEventRepository)_eventRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
            {
                throw new ValidationException(validationResult);
            }

            var @event = _mapper.Map<Event>(request);
            var createdEvent = await _eventRepository.AddAsync(@event);

            return createdEvent.EventId;
        }
    }
}
