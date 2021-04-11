using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarDatabaseContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (CarDatabaseContext context = new CarDatabaseContext())
            {
                var result = from ct in filter == null ? context.Customers : context.Customers.Where(filter)
                             join us in context.Users
                                 on ct.UserId equals us.Id
                             select new CustomerDetailDto
                             {
                                
                                 UserId = us.Id,
                                 CompanyName = ct.CompanyName,
                                 Email = us.Email,
                                 UserName = us.FirstName + " " + us.LastName,
                                 FindexScore=ct.FindexScore

                             };
                return result.ToList();

            }
        }
    }
}
