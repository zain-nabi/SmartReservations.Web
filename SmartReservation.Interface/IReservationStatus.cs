using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartReservation.Interface
{
    public interface IReservationStatus
    {
        Task<List<Model.ReservationStatus>> ReservationStatuses();
    }
}
