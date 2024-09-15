using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands
{
    public class DeleteEventCommand : IRequest
    {
        public Guid EventId { get; set; }
    }
}
