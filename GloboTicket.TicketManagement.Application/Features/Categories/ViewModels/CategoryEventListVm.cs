namespace GloboTicket.TicketManagement.Application.Features.Categories.ViewModels
{
    public class CategoryEventListVm
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }

        public ICollection<EventDto> Events { get; set; }
    }
}
