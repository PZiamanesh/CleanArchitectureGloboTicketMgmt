using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Contracts.Presistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
    }
}
