using Assignment10._3.Data;
using Assignment10._3.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment10._3
{
    internal class CRUD
    {
        public void AddCar(Car car)
        {
            Records.context.Cars.Add(car);
            Records.context.SaveChanges();
        }

        public List<Car> GetCars()
        {
            return Records.context.Cars.ToList();
        }

        public List<BillGatesGarage> GetGarages()
        {
            return Records.context.Garages.ToList();
        }

        public void DeleteCar(long vin)
        {
            var car = Records.context.Cars.Find(vin);
            if(car != null)
            {
                Records.context.Cars.Remove(car);
                Records.context.SaveChanges();
            }
        }

        public void UpdateCar(long vin, Car updatedCar)
        {
            var car = Records.context.Cars.Find(vin);
            if (car != null)
            {
                car.Make = updatedCar.Make;
                car.Model = updatedCar.Model;
                car.Price = updatedCar.Price;
                car.Year = updatedCar.Year;
                car.GarageID = updatedCar.GarageID;
                Records.context.SaveChanges();
            }
        }

        public Car? getCar(long vin)
        {
            return Records.context.Cars.Find(vin);
        }

    }
}
