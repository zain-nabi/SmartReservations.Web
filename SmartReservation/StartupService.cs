using Microsoft.Extensions.DependencyInjection;
using SmartReservation.Interface;
using SmartReservation.Service;

namespace SmartReservation
{
    public class StartupService
    {
        public static void AddService(IServiceCollection services)
        {
            services.AddScoped<IRole, RoleService>();
            services.AddScoped<IExternalUser, ExternalUserService>();
            services.AddScoped<IExternalUserRole, ExternalUserRoleService>();
            services.AddScoped<IRestaurant, RestaurantService>();
            services.AddScoped<IReservation, ReservationService>();
            services.AddScoped<IReservationStatus, ReservationStatusService>();
            services.AddScoped<ITableSettings, TableSettingsService>();
            services.AddScoped<IMenuItem, MenuItemService>();
            services.AddScoped<IOrder, OrderRepository>();
        }
    }
}
