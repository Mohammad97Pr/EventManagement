using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EventManagement.Enum;

namespace EventManagement.Domain.Tickets
{
    public class TicketManager : DomainService, ITicketManager
    {
        private readonly IRepository<Ticket> _ticketRepository;
        public TicketManager(IRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task CheckIfEventCanBeTicketed(int eventId, int numberOfTicketed)
        {
            var numberOfTicketedInDb = await _ticketRepository.CountAsync(x => x.EventId == eventId && x.Status == TicketStatus.Booked);
            if (numberOfTicketedInDb < numberOfTicketed)
                return;
            else
                throw new UserFriendlyException(403, L("EventFullyBooked"));
        }

        public async Task InsertNewTicket(Ticket ticket)
        {
            await _ticketRepository.InsertAsync(ticket);
        }
    }
}
