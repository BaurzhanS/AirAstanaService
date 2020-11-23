using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DatabaseAccess.Models
{
    public class FlightStatus
    {
        public int Id { get; set; }

        [Display(Name = "Статус рейса")]
        public string StatusName { get; set; }
    }
}
