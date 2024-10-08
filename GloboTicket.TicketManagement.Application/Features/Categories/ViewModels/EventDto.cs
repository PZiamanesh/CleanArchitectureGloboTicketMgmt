﻿using System;

namespace GloboTicket.TicketManagement.Application.Features.Categories.ViewModels
{
    public class EventDto
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public Guid CategoryId { get; set; }
    }
}
