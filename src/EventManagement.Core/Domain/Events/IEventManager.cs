using Abp.Domain.Services;
using EventManagement.Domain.Events.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Domain.Events
{
    public interface IEventManager : IDomainService
    {
        Task<EventDto> InsertNewEventAsync(Event newEvent);
        Task<Event> GetEventByIdAsync(int eventId);
        Task DeleteOldTranslationForEvent(int eventId);
        Task DeleteEvent(Event eventToDelete);
        Task<int> CheckIfEventIsExistAndGetNumberOfTicket(int eventId);
    }
}
