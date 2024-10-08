﻿using GloboTicket.TicketManagement.Application.Features.Categories.ViewModels;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
    }
}
