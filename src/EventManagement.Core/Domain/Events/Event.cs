using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using EventManagement.Authorization.Users;
using EventManagement.Domain.Tickets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Domain.Events
{
    public class Event : FullAuditedEntity, IMultiLingualEntity<EventTranslation>
    {
        public int NumberOfAvailableTickets { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public long UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        public ICollection<EventTranslation> Translations { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
