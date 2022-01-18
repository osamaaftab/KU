using DBContext.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.ResponseModel {
    public class CustomerResponseModel {
        
        public Guid CustomerId { get; set; }
       
        public string CustomerName { get; set; } = null!;
        
        public string? CustomerPhone { get; set; }
       
        public string? CustomerEmail { get; set; }
       
        public string? CustomerDob { get; set; }


    }
}
