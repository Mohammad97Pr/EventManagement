using Abp.Application.Services;
using EventManagement.Domain.Tickets.Dto;
using EventManagement.Domain.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.TicketServices
{
    public interface ITicketAppService : IAsyncCrudAppService<TicketDto, int, PagedTicketResultRequestDto, CreateTicketDto, UpdateTicketDto>
    {
    }
}
