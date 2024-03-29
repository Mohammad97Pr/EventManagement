using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using EventManagement.Authorization.Roles;
using EventManagement.Authorization.Users;
using EventManagement.MultiTenancy;
using EventManagement.Domain.Events;
using EventManagement.Domain.Tickets;

namespace EventManagement.EntityFrameworkCore
{
    public class EventManagementDbContext : AbpZeroDbContext<Tenant, Role, User, EventManagementDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventTranslation> EventTranslations { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        public EventManagementDbContext(DbContextOptions<EventManagementDbContext> options)
            : base(options)
        {
        }
    }
}
