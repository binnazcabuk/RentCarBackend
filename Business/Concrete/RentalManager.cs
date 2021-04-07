using Business.Abstract;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            DateTime date = DateTime.Now;
          
              
                if (rental.ReturnDate < date) { rental.Status = false;
                
                }
                else
                {
                    rental.Status = true;
                }
               _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
           

        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<RentalDetailDto> GetRentalDetailByCarId(int carId)
        {

            var result = _rentalDal.GetRentalDetails(r => r.CarId == carId).LastOrDefault();
            return new SuccessDataResult<RentalDetailDto>(result, Messages.RentalGetAllSuccess);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalsDetailByUserId(int userId)
        {
            var result = _rentalDal.GetRentalDetails(r => r.UserId == userId).ToList();
            return new SuccessDataResult<List<RentalDetailDto>>(result, Messages.RentalGetAllSuccess);
        }


        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CarId == id));
        }

        public IDataResult<List<Rental>> GetByCarId(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == id));
        }
        public IDataResult<List<RentalDetailDto>> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

      
    }
}
