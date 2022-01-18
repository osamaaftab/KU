using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.RequestModel {
    public class CreateCustomerRequest {
       
        public string CustomerName { get; set; } = null!;
        public string? CustomerPhone { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerDob { get; set; }
        public string Line1 { get; set; } = null!;
        public string Line2 { get; set; } = null!;
        public string? City { get; set; }
        public int? PostCode { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }

    }
}
