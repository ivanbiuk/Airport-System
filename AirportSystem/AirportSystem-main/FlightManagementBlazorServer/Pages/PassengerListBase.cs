using DomainModel.Models;
using FlightManagementBlazorServer.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementBlazorServer.Pages
{
    public class PassengerListBase : ComponentBase
    {
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        [Inject]
        private PassengerService _passengerService { get; set; }
        public List<Passenger> Passengers { get; set; }
        protected void OpenAddPassengerPage(int flightId, int userId)
        {
            _navigationManager.NavigateTo($"/AddPassenger/{flightId}/{userId}");
        }

        protected void OpenEditPassengerPage(int passengerId, int userId)
        {
            _navigationManager.NavigateTo($"/EditPassenger/{passengerId}/{userId}");
        }
        protected void OpenCheckInPassengerPage(int passengerId, int userId)
        {
            _navigationManager.NavigateTo($"/CheckInPassenger/{passengerId}/{userId}");
        }

        protected async Task DeletePassengerAsync(int passengerId, int flightId)
        {
            await _passengerService.DeletePassenger(passengerId);
            Passengers = await _passengerService.GetPassengersAsync(flightId);
            foreach (var passenger in Passengers.ToList())
            {
                if (passenger.FlightId != flightId)
                    Passengers.Remove(passenger);
            }
        }

        protected void OpenPassengerListPage(int flightId, int userId)
        {
            _navigationManager.NavigateTo($"/PassengerList/{flightId}/{userId}");
        }

        protected void OpenCheckedInPassengersListPage(int flightId, int userId)
        {
            _navigationManager.NavigateTo($"/CheckedInPassengersList/{flightId}/{userId}");
        }

        protected async Task<List<Passenger>> GetPassengersAsync(int flightId)
        {
            return await _passengerService.GetPassengersAsync(flightId);
        }

    }
}
