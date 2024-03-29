using Abp.Application.Services;
using Abp.Domain.Repositories;
using EventManagement.Domain.Events.Dto;
using EventManagement.Domain.Events;
using EventManagement.Domain.Tickets;
using EventManagement.Domain.Tickets.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization;
using static EventManagement.Enum;
using Abp.Application.Services.Dto;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.TicketServices
{
    [AbpAuthorize]
    public class TicketAppService : AsyncCrudAppService<Ticket, TicketDto, int, PagedTicketResultRequestDto, CreateTicketDto, UpdateTicketDto>, ITicketAppService
    {
        private readonly IEventManager _eventManager;
        private readonly ITicketManager _ticketManager;
        public TicketAppService(IRepository<Ticket, int> repository, IEventManager eventManager, ITicketManager ticketManager) : base(repository)
        {
            _eventManager = eventManager;
            _ticketManager = ticketManager;
        }
        public override async Task<PagedResultDto<TicketDto>> GetAllAsync(PagedTicketResultRequestDto input)
        {
            return await base.GetAllAsync(input);
        }

        public override async Task<TicketDto> CreateAsync(CreateTicketDto input)
        {
            var numberOfTicket = await _eventManager.CheckIfEventIsExistAndGetNumberOfTicket(input.EventId);
            await _ticketManager.CheckIfEventCanBeTicketed(input.EventId, numberOfTicket);
            var ticket = new Ticket
            {
                EventId = input.EventId,
                UserId = AbpSession.UserId.Value
            };
            await _ticketManager.InsertNewTicket(ticket);
            return MapToEntityDto(ticket);
        }
        public async Task CancelTicket(int ticketId)
        {
            var ticket = await Repository.GetAsync(ticketId);
            ticket.Status = TicketStatus.Canceled;
            await Repository.UpdateAsync(ticket);
            await UnitOfWorkManager.Current.SaveChangesAsync();

        }
        protected override IQueryable<Ticket> CreateFilteredQuery(PagedTicketResultRequestDto input)
        {
            var data = base.CreateFilteredQuery(input);
            data = data.Include(x => x.Event).ThenInclude(x => x.Translations).AsNoTracking();
            if (input.GetMyTicket)
                data = data.Where(x => x.UserId == AbpSession.UserId.Value);
            return data;
        }
    }
}
