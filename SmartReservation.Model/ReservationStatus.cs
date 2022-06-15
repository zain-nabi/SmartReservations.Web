using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartReservation.Model
{
    [Table("ReservationStatus")]
    public class ReservationStatus
    {
        [Dapper.Contrib.Extensions.Key]
        public int reservationstatusID { get; set; }
        public string Status { get; set; }
    }
}
