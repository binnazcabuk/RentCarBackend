using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business.Concrete
{
    public class FakeCardManager : IFakeCardService
    {
        IFakeCardDal _fakeCard;
        public IDataResult<List<FakeCard>> GetAllByUserId(int UserId)
        {
            return new SuccessDataResult<List<FakeCard>>(_fakeCard.GetAll(p => p.UserId == UserId).ToList());
        }
    }
}
