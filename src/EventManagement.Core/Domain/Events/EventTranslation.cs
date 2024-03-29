using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace EventManagement.Domain.Events
{
    public class EventTranslation : FullAuditedEntity, IEntityTranslation<Event>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Event Core { get; set; }
        public int CoreId { get; set; }
        public string Language { get; set; }
    }
}