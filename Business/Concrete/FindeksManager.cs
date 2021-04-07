using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class FindeksManager : IFindeksService
    {
        IFindexDal _findexDal;
        public IDataResult<List<Findex>> GetAllByUserId(int UserId)
        {
            return new SuccessDataResult<List<Findex>>(_findexDal.GetAll(p => p.UserId == UserId).ToList());
        }
    }
}
