using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace EventManagement.Domain.Events.Dto
{
    public class EventDto : EntityDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}


