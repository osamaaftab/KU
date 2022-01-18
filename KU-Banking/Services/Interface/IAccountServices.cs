using Common.Model;
using Common.Model.RequestModel;

namespace KU_Banking.Services {
    public interface IAccountServices {
        ApiResponse GetAcounts();
        ApiResponse GetAccount(Guid id);
        public  Task<ApiResponse> CreateAccountAsync(CreateAccountRequest model);
    }
}
