using AutoMapper;
using Common.Data;
using Common.Model;
using Common.Model.RequestModel;
using Common.Model.ResponseModel;
using DBContext.Data;
using KU_Banking.Services.Interface;
using Microsoft.EntityFrameworkCore;


namespace KU_Banking.Services.Imp {
    public class CustomerServices : ICustomerServices {

        private readonly IUnitofWork unitOfWork;
        private readonly IAPIResponse apiResponse;
        private readonly IMapper mapper;
        private readonly IRepository<Customer> customerRepository;
        private readonly IRepository<Address> addressRepository;

        public CustomerServices(IUnitofWork unitOfWork, IAPIResponse apiResponse, IMapper mapper) {
            this.unitOfWork = unitOfWork;
            this.apiResponse = apiResponse;
            this.mapper = mapper;
            customerRepository = unitOfWork.GetRepository<Customer>();
            addressRepository = unitOfWork.GetRepository<Address>();

        }
        public async Task<ApiResponse> CreateCustomerAsync(CreateCustomerRequest model) {

            try {

                var customer = mapper.Map<CreateCustomerRequest, Customer>(model);
                customer.CustomerId = Guid.NewGuid();
                customerRepository.Add(customer);
                unitOfWork.Commit();

                var address = mapper.Map<CreateCustomerRequest, Address>(model);
                address.AddressId = Guid.NewGuid();
                address.CustomerId = customer.CustomerId;
                addressRepository.Add(address);
                unitOfWork.Commit();
               
                return apiResponse.Success(ResponseMessages.ActionCompleted, model);

            } catch (Exception ex) {
                return apiResponse.InternalFailure(ResponseMessages.UnExpectedErrorOccured, null);

            }
        }

        public ApiResponse GetCustomer(Guid id) {
            var customer = customerRepository.Get(id);
            return apiResponse.Success(ResponseMessages.ActionCompleted, customer);
        }

        public ApiResponse GetCustomers() {
            var acccounts = customerRepository.GetAll()
                  .ToList();

            return apiResponse.Success(ResponseMessages.ActionCompleted, acccounts);
        }
    }
}
