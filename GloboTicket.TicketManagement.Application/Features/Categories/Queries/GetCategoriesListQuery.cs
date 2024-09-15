using GloboTicket.TicketManagement.Application.Features.Categories.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries
{
    public class GetCategoriesListQuery : IRequest<List<CategoryListVm>>
    {
    }
}
