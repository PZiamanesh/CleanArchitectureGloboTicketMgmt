using FluentValidation;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Features.Events.Commands;

namespace GloboTicket.TicketManagement.Application.Features.Events.Validators
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public CreateEventCommandValidator(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Date)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(DateTime.Now);

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);

            RuleFor(p => p)
                .MustAsync(CheckUniqueEventNameAndDate).WithMessage("An event with same name and date already exists.");
        }

        private async Task<bool> CheckUniqueEventNameAndDate(CreateEventCommand createEventCommand, CancellationToken token)
        {
            var result = await _eventRepository.IsEventNameAndDateUnique(createEventCommand.Name, createEventCommand.Date);
            return !result;
        }
    }
}
