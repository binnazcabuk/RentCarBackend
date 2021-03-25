using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
  
       
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int ColorId);
        IDataResult<List<CarDetailDto>> GetCarsDetailByBrandId(int BrandId);
        IDataResult<List<CarDetailDto>> GetCarDetailById(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetCarDetailsFilter(int brandId, int colorId);
        IResult AddTransactionTest(Car car);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
    }
}
