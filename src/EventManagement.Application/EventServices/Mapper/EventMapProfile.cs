using AutoMapper;
using EventManagement.Domain.Events;
using EventManagement.Domain.Events.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.EventServices.Mapper
{
    public class EventMapProfile:Profile
    {
        public EventMapProfile()
        {
            CreateMap<CreateEventDto, Event>();
            CreateMap<UpdateEventDto, Event>();
        }
    }
}
