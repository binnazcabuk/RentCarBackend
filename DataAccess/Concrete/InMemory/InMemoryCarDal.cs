using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car { CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 100, ModelYear = "2015", Description = " Arac 1" },
                new Car { CarId = 2, BrandId = 1, ColorId = 2, DailyPrice = 100, ModelYear = "2020", Description = " Arac 2" },
                new Car { CarId = 3, BrandId = 2, ColorId = 1, DailyPrice = 150, ModelYear = "2015", Description = " Arac 3" },
                new Car { CarId = 4, BrandId = 2, ColorId = 3, DailyPrice = 150, ModelYear = "2020", Description = " Arac 4" },
                new Car { CarId = 5, BrandId = 3, ColorId = 5, DailyPrice = 200, ModelYear = "2015", Description = " Arac 5" },
                new Car { CarId = 6, BrandId = 3, ColorId = 4, DailyPrice = 200, ModelYear = "2020", Description = " Arac 6" }
            };

        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.CarId == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
