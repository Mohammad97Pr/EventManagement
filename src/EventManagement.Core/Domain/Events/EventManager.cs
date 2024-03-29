using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using EventManagement.Domain.Events.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Domain.Events
{
    public class EventManager : DomainService, IEventManager
    {
        private readonly IRepository<Event> _eventRepository;
        private readonly IRepository<EventTranslation> _eventTranslationRepository;
        public EventManager(IRepository<Event> eventRepository, IRepository<EventTranslation> eventTranslationRepository)
        {
            _eventRepository = eventRepository;
            _eventTranslationRepository = eventTranslationRepository;
        }

        public async Task<int> CheckIfEventIsExistAndGetNumberOfTicket(int eventId)
        {
            var entity = await _eventRepository.GetAsync(eventId) ??
            throw new UserFriendlyException(404, L("EventWasNotFound"));
            return entity.NumberOfAvailableTickets;
        }

        public async Task DeleteEvent(Event eventToDelete)
        {
            await DeleteOldTranslationForEvent(eventToDelete.Id);
            await _eventRepository.DeleteAsync(eventToDelete);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        public async Task DeleteOldTranslationForEvent(int eventId)
        {
            await _eventTranslationRepository.GetAll()
                .AsTracking()
                .Where(x => x.CoreId == eventId)
                .ExecuteDeleteAsync();
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        public async Task<Event> GetEventByIdAsync(int eventId)
        {
            return await _eventRepository.GetAsync(eventId);
        }

        public async Task<EventDto> InsertNewEventAsync(Event newEvent)
        {
            var insertedEvent = await _eventRepository.InsertAsync(newEvent);
            return ObjectMapper.Map<EventDto>(insertedEvent);
        }
    }
}
