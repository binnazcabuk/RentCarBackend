using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;
using Core.Extension;
using Business.Contants;

namespace Business.BusinessAspect.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        //istek yaparken her bir istek için httpcontext oluşturmak için
        //aynı isteği aynı anda birden fazla kişi yapıyor olabilir bu yüzden context oluştuyor
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            //rolleri virgülle ayırarak arraye at
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            //kullanıcı rollerini gez , eğer claimleri içinde  ilgili rol varsa metodu çalıştırmaya devam et
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            //yetkisi yoksa yetkin yok mesajı
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
