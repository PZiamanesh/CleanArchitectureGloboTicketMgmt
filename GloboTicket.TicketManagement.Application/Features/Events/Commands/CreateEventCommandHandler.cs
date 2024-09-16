using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Exceptions;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Features.Events.Validators;
using GloboTicket.TicketManagement.Application.Models.Mail;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateEventCommandHandler(
            IAsyncRepository<Event> eventRepository,
            IMapper mapper,
            IEmailService emailService)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _emailService = emailService;
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

            try
            {
                var email = new Email()
                {
                    To = "po2.ziamanesh@gmail.com",
                    Subject = "A new event was created!",
                    Body = $"hi!\nevent {request.Name} created!\n{request.Description}"
                };

                await _emailService.SendEmail(email);
            }
            catch (Exception)
            {

                // log and other procedures
            }

            return createdEvent.EventId;
        }
    }
}
