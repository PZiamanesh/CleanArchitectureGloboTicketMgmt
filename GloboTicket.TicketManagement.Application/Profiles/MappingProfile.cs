using AutoMapper;
using GloboTicket.TicketManagement.Application.Features.Categories.Commands;
using GloboTicket.TicketManagement.Application.Features.Categories.ViewModels;
using GloboTicket.TicketManagement.Application.Features.Events.Commands;
using GloboTicket.TicketManagement.Application.Features.Events.ViewModels;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryListVm>().ReverseMap();
            CreateMap<Category, CategoryEventListVm>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
        }
    }
}
