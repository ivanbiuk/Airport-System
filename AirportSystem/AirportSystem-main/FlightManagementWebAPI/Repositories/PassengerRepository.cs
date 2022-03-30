using DomainModel.Models;
using FlightManagementWebAPI.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementWebAPI.Repositories
{
    public class PassengerRepository
    { 
        private readonly AirportSystemContext _airportSystemContext;

        public PassengerRepository(AirportSystemContext airportSystemContext)
        {
            _airportSystemContext = airportSystemContext;
        }

        public List<Passenger> GetPassengers(int flightId)
        {
            return _airportSystemContext.Passengers.Where(passenger => passenger.FlightId == flightId).ToList();
        }

        public Passenger GetPassenger(int passengerId)
        {
            return _airportSystemContext.Passengers.FirstOrDefault(passenger => passenger.Id == passengerId);
        }
        public void AddPassenger(Passenger passenger)
        {
            _airportSystemContext.Passengers.Add(passenger);
            _airportSystemContext.SaveChanges();
        }
        public void UpdatePassenger(Passenger passenger)
        {
            var passengerForUpdate = GetPassenger(passenger.Id);
            if (passengerForUpdate != null)
            {
                passengerForUpdate.Name = passenger.Name;
                passengerForUpdate.Surname = passenger.Surname;
                passengerForUpdate.Gender = passenger.Gender;
                passengerForUpdate.Seat = passenger.Seat;
                passengerForUpdate.BaggageItems = passenger.BaggageItems;
                passengerForUpdate.BaggageWeight = passenger.BaggageWeight;
                passengerForUpdate.NameInDocument = passenger.NameInDocument;
                passengerForUpdate.SurnameInDocument = passenger.SurnameInDocument;
                passengerForUpdate.DocumentType = passenger.DocumentType;
                passengerForUpdate.DocumentNumber = passenger.DocumentNumber;
                passengerForUpdate.DocumentExpirationDate = passenger.DocumentExpirationDate;

                _airportSystemContext.SaveChanges();
            }
        }
        public void DeletePassenger(int passengerId)
        {
            var passengerForDelete = GetPassenger(passengerId);
            if (passengerForDelete != null)
            {
                _airportSystemContext.Passengers.Remove(passengerForDelete);
                _airportSystemContext.SaveChanges();
            }
        }
        public void CheckInPassenger(int passengerId)
        {
            var passengerForCheckIn = GetPassenger(passengerId);
            if(passengerForCheckIn != null)
            {
                passengerForCheckIn.IsChecked = true;
                _airportSystemContext.SaveChanges();
            }
        }

        public List<Passenger> GetCheckedInPassengers(int flightId)
        {
            return _airportSystemContext.Passengers.Where(passenger => (passenger.FlightId == flightId && passenger.IsChecked == true)).ToList();
        }
    }
}
