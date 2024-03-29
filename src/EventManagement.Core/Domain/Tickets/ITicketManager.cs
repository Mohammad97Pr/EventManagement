using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Domain.Tickets
{
    public interface ITicketManager : IDomainService
    {
        Task InsertNewTicket(Ticket ticket);
        Task CheckIfEventCanBeTicketed(int eventId,int numberOfTicketed);
    }
}
