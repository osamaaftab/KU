using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.RequestModel {
    public class CreateTransactionModel {

        
        public Guid AccountId { get; set; }
       
        public decimal Amount { get; set; }
       
        public Guid? TransactionTypeId { get; set; }

    }
}
