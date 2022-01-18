using Common.Model;
using Common.Model.RequestModel;

namespace KU_Banking.Services.Interface {
    public interface ICustomerServices {
        ApiResponse GetCustomers();
        ApiResponse GetCustomer(Guid id);

        public Task<ApiResponse> CreateCustomerAsync(CreateCustomerRequest model);
    }
}
