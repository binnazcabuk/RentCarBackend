using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Business.Contants;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCard;
        public CreditCardManager(ICreditCardDal creditCard)
        {
            _creditCard = creditCard;
        }
        public IResult Add(CreditCard creditCard)
        {
            _creditCard.Add(creditCard);
            return new SuccessResult("başarılı");
        }

        public IDataResult<List<CreditCard>> GetAllByUserId(int UserId)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCard.GetAll(p => p.UserId == UserId).ToList());

        }
    }
}
