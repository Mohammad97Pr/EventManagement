using AutoMapper;
using EventManagement.Domain.Tickets;
using EventManagement.Domain.Tickets.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.TicketServices.Mapper
{
    public class TicketMapProfile : Profile
    {
        public TicketMapProfile()
        {
            CreateMap<Ticket, TicketDto>();
        }
    }
}
