﻿namespace GloboTicket.TicketManagement.Application.Features.Categories.ViewModels
{
    public class CreateCategoryDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
