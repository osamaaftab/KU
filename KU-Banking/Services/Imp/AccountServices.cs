using AutoMapper;
using Common.Data;
using Common.Model;
using Common.Model.RequestModel;
using DBContext.Data;
using KU_Banking.Services;

namespace KU_Banking.Services {
    public sealed class AccountServices : IAccountServices {
        private readonly IUnitofWork unitOfWork;
        private readonly IAPIResponse apiResponse;
        private readonly IMapper mapper;
        private readonly IRepository<Account> accountRepository;
        public ApiResponse GetAccount(Guid id) {
            var account = accountRepository.Get(id);
            return apiResponse.Success(ResponseMessages.ActionCompleted, account);

        }
        public AccountServices(IUnitofWork unitOfWork, IAPIResponse apiResponse, IMapper mapper) {
            this.unitOfWork = unitOfWork;
            this.apiResponse = apiResponse;
            this.mapper = mapper;
            accountRepository = unitOfWork.GetRepository<Account>();
        }
        public ApiResponse GetAcounts() {
            var acccounts = accountRepository.GetAll(1, 10)
                    .ToList();

            return apiResponse.Success(ResponseMessages.ActionCompleted, acccounts);
        }
        public async Task<ApiResponse> CreateAccountAsync(CreateAccountRequest model) {

            var account = mapper.Map<CreateAccountRequest, Account>(model);
            account.AccountId = Guid.NewGuid();
            account.DateOpned = DateTime.Now;
            accountRepository.Add(account);
            unitOfWork.Commit();
            return apiResponse.Success(ResponseMessages.ActionCompleted, model);
        }

    }
}
