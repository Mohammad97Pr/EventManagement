using Abp.AutoMapper;
using EventManagement.Domain.Events.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventManagement.Domain.Events.Dto
{
    public class CreateEventDto
    {
        [Required]
        public int NumberOfAvailableTickets { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public List<EventTranslationDto> Translations { get; set; }
    }
}
