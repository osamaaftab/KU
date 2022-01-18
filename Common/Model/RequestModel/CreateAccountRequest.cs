using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.RequestModel {
    public class CreateAccountRequest {
      
        public Guid CustomerId { get; set; } 

        public string AccountName { get; set; } = null!;
      
        public decimal? CurrentBalance { get; set; }

    }
}
