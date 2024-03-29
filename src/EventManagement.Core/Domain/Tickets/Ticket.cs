using Abp.Domain.Entities.Auditing;
using EventManagement.Authorization.Users;
using EventManagement.Domain.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EventManagement.Enum;

namespace EventManagement.Domain.Tickets
{
    public class Ticket : FullAuditedEntity
    {
        public int? EventId { get; set; }
        [ForeignKey(nameof(EventId))]
        public virtual Event Event { get; set; }
        public long UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        public TicketStatus Status { get; set; }
    }
}
