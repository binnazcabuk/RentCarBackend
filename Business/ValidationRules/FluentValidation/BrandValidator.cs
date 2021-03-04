using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public  class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.Model).NotEmpty();
            RuleFor(b => b.Model).MinimumLength(2).WithMessage("Model min 2 harf olmali");

            RuleFor(b => b.BrandName).NotEmpty();
            RuleFor(b => b.BrandName).MinimumLength(2).WithMessage("Name min 2 harf olmali");
        }
    }
}
