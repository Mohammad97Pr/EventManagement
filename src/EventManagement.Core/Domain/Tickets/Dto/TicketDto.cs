using Abp.Application.Services.Dto;
using EventManagement.Domain.Events.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EventManagement.Enum;

namespace EventManagement.Domain.Tickets.Dto
{
    public class TicketDto : EntityDto
    {
        public EventDto EventDto { get; set; }
        public TicketStatus Status { get; set; }

    }
}
