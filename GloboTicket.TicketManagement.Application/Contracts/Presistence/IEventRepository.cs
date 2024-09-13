using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Contracts.Presistence
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
    }
}
