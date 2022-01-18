using AutoMapper;
using Common.Model.RequestModel;
using DBContext.Data;

namespace KU_Banking.Configuration.Mapping_Entities {
    public class CustomerMappingProfile : MapperConfigurationExpression {

        public CustomerMappingProfile() {

            CreateMap<CreateCustomerRequest, Address>();
            CreateMap<CreateCustomerRequest, Customer>();

        }
    }
}
