using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //Gönderilen type bir validation değilse hata ver
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir dogrulama sinifi degil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //reflection/çalışma anında bu işlem çalışır
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
           //verilen validator type'ın çalışma tipini bul(<Car>)
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //ilgili metodun paremetrelerini al ,entityType ile aynı olanları bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                //tool'u kullanarak doğrulama yap
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
