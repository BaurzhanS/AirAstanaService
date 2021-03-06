﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DatabaseAccess.Models
{
    public class Flight
    {
        public int Id { get; set; }

        [Display(Name = "Откуда")]
        public string Departure { get; set; }

        [Display(Name = "Куда")]
        public string Destination { get; set; }

        [Display(Name = "Время вылета")]
        public DateTime? DepartureTime { get; set; }

        [Display(Name = "Время прилета")]
        public DateTime? DestinationTime { get; set; }

        [Display(Name = "Статус рейса")]
        public int FlightStatusId { get; set; }
        public FlightStatus FlightStatus { get; set; }


        [Display(Name = "Информация по рейсу")]
        public string Note { get; set; }
    }
}
