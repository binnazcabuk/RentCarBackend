using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class CustomerDetailDto:IDto
    {
        public int Id { get; set; }
        public string  UserName { get; set; }
        
    }
}
