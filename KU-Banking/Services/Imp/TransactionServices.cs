
using AutoMapper;
using Common.Data;
using Common.Model;
using Common.Model.RequestModel;
using KU_Banking.Services.Interface;
using System.Transactions;

namespace KU_Banking.Services.Imp {
    public class TransactionServices : ItransactionServices {

        private readonly IUnitofWork unitOfWork;
        private readonly IAPIResponse apiResponse;
        private readonly IMapper mapper;
        private readonly IRepository<Transaction> transactionRepository;

        public TransactionServices(IUnitofWork unitOfWork, IAPIResponse apiResponse, IMapper mapper) {
            this.unitOfWork = unitOfWork;
            this.apiResponse = apiResponse;
            this.mapper = mapper;
            transactionRepository = unitOfWork.GetRepository<Transaction>();
        }


        public Task<ApiResponse> CreateTransaction(CreateTransactionModel model) {
            throw new NotImplementedException();
        }
    }
}
