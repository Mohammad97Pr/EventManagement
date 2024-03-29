using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AutoMapper;
using EventManagement.Domain.Events;
using EventManagement.Domain.Events.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.EventServices
{
    public class EventAppService : AsyncCrudAppService<Event, EventDto, int, PagedEventResultRequestDto, CreateEventDto, UpdateEventDto>, IEventAppService
    {
        private readonly IEventManager _eventManager;
        private readonly IMapper _mapper;
        public EventAppService(IRepository<Event, int> repository,
            IEventManager eventManager,
            IMapper mapper)
            : base(repository)
        {
            _eventManager = eventManager;
            _mapper = mapper;
        }
        public override async Task<EventDto> CreateAsync(CreateEventDto input)
        {
            var newEvent = ObjectMapper.Map<Event>(input);
            newEvent.UserId = AbpSession.UserId.Value;
            return await _eventManager.InsertNewEventAsync(newEvent);
        }
        public override async Task<PagedResultDto<EventDto>> GetAllAsync(PagedEventResultRequestDto input)
        {
            return await base.GetAllAsync(input);
        }
        public override async Task<EventDto> UpdateAsync(UpdateEventDto input)
        {

            var entity = await _eventManager.GetEventByIdAsync(input.Id);
            await _eventManager.DeleteOldTranslationForEvent(entity.Id);
            _mapper.Map<Event>(input);
            await Repository.UpdateAsync(entity);
            await UnitOfWorkManager.Current.SaveChangesAsync();
            return MapToEntityDto(entity);
        }
        public override async Task DeleteAsync(EntityDto<int> input)
        {
            var eventToDelete = await _eventManager.GetEventByIdAsync(input.Id);
            await _eventManager.DeleteEvent(eventToDelete);
        }
        protected override IQueryable<Event> CreateFilteredQuery(PagedEventResultRequestDto input)
        {
            var data = base.CreateFilteredQuery(input);
            data = data.Include(x => x.Translations);
            return data;
        }

    }
}
