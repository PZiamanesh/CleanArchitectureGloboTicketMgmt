using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Contracts.Presistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
    }
}
