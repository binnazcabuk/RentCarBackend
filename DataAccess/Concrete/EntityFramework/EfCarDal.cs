using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarDatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (CarDatabaseContext context = new CarDatabaseContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                            

                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 Description = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 BrandId=b.BrandId,
                                 ColorId=co.ColorId,
                                 Model=b.Model,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 ImagePath = (from a in context.CarImages where a.CarId == c.CarId select a.ImagePath).FirstOrDefault()

                             };



                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
          

           
        }
    }

