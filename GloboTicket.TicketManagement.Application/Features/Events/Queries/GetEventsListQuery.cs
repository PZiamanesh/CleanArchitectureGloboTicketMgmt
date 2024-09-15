using GloboTicket.TicketManagement.Application.Features.Events.ViewModels;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries
{
    public class GetEventsListQuery : IRequest<List<EventListVm>>
    {
    }
}
