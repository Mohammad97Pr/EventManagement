using Abp.Application.Services;
using EventManagement.Domain.Events.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.EventServices
{
    public interface IEventAppService: IAsyncCrudAppService<EventDto, int, PagedEventResultRequestDto, CreateEventDto, UpdateEventDto>
    {
    }
}
