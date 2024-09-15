using GloboTicket.TicketManagement.Application.Features.Categories.ViewModels;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries
{
    public class GetCategoriesListWithEventsQuery : IRequest<List<CategoryEventListVm>>
    {
        public bool IncludeHistory { get; set; }
    }
}
