using SmartReservation.Model.Custom;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartReservation.Interface
{
    public interface IDashboard
    {
        Task<Model.ReservationBooked> GetBookedReservations();
        Task<Model.ReservationArrived> GetArrivedReservations();
        Task<Model.ReservationComplete> GetCompleteReservations();
        Task<byte[]> GenerateReportAsync(string reportName, string reportType);
        Task<byte[]> BookedReservationsByDateAsync(string reportName, string reportType, DateTime startDate, DateTime endDate);
    }
}
