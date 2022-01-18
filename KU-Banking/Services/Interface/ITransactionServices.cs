using Common.Model;
using Common.Model.RequestModel;

namespace KU_Banking.Services.Interface {
    public interface ItransactionServices {




        public Task<ApiResponse> CreateTransaction(CreateTransactionModel model);

    }
}
