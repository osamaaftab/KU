using AutoMapper;
using Common.Model.ResponseModel;
using DBContext.Data;

namespace KU_Banking.Configuration.MappingEntities {
    public class AccountMappingProfile : MapperConfigurationExpression {
        public AccountMappingProfile() {
            CreateMap<Account, AccountResponseModel>();
        }
    }
}
