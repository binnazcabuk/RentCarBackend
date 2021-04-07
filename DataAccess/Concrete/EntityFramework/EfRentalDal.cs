using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarDatabaseContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (CarDatabaseContext context = new CarDatabaseContext())
            {
                var result = from rt in context.Rentals 
                             join cr in context.Cars on rt.CarId equals cr.CarId
                             join cst in context.Customers on rt.CustomerId equals cst.UserId
                             join usr in context.Users on cst.UserId equals usr.Id
                             join brd in context.Brands on cr.BrandId equals brd.BrandId
                             join clr in context.Colors on cr.ColorId equals clr.ColorId
                             select new RentalDetailDto
                             {
                                 RentalId = rt.Id,
                                 CompanyName = cst.CompanyName,
                                 CarModel = cr.ModelYear,
                                 CarBrand=brd.BrandName,
                                 CarDescription = cr.Description,
                                 CarId = rt.CarId,
                                 FirstName = usr.FirstName,
                                 LastName = usr.LastName,
                                 UserId = usr.Id,
                                 RentDate = rt.RentDate,
                                 ReturnDate = rt.ReturnDate
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

       
    }
}
